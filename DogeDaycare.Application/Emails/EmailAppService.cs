using Abp.Net.Mail.Smtp;
using DogeDaycare.Configuration;
using DogeDaycare.Users;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace DogeDaycare.Emails
{
    public class EmailAppService : DogeDaycareAppServiceBase, IEmailAppService
    {
        private readonly SmtpClient _smtpClient;
        private readonly ISmtpEmailSenderConfiguration _smtpEmailSenderConfiguration;
        private readonly IEmailTemplateManager _emailTemplateManager;
        private readonly IWebConfigConfigurationManager _webConfigConfigurationManager;
        private const string GMAIL_API_SECRET_FILE_KEY = "GmailAPISecretKeyFileLocation";
        private const string GMAIL_PASSWORD_KEY = "DogeDaycareGmailPassword";

        public EmailAppService(
            IWebConfigConfigurationManager webConfigConfigurationManager,
            IEmailTemplateManager emailTemplateManager,
            ISmtpEmailSenderConfiguration smtpEmailSenderConfiguration
            )
        {
            _webConfigConfigurationManager = webConfigConfigurationManager;
            _emailTemplateManager = emailTemplateManager;
            _smtpEmailSenderConfiguration = smtpEmailSenderConfiguration;
            _smtpClient = BuildSmtpClient();
        }

        /// <summary>
        /// Builds an SMTP client based on settings from the database. Reads password from an external file for security.
        /// </summary>
        /// <returns>An SmtpClient</returns>
        private SmtpClient BuildSmtpClient()
        {
            var password = _webConfigConfigurationManager.GetAppSetting(GMAIL_PASSWORD_KEY);

            var client = new SmtpClient(_smtpEmailSenderConfiguration.Host, _smtpEmailSenderConfiguration.Port)
            {
                UseDefaultCredentials = _smtpEmailSenderConfiguration.UseDefaultCredentials,
                Credentials = new NetworkCredential(_smtpEmailSenderConfiguration.UserName, password),
                EnableSsl = _smtpEmailSenderConfiguration.EnableSsl
            };
            return client;
        }

        /// <summary>
        /// Sent after a user registers for an account to confirm they own the email.
        /// </summary>
        /// <param name="email">Recipient</param>
        /// <param name="confirmationCode">Confirmation code</param>
        /// <param name="name">Their name</param>
        /// <returns></returns>
        public async Task SendRegistrationConfirmationEmail(User user, string confirmationCode)
        {
            try
            {
                const int CONFIRMATION_EMAIL_PK = 2;
                const string CUSTOMER_NAME_KEY = "(%~CustomerName~%)";
                const string CONFIRMATION_LINK_KEY = "(%~ConfirmationLink~%)";

                // Get the template..
                var template = await _emailTemplateManager.GetAsync(CONFIRMATION_EMAIL_PK);

                // Move CSS inline
                var inline = PreMailer.Net.PreMailer.MoveCssInline(template.BodyHTML);

                // Log any errors from moving CSS inline
                foreach(var error in inline.Warnings)
                {
                    Logger.Error(error);
                }

                //Perform replacements.
                var final = inline.Html;
                final = final.Replace(CUSTOMER_NAME_KEY, user.FullName);
                final = final.Replace(CONFIRMATION_LINK_KEY, confirmationCode);

                //Create the actual email
                var mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(user.EmailAddress));
                mail.From = new MailAddress(_smtpEmailSenderConfiguration.DefaultFromAddress, _smtpEmailSenderConfiguration.DefaultFromDisplayName);
                mail.Subject = template.Subject;
                mail.Body = final;

                //Send!
                await _smtpClient.SendMailAsync(mail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Sent when a user requests a password change.
        /// </summary>
        /// <param name="email">Email to send to</param>
        /// <param name="confirmationCode">Confirmation code</param>
        /// <returns></returns>
        public async Task<bool> SendPasswordResetEmail(string email, string confirmationCode)
        {
            throw new NotImplementedException();

        }
    }
}
