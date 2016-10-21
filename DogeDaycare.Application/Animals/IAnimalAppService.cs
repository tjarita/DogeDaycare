using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DogeDaycare.Animals.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals
{
    public interface IAnimalAppService : IApplicationService
    {
        Task Create(CreateAnimalInput input);
        //Task Deactivate(EntityRequestInput<long> input);
        //Task<AnimalDetailOutput> GetDetail(EntityRequestInput<long> input);
    }
}
