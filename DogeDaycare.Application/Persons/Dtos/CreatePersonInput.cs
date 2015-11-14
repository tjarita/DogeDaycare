using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace DogeDaycare.Persons.Dtos
{
    /// <summary>
    /// Input validation for creating a person.
    /// </summary>
    public class CreatePersonInput : IInputDto
    {
        [Required]
        public string FName { get; set; }
        public string NickName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

    }
}
