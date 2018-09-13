using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService
{
        public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);

        Owner UpdateOwner(Owner owner);

        Owner DeleteOwner(Owner owner);

        Owner GetOwnerById(int ownerId);

        List<Owner> GetAllOwners();

        Owner GetOwnerByIdIncludingPets(int id);


    }
}
