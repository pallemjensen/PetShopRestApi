using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Implementation
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private IPetShopRepository _petShopRepository;

        public OwnerService(IOwnerRepository ownerRepository, IPetShopRepository petShopRepository)
        {
            _ownerRepository = ownerRepository;
            _petShopRepository = petShopRepository;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.CreateOwner(owner);
        }

        public Owner UpdateOwner(Owner owner)
        {
            return _ownerRepository.UpdateOwner(owner);
        }

        public Owner DeleteOwner(Owner owner)
        {
            return _ownerRepository.DeleteOwner(owner);
        }

        public Owner GetOwnerById(int ownerId)
        {
            return _ownerRepository.GetOwnerById(ownerId);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.ReadAllOwners().ToList();
        }

        public Owner GetOwnerByIdIncludingpets(int id)
        {
            Owner owner = GetOwnerById(id);
            owner.OwnedPets = _petShopRepository.ReadAllPets().Where(pet => pet.Owner.OwnerId == owner.OwnerId)
            .ToList();
            return owner;
        }
    }
}
