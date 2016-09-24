using Abp.Application.Services;
using Google.Apis.Gmail.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Emails
{
    public interface IEmailAppService : IApplicationService
    {
        Task<bool> SendEmailAddressConfirmationEmail(string email, string confirmationCode, string name);
        Task<bool> SendPasswordResetEmail(string email, string confirmationCode);
        
    }
}
