using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using System.Data.Entity;
using AutoMapper;
using DogeDaycare.Animals.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace DogeDaycare.Animals
{
    public class AnimalAppService : ApplicationService, IAnimalAppService
    {
        private readonly IAnimalManager _animalManager;
        private readonly IRepository<Animal, long> _animalRepository;

        public AnimalAppService(
            IAnimalManager animalManager,
            IRepository<Animal, long> animalRepository)
        {
            _animalManager = animalManager;
            _animalRepository = animalRepository;
        }

        public async Task Create(CreateAnimalInput input)
        {
            Logger.Info(string.Format("Creating a new animal with name: {0}", input.Name));
            var @animal = Animal.Create(AbpSession.GetTenantId(), input.Name, input.Owner, input.Age);
            await _animalManager.CreateAsync(@animal);
        }

        //public async Task Deactivate(EntityRequestInput<long> input)
        //{
        //    var @animal = await _animalManager.GetAsync(input.Id);
        //    _animalManager.Deactivate(@animal);
        //}

        //public async Task<AnimalDetailOutput> GetDetail(EntityRequestInput<long> input)
        //{
        //    var @animal = await _animalRepository
        //        .GetAll()
        //        .Include(a => a.Owner)
        //        .Where(a => a.Id == input.Id)
        //        .FirstOrDefaultAsync();

        //    if (@animal == null)
        //    {
        //        throw new UserFriendlyException("Couldn't find that animal");
        //    }

        //    return @animal.MapTo<AnimalDetailOutput>();
        //}



        //public AnimalAppService(IAnimalRepository animalRepository, IPersonRepository personRepository)
        //{
        //    _animalRepository = animalRepository;
        //    _personRepository = personRepository;
        //}


        //#region CREATE
        //public void CreateAnimal(CreateAnimalInput input)
        //{
        //    Animal animal = new Animal() { Name = input.Name , Owner = _personRepository.Get(input.IdOwner)};
        //    Logger.Info("Registering an animal named..." + input.Name + "...Id..." + animal.Id + "...to..." + animal.Owner.FName + " " + animal.Owner.LName);
        //    _animalRepository.Insert(animal);
        //}
        //#endregion

        //#region READ
        //public GetAnimalsOutput GetAnimals(GetAnimalsInput input)
        //{
        //    var animals = _animalRepository.GetAllPetsPerOwner(input.IdOwner);

        //    return new GetAnimalsOutput
        //    {
        //        Animals = Mapper.Map<List<AnimalDto>>(animals)
        //    };
        //}

        //public GetAnimalsOutput GetAllAnimals()
        //{
        //    var query = _animalRepository.GetAllAnimals();

        //    var animals = Mapper.Map<List<AnimalDto>>(query);

        //    return new GetAnimalsOutput()
        //    {
        //        Animals = animals
        //    };
        //}
        //#endregion

        //#region UPDATE
        //public void UpdateAnimal()
        //{

        //}
        //#endregion
    }
}
