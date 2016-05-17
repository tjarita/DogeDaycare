using DogeDaycare.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogeDaycare.Web.Models.Account
{
    public class ResetPasswordCodeViewModel
    {
        [Required]
        [StringLength(User.MaxPasswordResetCodeLength)]
        public string PasswordResetCode { get; set; }
    }
}