using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Threading;
using Abp.UI;
using Abp.Web.Mvc.Models;
using DogeDaycare.Authorization.Roles;
using DogeDaycare.MultiTenancy;
using DogeDaycare.Users;
using DogeDaycare.Web.Controllers.Results;
using DogeDaycare.Web.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Abp.Net.Mail.Smtp;
using System.Net.Mail;
using System.Text;
using Abp.Domain.Repositories;
using Abp.Logging;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Microsoft.Owin.Security.DataProtection;
using Abp.Web.Models;
using Abp.Runtime.Validation;
using DogeDaycare.Emails;

namespace DogeDaycare.Web.Controllers
{
    public class AccountController : DogeDaycareControllerBase
    {
        private readonly TenantManager _tenantManager;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly ISmtpEmailSender _smtpEmailSender;
        private readonly ISmtpEmailSenderConfiguration _smtpEmailSenderConfiguration;
        private readonly IEmailAppService _emailAppService;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(
            TenantManager tenantManager,
            UserManager userManager,
            RoleManager roleManager,
            IUnitOfWorkManager unitOfWorkManager,
            IMultiTenancyConfig multiTenancyConfig,
            ISmtpEmailSender stmpEmailSender,
            ISmtpEmailSenderConfiguration smtpEmailSenderConfiguration,
            IEmailAppService emailAppService
            )
        {
            _tenantManager = tenantManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWorkManager = unitOfWorkManager;
            _multiTenancyConfig = multiTenancyConfig;
            _smtpEmailSender = stmpEmailSender;
            _smtpEmailSenderConfiguration = smtpEmailSenderConfiguration;
            _emailAppService = emailAppService;
        }

        #region Login / Logout

        public ActionResult Login(string returnUrl = "")
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }

            return View(
                new LoginFormViewModel
                {
                    ReturnUrl = returnUrl,
                    IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled
                });
        }

        [HttpPost]
        [DisableAuditing]
        [DisableValidation]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        {
            try
            {
                CheckModelState();

                var loginResult = await GetLoginResultAsync(
                    loginModel.UsernameOrEmailAddress,
                    loginModel.Password,
                    loginModel.TenancyName
                    );

                await SignInAsync(loginResult.User, loginResult.Identity, loginModel.RememberMe);

                if (string.IsNullOrWhiteSpace(returnUrl))
                {
                    returnUrl = Request.ApplicationPath;
                }

                if (!string.IsNullOrWhiteSpace(returnUrlHash))
                {
                    returnUrl = returnUrl + returnUrlHash;
                }

                return Json(new AjaxResponse { TargetUrl = returnUrl });
            }
            catch (UserFriendlyException ex)
            {
                var error = new ErrorInfo(ex.Message);
                return Json(new AjaxResponse { Success = false, Error = error });
            }
        }

        private async Task<AbpUserManager<Tenant, Role, User>.AbpLoginResult> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _userManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        private async Task SignInAsync(User user, ClaimsIdentity identity = null, bool rememberMe = false)
        {
            if (identity == null)
            {
                identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = rememberMe }, identity);
        }

        private Exception CreateExceptionForFailedLoginAttempt(AbpLoginResultType result, string usernameOrEmailAddress, string tenancyName)
        {
            switch (result)
            {
                case AbpLoginResultType.Success:
                    return new ApplicationException("Don't call this method with a success result!");
                case AbpLoginResultType.InvalidUserNameOrEmailAddress:
                case AbpLoginResultType.InvalidPassword:
                    return new UserFriendlyException(L("LoginFailed"), L("InvalidUserNameOrPassword"));
                case AbpLoginResultType.InvalidTenancyName:
                    return new UserFriendlyException(L("LoginFailed"), L("ThereIsNoTenantDefinedWithName{0}", tenancyName));
                case AbpLoginResultType.TenantIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("TenantIsNotActive", tenancyName));
                case AbpLoginResultType.UserIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress));
                case AbpLoginResultType.UserEmailIsNotConfirmed:
                    return new UserFriendlyException(L("LoginFailed"), "Your email address is not confirmed. You can not login"); //TODO: localize message
                default: //Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(L("LoginFailed"));
            }
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        #endregion

        #region Register

        public ActionResult Register()
        {
            return RegisterView(new RegisterViewModel());
        }

        private ActionResult RegisterView(RegisterViewModel model)
        {
            ViewBag.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;

            return View("Register", model);
        }

        [HttpPost]
        [UnitOfWork]
        [DisableValidation]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Register(RegisterViewModel model)
        {
            try
            {
                CheckModelState();

                //Get tenancy name and tenant
                if (!_multiTenancyConfig.IsEnabled)
                {
                    model.TenancyName = Tenant.DefaultTenantName;
                }
                else if (model.TenancyName.IsNullOrEmpty())
                {
                    throw new UserFriendlyException(L("TenantNameCanNotBeEmpty"));
                }

                var tenant = await GetActiveTenantAsync(model.TenancyName);

                //Create user
                var user = new User
                {
                    TenantId = tenant.Id,
                    Name = model.FirstName,
                    Surname = model.Surname,
                    EmailAddress = model.EmailAddress.ToLower().Trim(),
                    IsActive = true,
                    IsEmailConfirmed = false
                };

                //Get external login info if possible
                ExternalLoginInfo externalLoginInfo = null;
                if (model.IsExternalLogin)
                {
                    externalLoginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
                    if (externalLoginInfo == null)
                    {
                        throw new ApplicationException("Can not external login!");
                    }

                    user.Logins = new List<UserLogin>
                    {
                        new UserLogin
                        {
                            LoginProvider = externalLoginInfo.Login.LoginProvider,
                            ProviderKey = externalLoginInfo.Login.ProviderKey
                        }
                    };

                    if (model.UserName.IsNullOrEmpty())
                    {
                        model.UserName = model.EmailAddress;
                    }

                    model.Password = Users.User.CreateRandomPassword();

                    if (string.Equals(externalLoginInfo.Email, model.EmailAddress, StringComparison.InvariantCultureIgnoreCase))
                    {
                        user.IsEmailConfirmed = true;
                    }
                }
                else
                {
                    //Username and Password are required if not external login
                    if (model.UserName.IsNullOrEmpty() || model.Password.IsNullOrEmpty())
                    {
                        throw new UserFriendlyException(L("FormIsNotValidMessage"));
                    }
                }

                user.UserName = model.UserName;
                user.Password = new PasswordHasher().HashPassword(model.Password);

                //Switch to the tenant
                _unitOfWorkManager.Current.EnableFilter(AbpDataFilters.MayHaveTenant);
                _unitOfWorkManager.Current.SetFilterParameter(AbpDataFilters.MayHaveTenant, AbpDataFilters.Parameters.TenantId, tenant.Id);

                //Add default roles
                user.Roles = new List<UserRole>();
                foreach (var defaultRole in await _roleManager.Roles.Where(r => r.IsDefault).ToListAsync())
                {
                    user.Roles.Add(new UserRole { RoleId = defaultRole.Id });
                }

                //Save user
                CheckErrors(await _userManager.CreateAsync(user));
                await _unitOfWorkManager.Current.SaveChangesAsync();

                // Send confirmation email
                var code = await GenerateEmailConfirmationCodeLink(user);
                await _emailAppService.SendRegistrationConfirmationEmail(user, code);
                //await SendConfirmationEmail(user.EmailAddress, code, user.Name, user.Id);

                //Show a register result page
                return View("RegisterResult", new RegisterResultViewModel
                {
                    TenancyName = tenant.TenancyName,
                    FirstName = user.Name,
                    LastName = user.Surname,
                    UserName = user.UserName,
                    EmailAddress = user.EmailAddress,
                    IsActive = user.IsActive
                });
            }
            catch (UserFriendlyException ex)
            {
                ViewBag.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;
                ViewBag.ErrorMessage = ex.Message;

                return View("Register", model);
            }
        }

        #endregion

        #region ConfirmEmail

        [UnitOfWork]
        public virtual async Task<ActionResult> ConfirmEmail(ConfirmEmailViewModel model)
        {
            try
            {
                CheckModelState();
                model.EmailConfirmationCode = HttpUtility.UrlDecode(model.EmailConfirmationCode);

                // {"No IUserTokenProvider is registered."}
                var dataProtectionProvider = Startup.DataProtectionProvider;
                _userManager.UserTokenProvider = new DataProtectorTokenProvider<User, long>(dataProtectionProvider.Create("EmailConfirmation")) { TokenLifespan = TimeSpan.FromDays(1) };
                var result = await _userManager.ConfirmEmailAsync(model.UserId, model.EmailConfirmationCode);
                if (result.Succeeded)
                {
                    Logger.Info(string.Format("Email Confirmed for userId: {0} , Confirmation Code {1}", model.UserId, model.EmailConfirmationCode));
                    return View("ConfirmEmailResult", new ConfirmEmailResultViewModel
                    {
                        Success = true
                    });
                }
                else
                {
                    Logger.Warn(string.Format("Failed attempt to confirm email for userId: {0} with code: {1}", model.UserId, model.EmailConfirmationCode));
                    return View("ConfirmEmailResult", new ConfirmEmailResultViewModel
                    {
                        Success = false
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.Info(ex.ToString());
                return View("ConfirmEmailResult", new ConfirmEmailResultViewModel
                {
                    Success = false
                });
            }
        }
        #endregion

        #region PasswordResetEmail

        public ActionResult PasswordResetEmail()
        {
            return View("PasswordResetEmail", new PasswordResetEmailViewModel());
        }

        [HttpPost]
        [UnitOfWork]
        public virtual async Task<ActionResult> PasswordResetEmail(PasswordResetEmailViewModel model)
        {
            try
            {
                CheckModelState();

                using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
                {
                    var user = await _userManager.Users.Where(u => u.EmailAddress.Contains(model.EmailAddress)).FirstOrDefaultAsync();

                    if (user == null || !(await _userManager.IsEmailConfirmedAsync(user.Id)))
                    {
                        // Don't reveal user existence or email confirm status
                        return View("PasswordResetEmailResult");
                    }

                    //var dataProtectionProvider = Startup.DataProtectionProvider;
                    //_userManager.UserTokenProvider = new DataProtectorTokenProvider<User, long>(dataProtectionProvider.Create("PasswordResetConfirmation")) { TokenLifespan = TimeSpan.FromDays(1) };
                    //var resetCode = _userManager.GeneratePasswordResetTokenAsync(user.Id);
                    //await SendPasswordResetEmail(user.EmailAddress, HttpUtility.HtmlEncode(resetCode), user.Name, user.Id);
                    var code = await GeneratePasswordResetCodeLink(user);
                    await _emailAppService.SendPasswordResetEmail(user, code);

                    return View("PasswordResetEmailResult");
                }
            }
            catch (UserFriendlyException ex)
            {
                Logger.Warn("Reset password failed", ex);
                return View("PasswordResetEmailResult");
            }
        }

        #endregion

        #region PasswordReset

        public ActionResult PasswordReset(PasswordResetCodeViewModel input)
        {
            return View("PasswordReset", new PasswordResetViewModel() { UserId = input.UserId, PasswordResetToken = input.PasswordResetToken });

            //try
            //{
            //    var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PasswordResetCode == input.PasswordResetCode);
            //    if (user == null)
            //    {
            //        return View("PasswordReset", new PasswordResetViewModel { CodeExists = false });
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.Info("Reset password exception", ex);
            //    return View("PasswordReset", new PasswordResetViewModel { CodeExists = false });
            //}
        }


        #endregion  


        #region External Login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ChallengeResult(
                provider,
                Url.Action(
                    "ExternalLoginCallback",
                    "Account",
                    new
                    {
                        ReturnUrl = returnUrl
                    })
                );
        }

        [UnitOfWork]
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl, string tenancyName = "")
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            //Try to find tenancy name
            if (tenancyName.IsNullOrEmpty())
            {
                var tenants = await FindPossibleTenantsOfUserAsync(loginInfo.Login);
                switch (tenants.Count)
                {
                    case 0:
                        return await RegisterView(loginInfo);
                    case 1:
                        tenancyName = tenants[0].TenancyName;
                        break;
                    default:
                        return View("TenantSelection", new TenantSelectionViewModel
                        {
                            Action = Url.Action("ExternalLoginCallback", "Account", new { returnUrl }),
                            Tenants = tenants.MapTo<List<TenantSelectionViewModel.TenantInfo>>()
                        });
                }
            }

            var loginResult = await _userManager.LoginAsync(loginInfo.Login, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    await SignInAsync(loginResult.User, loginResult.Identity, false);

                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        returnUrl = Url.Action("Index", "Home");
                    }

                    return Redirect(returnUrl);
                case AbpLoginResultType.UnknownExternalLogin:
                    return await RegisterView(loginInfo, tenancyName);
                default:
                    throw CreateExceptionForFailedLoginAttempt(loginResult.Result, loginInfo.Email ?? loginInfo.DefaultUserName, tenancyName);
            }
        }

        private async Task<ActionResult> RegisterView(ExternalLoginInfo loginInfo, string tenancyName = null)
        {
            var name = loginInfo.DefaultUserName;
            var surname = loginInfo.DefaultUserName;

            var extractedNameAndSurname = TryExtractNameAndSurnameFromClaims(loginInfo.ExternalIdentity.Claims.ToList(), ref name, ref surname);

            var viewModel = new RegisterViewModel
            {
                TenancyName = tenancyName,
                EmailAddress = loginInfo.Email,
                FirstName = name,
                Surname = surname,
                IsExternalLogin = true
            };

            if (!tenancyName.IsNullOrEmpty() && extractedNameAndSurname)
            {
                return await Register(viewModel);
            }

            return RegisterView(viewModel);
        }

        [UnitOfWork]
        protected virtual async Task<List<Tenant>> FindPossibleTenantsOfUserAsync(UserLoginInfo login)
        {
            List<User> allUsers;
            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                allUsers = await _userManager.FindAllAsync(login);
            }

            return allUsers
                .Where(u => u.TenantId != null)
                .Select(u => AsyncHelper.RunSync(() => _tenantManager.FindByIdAsync(u.TenantId.Value)))
                .ToList();
        }

        private static bool TryExtractNameAndSurnameFromClaims(List<Claim> claims, ref string name, ref string surname)
        {
            string foundName = null;
            string foundSurname = null;

            var givennameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName);
            if (givennameClaim != null && !givennameClaim.Value.IsNullOrEmpty())
            {
                foundName = givennameClaim.Value;
            }

            var surnameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname);
            if (surnameClaim != null && !surnameClaim.Value.IsNullOrEmpty())
            {
                foundSurname = surnameClaim.Value;
            }

            if (foundName == null || foundSurname == null)
            {
                var nameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                if (nameClaim != null)
                {
                    var nameSurName = nameClaim.Value;
                    if (!nameSurName.IsNullOrEmpty())
                    {
                        var lastSpaceIndex = nameSurName.LastIndexOf(' ');
                        if (lastSpaceIndex < 1 || lastSpaceIndex > (nameSurName.Length - 2))
                        {
                            foundName = foundSurname = nameSurName;
                        }
                        else
                        {
                            foundName = nameSurName.Substring(0, lastSpaceIndex);
                            foundSurname = nameSurName.Substring(lastSpaceIndex);
                        }
                    }
                }
            }

            if (!foundName.IsNullOrEmpty())
            {
                name = foundName;
            }

            if (!foundSurname.IsNullOrEmpty())
            {
                surname = foundSurname;
            }

            return foundName != null && foundSurname != null;
        }

        #endregion

        #region Common private methods

        private async Task<Tenant> GetActiveTenantAsync(string tenancyName)
        {
            var tenant = await _tenantManager.FindByTenancyNameAsync(tenancyName);
            if (tenant == null)
            {
                throw new UserFriendlyException(L("ThereIsNoTenantDefinedWithName{0}", tenancyName));
            }

            if (!tenant.IsActive)
            {
                throw new UserFriendlyException(L("TenantIsNotActive", tenancyName));
            }

            return tenant;
        }



        #endregion

        #region Email Methods

        private async Task<string> GenerateEmailConfirmationCodeLink(User user)
        {
            var dataProtectionProvider = Startup.DataProtectionProvider;
            _userManager.UserTokenProvider = new DataProtectorTokenProvider<User, long>(dataProtectionProvider.Create("EmailConfirmation")) { TokenLifespan = TimeSpan.FromDays(1) };
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id);
            code = HttpUtility.UrlEncode(code);
            var confirmURL = Url.Action("ConfirmEmail", "Account", new ConfirmEmailViewModel { EmailConfirmationCode = code, UserId = user.Id }, protocol: Request.Url.Scheme);
            return confirmURL;
        }

        private async Task<string> GeneratePasswordResetCodeLink(User user)
        {
            var dataProtectionProvider = Startup.DataProtectionProvider;
            _userManager.UserTokenProvider = new DataProtectorTokenProvider<User, long>(dataProtectionProvider.Create("PasswordResetConfirmation")) { TokenLifespan = TimeSpan.FromDays(1) };
            var code = await _userManager.GeneratePasswordResetTokenAsync(user.Id);
            code = HttpUtility.UrlEncode(code);
            var confirmURL = Url.Action("PasswordReset", "Account", new PasswordResetCodeViewModel { UserId = user.Id, PasswordResetToken = code }, Request.Url.Scheme);
            return confirmURL;

        }

        //private async Task SendConfirmationEmail(string clientEmail, string code, string clientName, long clientId)
        //{
        //    var confirmURL = Url.Action("ConfirmEmail", "Account", new ConfirmEmailViewModel { EmailConfirmationCode = code, UserId = clientId }, protocol: Request.Url.Scheme);

        //    MailDefinition mailDef = new MailDefinition();
        //    mailDef.From = "dogedaycaredev@gmail.com";
        //    mailDef.Subject = "Welcome to DogeDaycare!";
        //    mailDef.IsBodyHtml = true;

        //    ListDictionary replacements = new ListDictionary();
        //    replacements.Add("{EmailTitle}", mailDef.Subject);
        //    replacements.Add("{CustomerName}", clientName);
        //    replacements.Add("{ConfirmationLink}", confirmURL);
        //    replacements.Add("{ContactUsEmail}", mailDef.From);

        //    var body = System.IO.File.ReadAllText(Server.MapPath("~/Controllers/EmailTemplates/Inline/EmailConfirmationTemplateInline.html"));

        //    MailMessage message = mailDef.CreateMailMessage(clientEmail, replacements, body, new System.Web.UI.Control());

        //    using (var client = _smtpEmailSender.BuildClient())
        //    {
        //        await client.SendMailAsync(message);
        //    }

        //    Logger.Info(string.Format("Sent confirmation code {0} to email {1}", code, clientEmail));
        //}

        //private async Task SendPasswordResetEmail(string clientEmail, string code, string clientName, long id)
        //{
        //    var confirmURL = Url.Action("PasswordReset", "Account", new PasswordResetCodeViewModel { UserId = id, PasswordResetToken = code }, Request.Url.Scheme);

        //    MailDefinition mailDef = new MailDefinition();
        //    mailDef.From = "dogedaycaredev@gmail.com";
        //    mailDef.Subject = "Reset your DogeDaycare password";
        //    mailDef.IsBodyHtml = true;

        //    ListDictionary replacements = new ListDictionary();
        //    replacements.Add("{EmailTitle}", mailDef.Subject);
        //    replacements.Add("{CustomerName}", clientName);
        //    replacements.Add("{ConfirmationLink}", confirmURL);
        //    replacements.Add("{ContactUsEmail}", mailDef.From);

        //    var body = System.IO.File.ReadAllText(Server.MapPath("~/Controllers/EmailTemplates/Inline/PasswordResetTemplateInline.html"));

        //    MailMessage message = mailDef.CreateMailMessage(clientEmail, replacements, body, new System.Web.UI.Control());

        //    using (var client = _smtpEmailSender.BuildClient())
        //    {
        //        await client.SendMailAsync(message);
        //    }

        //    Logger.Info(string.Format("Sent password reset code {0} to email {1}", code, clientEmail));
        //}

        #endregion

    }
}