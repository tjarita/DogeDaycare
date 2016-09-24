using DogeDaycare.Configuration;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Hosting;

namespace DogeDaycare.Emails
{
    public class EmailAppService : DogeDaycareAppServiceBase, IEmailAppService
    {
        private readonly GmailService _gmailService;
        private readonly IWebConfigConfigurationManager _webConfigConfigurationManager;


        public EmailAppService(IWebConfigConfigurationManager webConfigConfigurationManager)
        {
            _webConfigConfigurationManager = webConfigConfigurationManager;


            _gmailService = CreateGmailServiceAsync();
        }

        private GmailService CreateGmailServiceAsync()
        {
            string path = _webConfigConfigurationManager.GetAppSetting("GmailAPISecretKeyFileLocation");
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    GoogleCredential credential;

                    string[] gmailScopes = new string[]
                    {
                        GmailService.Scope.GmailCompose
                    };

                    credential = GoogleCredential
                        .FromStream(stream)
                        .CreateScoped(gmailScopes);

                    var service = new GmailService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "DogeDaycare"
                    });

                    return service;
                }
                catch (Exception e)
                {
                    Logger.FatalFormat("Email App Service wasn't successfully started!!! Exception info: {0}", e.ToString());
                    throw e;
                }
            }
        }
        public async Task<bool> SendEmailAddressConfirmationEmail(string email, string confirmationCode, string name)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> SendPasswordResetEmail(string email, string confirmationCode)
        {
            throw new NotImplementedException();

        }
    }
}
