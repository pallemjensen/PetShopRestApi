using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetShopRepository
    {
        readonly PetshopContext _ctx;

        public PetRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Pet> ReadAllPets()
        {
            return _ctx.Pets;
            //return _ctx.Pets.Include(p => p.Owner);
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
            var _pet = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return _pet;
        }

        public Pet GetPetById(int petId)
        {
            return _ctx.Pets.FirstOrDefault((p => p.PetId == petId));
        }
    }
}
