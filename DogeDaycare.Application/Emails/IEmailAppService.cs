using Abp.Application.Services;
using DogeDaycare.Users;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Emails
{
    public interface IEmailAppService : IApplicationService
    {
        Task SendRegistrationConfirmationEmail(User user, string confirmationCode);
        Task<bool> SendPasswordResetEmail(string email, string confirmationCode);
        
    }
}
