using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Zero.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogeDaycare.Web.App_Start
{
    public class DogeDaycareWebSettingProvider : SettingProvider
    {

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(
                    AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin,
                    "true"),


                // Email SMTP Settings
                new SettingDefinition(
                    EmailSettingNames.Smtp.Host,
                    "smtp.gmail.com"
                    ),

                new SettingDefinition(
                    EmailSettingNames.Smtp.Port,
                    "587"
                    ),
                new SettingDefinition(
                    EmailSettingNames.Smtp.UserName,
                    "dogedaycaredev@gmail.com"
                    ),
                new SettingDefinition(
                    EmailSettingNames.Smtp.Password,
                    "developeratdogedaycare"
                    ),
                new SettingDefinition(
                    EmailSettingNames.Smtp.EnableSsl,
                    "true"
                    ),
                new SettingDefinition(
                    EmailSettingNames.Smtp.UseDefaultCredentials,
                    "false"
                    ),
                new SettingDefinition(
                    EmailSettingNames.DefaultFromAddress,
                    "dogedaycaredev@gmail.com"
                    ),
                new SettingDefinition(
                    EmailSettingNames.DefaultFromDisplayName,
                    "Admin"
                    ),


            };

        }
    }
}