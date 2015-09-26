using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons.Dtos
{
    /// <summary>
    /// Input validation for creating a person.
    /// </summary>
    public class CreatePersonInput : IInputDto
    {
        [Required]
        public string Name { get; set; }
    }
}
