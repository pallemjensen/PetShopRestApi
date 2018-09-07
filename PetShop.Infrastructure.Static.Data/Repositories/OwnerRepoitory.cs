using System.Collections.Generic;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Static.Data.Repositories
{
        public class OwnerRepository : IOwnerRepository
    {       
        public Owner GetOwnerById(int id)
        {
            foreach (var owner in FakeDb.Owners)
            {
                if (owner.OwnerId == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public Owner UpdateOwner(Owner owner)
        {
            Owner ownerToUpdate = GetOwnerById(owner.OwnerId);
            ownerToUpdate.FirstName = owner.FirstName;
            ownerToUpdate.LastName = owner.LastName;
            ownerToUpdate.Address = owner.Address;
            ownerToUpdate.Email = owner.Email;
            ownerToUpdate.PhoneNumber = owner.PhoneNumber;           

            return owner;
        }

        public Owner DeleteOwner(Owner owner)
        {
            FakeDb.Owners.Remove(owner);
            return owner;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.OwnerId = FakeDb.PetId++;
            FakeDb.Owners.Add(owner);
            return owner;
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return FakeDb.Owners;
        }
    }
}
