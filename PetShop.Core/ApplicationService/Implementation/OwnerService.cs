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

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
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
    }
}
