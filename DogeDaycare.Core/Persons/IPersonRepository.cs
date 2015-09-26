using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons
{
    /// <summary>
    /// Repository holding persons. Used for custom queries that IReposity doesn't cover.
    /// </summary>
    public interface IPersonRepository : IRepository<Person,Guid>
    {
        List<Person> GetAllPeople();
    }
}
