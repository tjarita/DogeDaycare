using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using DogeDaycare.Animals.Dtos;
using DogeDaycare.Persons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals
{
    public class AnimalAppService : ApplicationService, IAnimalAppService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IPersonRepository _personRepository;


        public AnimalAppService(IAnimalRepository animalRepository, IPersonRepository personRepository)
        {
            _animalRepository = animalRepository;
            _personRepository = personRepository;
        }


        #region CREATE
        public void CreateAnimal(CreateAnimalInput input)
        {
            Animal animal = new Animal() { Name = input.Name , Owner = _personRepository.Get(input.IdOwner)};
            Logger.Info("Registering an animal named..." + input.Name + "...Id..." + animal.Id + "...to..." + animal.Owner.FName + " " + animal.Owner.LName);
            _animalRepository.Insert(animal);
        }
        #endregion

        #region READ
        public GetAnimalsOutput GetAnimals(GetAnimalsInput input)
        {
            var animals = _animalRepository.GetAllPetsPerOwner(input.IdOwner);

            return new GetAnimalsOutput
            {
                Animals = Mapper.Map<List<AnimalDto>>(animals)
            };
        }

        public GetAnimalsOutput GetAllAnimals()
        {
            var query = _animalRepository.GetAllAnimals();

            var animals = Mapper.Map<List<AnimalDto>>(query);

            return new GetAnimalsOutput()
            {
                Animals = animals
            };
        }
        #endregion

        #region UPDATE
        public void UpdateAnimal()
        {

        }
        #endregion
    }
}
