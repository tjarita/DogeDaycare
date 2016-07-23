using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogeDaycare.Web.Models.Account
{
    public class PasswordResetEmailViewModel : IInputDto
    {
        private string _emailAddress;

        [Required]
        [EmailAddress]
        [StringLength(Users.User.MaxEmailAddressLength)]
        public string EmailAddress
        {
            get { return _emailAddress; }

            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    _emailAddress = value.ToLower().Trim();
                }
            }
        }
    }
}