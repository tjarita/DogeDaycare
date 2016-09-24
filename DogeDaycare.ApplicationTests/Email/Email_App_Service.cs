using DogeDaycare.Configuration;
using DogeDaycare.Emails;
using Google.Apis.Gmail.v1;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace DogeDaycare.ApplicationTests.Email
{
    public class Email_App_Service
    {
        private Mock<IWebConfigConfigurationManager> _webConfigConfigurationManager;
        
        [SetUp]
        public void SetUp() {
            _webConfigConfigurationManager = new Mock<IWebConfigConfigurationManager>();
        }

        [Test]
        public void Can_Create_Email_Service()
        {
            string secretFileLocation = "GmailAPISecretKeyFileLocation";

            _webConfigConfigurationManager.Setup(cm => cm.GetAppSetting(secretFileLocation)).Returns(@"C:\inetpub\wwwroot\DogeDaycare-89f11a719dbf-dev.json");

            var email = new EmailAppService(_webConfigConfigurationManager.Object);
            Assert.IsNotNull(email);
        }

    }
}
