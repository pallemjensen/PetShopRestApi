
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;

namespace PetShop.PetShopRestApi.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : Controller
    {
        private readonly IPetShopService _petShopService;

        public PetsController(IPetShopService petShopService)
        {
            _petShopService = petShopService;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petShopService.GetAllPets().ToList();
        }


        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petShopService.GetPetById(id);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            return Ok(_petShopService.CreatePet(pet));
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.PetId)
            {
                return BadRequest("Parameter Id and pet ID must be the same.");
            }
            return Ok(_petShopService.UpdatePet(pet));
        }
     
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pet = _petShopService.GetPetById(id);
            _petShopService.DeletePet(pet);
            return Ok("Pet with id " + id + " was deleted.");
        }
    }
}
