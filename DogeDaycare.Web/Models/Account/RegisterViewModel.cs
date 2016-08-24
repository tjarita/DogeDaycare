using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using DogeDaycare.MultiTenancy;
using DogeDaycare.Users;

namespace DogeDaycare.Web.Models.Account
{
    public class RegisterViewModel
    {
        /// <summary>
        /// Not required for single-tenant applications.
        /// </summary>
        [StringLength(Tenant.MaxTenancyNameLength)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(User.MaxNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(User.MaxSurnameLength)]
        public string Surname { get; set; }

        [StringLength(User.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(User.MaxPlainPasswordLength)]
        public string Password { get; set; }

        [StringLength(User.MaxPlainPasswordLength)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Try again.")]
        public string PasswordConfirm { get; set; }

        public bool IsExternalLogin { get; set; }
    }
}