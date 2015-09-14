using System;
using System.Collections.Generic;
using DogeDaycare.Animals;
using Abp.EntityFramework;
using System.Linq;

namespace DogeDaycare.EntityFramework.Repositories
{
    public class AnimalRepository : DogeDaycareRepositoryBase<Animal, Guid>, IAnimalRepository
    {

        public AnimalRepository(IDbContextProvider<DogeDaycareDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public List<Animal> GetAllPetsPerOwner(Guid? owner)
        {
            var query = GetAll();

            if(owner.HasValue)
                query.Where(animal => animal.Owner.Id == owner);
            
            return query
                .OrderByDescending(animal => animal.RegisteredTime)
                .ToList();
        }
    }
}
