//using Abp.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace DogeDaycare.EntityFramework.Repositories
//{
//    public class PersonRepository : DogeDaycareRepositoryBase<Person, Guid>
//    {

//        public PersonRepository(IDbContextProvider<DogeDaycareDbContext> dbContextProvider) 
//            : base(dbContextProvider)
//        {
//        }

//        public List<Person> GetAllPeople()
//        {
//            return GetAll().OrderByDescending(person => person.LName).ToList();
//        }

        
//    }
//}
