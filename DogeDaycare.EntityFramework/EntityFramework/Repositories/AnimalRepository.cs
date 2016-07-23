using System;
using System.Collections.Generic;
using DogeDaycare.Animals;
using Abp.EntityFramework;
using System.Linq;
using System.Data.Entity;

namespace DogeDaycare.EntityFramework.Repositories
{
    public class AnimalRepository : DogeDaycareRepositoryBase<Animal, long>
    {

        public AnimalRepository(IDbContextProvider<DogeDaycareDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        /// <summary>
        /// Gets all pets that belong to a certain owner or all registered animals if owner is null.
        /// </summary>
        /// <param name="owner">nullable Guid of Owner</param>
        /// <returns>All pets for one owner or all animals</returns>
        //public List<Animal> GetAllPetsPerOwner(Guid? owner)
        //{
        //    var query = GetAll();

        //    if (owner.HasValue)
        //        query = query.Where(animal => animal.Owner.Id == owner);

        //    return query
        //        .OrderByDescending(animal => animal.RegisteredTime)
        //        .ToList();
        //}

        public List<Animal> GetAllAnimals()
        {
            var query = this.Context.Animals.Include(animals => animals.Owner);

            return query.ToList();
        }


    }
}
