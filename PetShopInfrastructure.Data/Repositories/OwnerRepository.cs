using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetshopContext _ctx;

        public OwnerRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }

        public Owner GetOwnerById(int ownerId)
        {
            return _ctx.Owners.FirstOrDefault(o => o.OwnerId == ownerId);
        }

        public Owner UpdateOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public Owner DeleteOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public Owner CreateOwner(Owner owner)
        {
           var newOwner = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return newOwner;
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return _ctx.Owners;
        }
    }
}
