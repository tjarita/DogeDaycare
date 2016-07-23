using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals
{
    public class AnimalManager : IAnimalManager
    {
        private readonly IRepository<Animal, long> _animalRepository;

        public AnimalManager(IRepository<Animal,long> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task CreateAsync(Animal @animal)
        {
            await _animalRepository.InsertAsync(@animal);
        }

        public async Task<Animal> GetAsync(long id)
        {
            var @animal = await _animalRepository.FirstOrDefaultAsync(id);
            if(@animal == null)
            {
                throw new UserFriendlyException("Couldn't find that animal");
            }
            return @animal;
        }

        public void Deactivate(Animal @animal)
        {
            @animal.Deactivate();
            // Animal decativated event
        }

    }
}
