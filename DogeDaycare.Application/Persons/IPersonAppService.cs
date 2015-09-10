using Abp.Application.Services;
using DogeDaycare.Persons.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons
{
    public interface IPersonAppService : IApplicationService
    {

        void CreatePerson(CreatePersonInput input);


    }
}
