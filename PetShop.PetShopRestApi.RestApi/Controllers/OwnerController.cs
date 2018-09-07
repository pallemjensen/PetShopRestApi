using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.PetShopRestApi.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        // GET: api/Owner
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerRepository.ReadAllOwners().ToList();
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        // POST: api/Owner
        [HttpPost]
        public ActionResult Post([FromBody] Owner owner)
        {
            _ownerRepository.CreateOwner(owner);
            return Ok("Owner with id " + owner.OwnerId + " was created!");
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public ActionResult Put(Owner owner)
        {
            int id = owner.OwnerId;
            _ownerRepository.UpdateOwner(owner);
            return Ok("Owner with id " + id + " was updated.");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var owner = _ownerRepository.GetOwnerById(id);
            _ownerRepository.DeleteOwner(owner);
            return Ok("Owner with id " + id + " was deleted.");
        }
    }
}
