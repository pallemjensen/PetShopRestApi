﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.PetShopRestApi.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetShopRepository _petShopRepository;

        public PetsController(IPetShopRepository petShopRepository)
        {
            _petShopRepository = petShopRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
           return _petShopRepository.ReadAllPets().ToList();
        }
    

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petShopRepository.GetPetById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Pet pet)
        {
            _petShopRepository.CreatePet(pet);
            return Ok("Pet with id " + pet.PetId + " was created!");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(Pet pet)
        {
            int id = pet.PetId;
            _petShopRepository.UpdatePet(pet);
            return Ok("Pet with id " + id + " was updated.");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Pet pet = new Pet();
            pet = _petShopRepository.GetPetById(id);
            _petShopRepository.DeletePet(pet);
            return Ok("Pet with id " + id + " was deleted.");
        }
    }
}
