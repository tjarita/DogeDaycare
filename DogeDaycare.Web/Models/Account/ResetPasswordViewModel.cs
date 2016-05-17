using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogeDaycare.Web.Models.Account
{
    public class ResetPasswordViewModel : IInputDto
    {
        public bool CodeExists { get; set; }

        [Required]
        public long UserId { get; set; }

        public string Password { get; set; }
        
        public string ConfirmationPassword { get; set; }
    }
}