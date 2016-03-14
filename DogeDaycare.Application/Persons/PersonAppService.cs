using Abp.Application.Services;
using Abp.Authorization;
using AutoMapper;
using DogeDaycare.Animals;
using DogeDaycare.Persons.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DogeDaycare.Persons
{
    public class PersonAppService : ApplicationService, IPersonAppService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPermissionManager _permissionManager;

        public PersonAppService(IAnimalRepository animalRepository, IPersonRepository personRepository, IPermissionManager permissionManager)
        {
            _animalRepository = animalRepository;
            _personRepository = personRepository;
            _permissionManager = permissionManager;
        }

        public GetPersonsOutput GetAllPersons()
        {
            var persons = _personRepository.GetAll().ToList();

            return new GetPersonsOutput
            {
                Persons = Mapper.Map<List<PersonDto>>(persons)
            };
        }

        public GetPersonsOutput SearchForPerson(SearchPersonDto input)
        {
            Logger.Info("Searching for person with properties : " + input.FName + ", " + input.LName);
            Regex firstName = new Regex(input.FName, RegexOptions.IgnoreCase);
            Regex lastName = new Regex(input.LName, RegexOptions.IgnoreCase);


            var persons = _personRepository
                .GetAll()
                .Select(person => new { person.Id, person.FName, person.LName })
                .AsEnumerable();

            var resultIDs = persons
                .Where(person =>    firstName.IsMatch(person.FName) && 
                                    lastName.IsMatch(person.LName))
                .Select(person => person.Id)
                .ToList();

            var results = _personRepository
                .GetAll()
                .Where(person => resultIDs.Contains(person.Id))
                .ToList();

            return new GetPersonsOutput
            {
                Persons = Mapper.Map<List<PersonDto>>(results)
            };
                            
        }

        //[AbpAuthorize("Administration.UserMaintenance")]

        public void CreatePerson(CreatePersonInput input)
        {
            Logger.Info("Registering a person : " + input.FName + "  " + input.LName);

            Person person = new Person()
            {
                FName = input.FName,
                LName = input.LName,
                NickName = input.NickName,
                Email = input.Email,
                Phone = input.Phone
            };

            _personRepository.Insert(person);
        }
    }
}
