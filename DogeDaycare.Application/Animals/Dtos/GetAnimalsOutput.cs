using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals.Dtos
{
    public class GetAnimalsOutput : IOutputDto
    {
        public List<AnimalDto> Animals { get; set; }
    }
}
