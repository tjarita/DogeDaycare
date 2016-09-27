using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Emails
{
    public class EmailTemplateManager : IEmailTemplateManager
    {
        private readonly IRepository<EmailTemplate> _emailTemplateRepository;

        public EmailTemplateManager(
            IRepository<EmailTemplate> emailTemplateRepository
            )
        {
            _emailTemplateRepository = emailTemplateRepository;
        }

        public async Task CreateAsync(EmailTemplate @emailTemplate)
        {
            await _emailTemplateRepository.InsertAsync(@emailTemplate);
        }

        public async Task<EmailTemplate> GetAsync(int pk)
        {
            var template = await _emailTemplateRepository.GetAsync(pk);
            if(template == null)
            {
                throw new UserFriendlyException("This email template was not found!");
            }
            return template;
        }

    }
}
