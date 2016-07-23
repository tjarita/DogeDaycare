using DogeDaycare.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogeDaycare.Web.Models.Account
{
    public class PasswordResetCodeViewModel
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        [StringLength(User.MaxPasswordResetCodeLength)]
        public string PasswordResetToken { get; set; }
    }
}