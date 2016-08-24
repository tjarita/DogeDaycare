using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace DogeDaycare.Web.Models.Account
{
    public class ConfirmEmailViewModel
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        [StringLength(Users.User.MaxEmailConfirmationCodeLength)]
        public string EmailConfirmationCode { get; set; }
    }
}