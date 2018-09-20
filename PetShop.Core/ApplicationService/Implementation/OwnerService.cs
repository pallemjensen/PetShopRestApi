using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Implementation
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetShopRepository _petShopRepository;

        public OwnerService(IOwnerRepository ownerRepository, IPetShopRepository petShopRepository)
        {
            _ownerRepository = ownerRepository;
            _petShopRepository = petShopRepository;
        }

        public Owner CreateOwner(Owner owner)
        {
            if (owner.FirstName == null || owner.FirstName.Any(char.IsDigit) || owner.LastName == null || owner.LastName.Any(char.IsDigit))
            {
                throw new InvalidDataException("Owner must have a first and last name and they can not contain numbers.");
            }

            if (owner.Email == null || owner.PhoneNumber == null)
            {
               throw new InvalidDataException("Owner must have an email and phone number.");
            }

            if (owner.FirstName.Length < 2)
            {
                throw new InvalidDataException("First name must be at least 2 characters.");
            }

            if (owner.LastName.Length < 2)
            {
                throw new InvalidDataException("Last name must be at least 2 characters.");
            }

            if ((!(owner.Email.Contains("@")) || (!(owner.Email.Contains(".")))))
            {
                throw new InvalidDataException("Not a valid email.");
            }

            if (owner.PhoneNumber.Length < 8)
            {
                throw new InvalidDataException("Phone number must be at least 8 numbers.");
            }

            if (!(owner.Address.Any(char.IsDigit) && owner.Address.Any(char.IsLetter)))
            {
                throw new InvalidDataException("Address must contain both letters and numbers.");
            }

            if (owner.Email.Length < 7)
            {
                throw new InvalidDataException("Email must be at least 7 characters.");
            }

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

        public Owner GetOwnerByIdIncludingPets(int id)
        {
            Owner owner = GetOwnerById(id);
            owner.OwnedPets = _petShopRepository.ReadAllPets().Where(pet => pet.Owner.OwnerId == owner.OwnerId)
            .ToList();
            return owner;
        }
    }
}
