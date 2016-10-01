using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Emails
{
    public interface IEmailTemplateManager : IDomainService
    {
        Task CreateAsync(EmailTemplate emailTemplate);
        Task<EmailTemplate> GetAsync(int pk);
    }
}
