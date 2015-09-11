﻿using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons
{
    public interface IPersonRepository : IRepository<Person,Guid>
    {
        List<Person> GetAllPeople();
    }
}