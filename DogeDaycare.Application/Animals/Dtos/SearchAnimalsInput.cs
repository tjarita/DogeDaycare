using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals.Dtos
{
    public class SearchAnimalsInput : IInputDto
    {
        public string NameAnimal { get; set; }
        public string NameOwner { get; set; }
    }
}
