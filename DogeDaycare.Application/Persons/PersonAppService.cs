using Abp.Application.Services;
using DogeDaycare.Animals;
using DogeDaycare.Persons.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons
{
    public class PersonAppService : ApplicationService, IPersonAppService
    {
        private IAnimalRepository _animalRepository;
        private IPersonRepository _personRepository;

        public PersonAppService(IAnimalRepository animalRepository, IPersonRepository personRepository)
        {
            _animalRepository = animalRepository;
            _personRepository = personRepository;
        }

        public void CreatePerson(CreatePersonInput input)
        {
            Logger.Info("Registering a person named" + input.Name);

            Person person = new Person() { Name = input.Name };

            _personRepository.Insert(person);
            //_personRepository.InsertPerson(person);
        }

    }
}
