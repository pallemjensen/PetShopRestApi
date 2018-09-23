using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;

namespace PetShop.Core.DomainService
{
        public interface IOwnerRepository
    {
        Owner GetOwnerById(int ownerID);

        Owner UpdateOwner(Owner owner);

        Owner DeleteOwner(Owner owner);

        Owner CreateOwner(Owner owner);

        IEnumerable<Owner> ReadAllOwners();

        Owner ReadOwnerByIdIncludePets(int id);
    }
}
