using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetShopRepository
    {
        public IEnumerable<Pet> ReadAllPets()
        {
            throw new NotImplementedException();
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Pet DeletePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Pet CreatePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Pet GetPetById(int petId)
        {
            throw new NotImplementedException();
        }
    }
}
