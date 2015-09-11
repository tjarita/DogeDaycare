using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons.Dtos
{
    public class GetPersonsOutput : IOutputDto
    {
        public List<PersonDto> Persons { get; set; }
    }
}
