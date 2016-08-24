using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using DogeDaycare.Users;

namespace DogeDaycare.MultiTenancy.Dto
{
    public class CreateTenantInput
    {
        [Required]
        [StringLength(Tenant.MaxTenancyNameLength)]
        [RegularExpression(Tenant.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(Tenant.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(User.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }
    }
}