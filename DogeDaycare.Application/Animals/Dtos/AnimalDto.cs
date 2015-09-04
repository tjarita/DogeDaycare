using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals.Dtos
{
    public class AnimalDto : EntityDto<Guid>
    {
        public Guid IdAnimal { get; set; }
        public Guid? IdOwner { get; set; }
        public string AnimalName { get; set; }
        public string OwnerName { get; set; }
        public DateTime RegisteredTime { get; set; }
    }
}
