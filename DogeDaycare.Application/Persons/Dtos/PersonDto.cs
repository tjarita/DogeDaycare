using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons.Dtos
{
    [AutoMapFrom(typeof(Person))]
    public class PersonDto : EntityDto<Guid>
    {
        public Guid IdPerson { get; set; }
        public string Name { get; set; }
        //public List<Animals.Animal> Pets { get; set; }

    }
}
