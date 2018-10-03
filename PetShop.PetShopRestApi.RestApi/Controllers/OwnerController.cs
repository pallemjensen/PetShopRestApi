using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;

namespace PetShop.PetShopRestApi.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/Owner
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwners().ToList();
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.GetOwnerByIdIncludingPets(id);
            //return _ownerService.GetOwnerById(id);
        }

        // POST: api/Owner
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            return _ownerService.CreateOwner(owner);
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.OwnerId)
                return BadRequest("Parameter Id and owner ID must be the same.");
            return Ok(_ownerService.UpdateOwner(owner));
        }

        // DELETE: api/Owner/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ownerToDelete = _ownerService.GetOwnerById(id);
            _ownerService.DeleteOwner(ownerToDelete);
            return Ok("Owner with id " + id + " was deleted.");
        }
    }
}