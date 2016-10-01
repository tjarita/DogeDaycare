using Abp.Net.Mail;
using DogeDaycare.Emails;
using DogeDaycare.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Migrations.SeedData
{
    class DefaultEmailTemplatesBuilder
    {
        private readonly DogeDaycareDbContext _context;

        public DefaultEmailTemplatesBuilder(DogeDaycareDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateEmailConfirmationTemplate();
            if (!_context.Settings.Any(s => s.Name.Contains(EmailSettingNames.Smtp.Host)))
            {
                CreateSmtpSettings();
            }
        }

        private void CreateEmailConfirmationTemplate()
        {
            var sender = "dogedaycaredev@gmail.com";
            var subject = "Welcome to DogeDaycare!";
            var body = File.ReadAllText(@"Y:\Repo\DogeDaycare\DogeDaycare.EntityFramework\Migrations\SeedData\EmailConfirmationTemplate.html");

            var template = EmailTemplate.Create(
                sender, subject, body
                );

            template.AddEmailBodyReplacement("{CustomerName}", "Name of the customer.");
            template.AddEmailBodyReplacement("{ConfirmationLink}", "Confirmation code.");

            if (!_context.EmailTemplates.Any(e => e.Subject.Contains("Welcome to DogeDaycare!")))
            {
                _context.EmailTemplates.Add(template);
                _context.SaveChanges();
            }
        }

        private void CreateSmtpSettings()
        {
            // Seed
            _context.Settings.Add(new Abp.Configuration.Setting
            {
                Name = EmailSettingNames.Smtp.Host,
                Value = "smtp.gmail.com"
            });

            _context.Settings.Add(new Abp.Configuration.Setting
            {
                Name = EmailSettingNames.Smtp.Port,
                Value = "587"
            });

            _context.Settings.Add(new Abp.Configuration.Setting
            {
                Name = EmailSettingNames.Smtp.UserName,
                Value = "DogeDaycareDev@gmail.com"
            });

            _context.Settings.Add(new Abp.Configuration.Setting
            {
                Name = EmailSettingNames.DefaultFromAddress,
                Value = "DogeDaycareDev@gmail.com"
            });

            _context.Settings.Add(new Abp.Configuration.Setting
            {
                Name = EmailSettingNames.DefaultFromDisplayName,
                Value = "DogeDaycare"
            });

            _context.Settings.Add(new Abp.Configuration.Setting
            {
                Name = EmailSettingNames.Smtp.EnableSsl,
                Value = "true"
            });

            _context.Settings.Add(new Abp.Configuration.Setting
            {
                Name = EmailSettingNames.Smtp.UseDefaultCredentials,
                Value = "false"
            });
        }

        private void CreatePasswordResetTemplate()
        {
            throw new NotImplementedException();
        }
    }
}
