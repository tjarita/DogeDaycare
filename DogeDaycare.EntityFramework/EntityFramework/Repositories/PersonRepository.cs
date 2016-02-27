using Abp.EntityFramework;
using DogeDaycare.Persons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DogeDaycare.EntityFramework.Repositories
{
    public class PersonRepository : DogeDaycareRepositoryBase<Person, Guid>, IPersonRepository
    {

        public PersonRepository(IDbContextProvider<DogeDaycareDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public List<Person> GetAllPeople()
        {
            return GetAll().OrderByDescending(person => person.LName).ToList();
        }

        
    }
}
