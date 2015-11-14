using Abp.Application.Services;
using AutoMapper;
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
        private readonly IAnimalRepository _animalRepository;
        private readonly IPersonRepository _personRepository;

        public PersonAppService(IAnimalRepository animalRepository, IPersonRepository personRepository)
        {
            _animalRepository = animalRepository;
            _personRepository = personRepository;
        }

        public GetPersonsOutput GetAllPersons()
        {
            var persons = _personRepository.GetAll().ToList();

            return new GetPersonsOutput
            {
                Persons = Mapper.Map<List<PersonDto>>(persons)
            };
        }

        public void CreatePerson(CreatePersonInput input)
        {
            Logger.Info("Registering a person : " + input.FName + "  " + input.LName);

            Person person = new Person()
            {
                FName = input.FName,
                NickName = input.NickName,
                LName = input.LName,
                Email = input.Email,
                Phone = input.Phone
            };

            _personRepository.Insert(person);
        }
    }
}
