using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals
{
    public interface IAnimalManager : IDomainService
    {
        Task<Animal> GetAsync(long id);

        Task CreateAsync(Animal @animal);

        void Deactivate(Animal @animal);
    }
}
