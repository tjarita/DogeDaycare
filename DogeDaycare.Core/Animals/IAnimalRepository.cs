using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DogeDaycare.Animals
{
    public interface IAnimalRepository : IRepository<Animal, Guid>
    {
        //List<Animal> GetAllPetsPerOwner(Guid? IdOwner);
        List<Animal> GetAllAnimals();
    }
}
