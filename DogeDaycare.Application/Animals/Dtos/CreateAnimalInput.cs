using Abp.Application.Services.Dto;
using DogeDaycare.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals.Dtos
{
    public class CreateAnimalInput : IInputDto
    {
        [Required]
        public User Owner { get; set; }

        [Required]
        [StringLength(Animal.MaxNameLength)]
        public string Name { get; set; }

        [Range(0,100)]
        public float Age { get; set; }
    }
}
