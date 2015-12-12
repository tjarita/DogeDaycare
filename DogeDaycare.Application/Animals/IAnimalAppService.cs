using Abp.Application.Services;
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
        GetAnimalsOutput GetAnimals(GetAnimalsInput input);
        GetAnimalsOutput GetAllAnimals();
        void CreateAnimal(CreateAnimalInput input);
        void UpdateAnimal();
    }
}
