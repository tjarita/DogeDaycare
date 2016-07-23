using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DogeDaycare.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals.Dtos
{
    [AutoMapFrom(typeof(Animal))]
    public class AnimalDetailOutput : EntityDto<Guid>, IOutputDto
    {
        public int TenantId { get; set; }

        public string Name { get; set; }

        public User Owner { get; set; }

        public float Age { get; set; }

        public bool IsActive { get; set; }
    }
}
