using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals.Dtos
{
    public class GetAnimalsInput
    {
        [Required]
        public Guid IdOwner { get; set; }
    }
}
