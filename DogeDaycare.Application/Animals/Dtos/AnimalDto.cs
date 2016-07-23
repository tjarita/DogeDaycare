using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DogeDaycare.Users;
using System;

namespace DogeDaycare.Animals.Dtos
{
    [AutoMapFrom(typeof(Animal))]
    public class AnimalDto : EntityDto<Guid>
    {
        public User Owner { get; set; }
        public string Name { get; set; }
    }
}
