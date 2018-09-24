using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Implementation
{
    public class PetShopService : IPetShopService
    {
        private readonly IPetShopRepository _petShopRepository;

        public PetShopService(IPetShopRepository petShopRepository)
        {
            _petShopRepository = petShopRepository;
        }

        public List<Pet> GetAllPets()
        {
            return _petShopRepository.ReadAllPets().ToList();
        }

        public List<Pet> GetPetsByType(string type)
        {
            var petsByType = new List<Pet>();
            foreach (var pet in GetAllPets())
                if (string.Equals(pet.Type, type, StringComparison.OrdinalIgnoreCase))
                    petsByType.Add(pet);
            return petsByType;
        }

        public List<Pet> GetFiveCheapestPets()
        {
            var getFiveCheapestPets = SortPetsByPrice().GetRange(0, 5).ToList();

            return getFiveCheapestPets;
        }

        public List<Pet> SortPetsByPrice()
        {
            var orderedByPrice = GetAllPets().OrderBy(orderedPet => orderedPet.Price).ToList();

            return orderedByPrice;
        }

        public Pet CreatePet(Pet pet)
        {
            //if (DateTime.TryParse(pet.BirthDate.ToString(CultureInfo.InvariantCulture), out var temp))
            //{
            //    pet.BirthDate = Convert.ToDateTime(temp.ToShortDateString());
            //}
            //else
            //{
            //    throw new InvalidDataException("Birthday is not a valid date.");
            //}

            if (!Regex.IsMatch(Convert.ToString(pet.Price, CultureInfo.InvariantCulture), @"^\d+$"))
                throw new InvalidDataException("Price can only contain numbers.");

            if (pet.PetName == null || pet.PetName.Any(char.IsDigit))
                throw new InvalidDataException("Pet must have a name and it can not contain numbers.");

            if (pet.Color == null || pet.Color.Any(char.IsDigit))
                throw new InvalidDataException("Pet must have a color and it can not contain numbers.");

            if (pet.Type == null || pet.Type.Any(char.IsDigit))
                throw new InvalidDataException("Pet must have a type and it can not contain numbers.");

            if (pet.BirthDate == null) throw new InvalidDataException("Pet must have a birthday.");

            return _petShopRepository.CreatePet(pet);
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petShopRepository.UpdatePet(pet);
        }

        public Pet DeletePet(Pet pet)
        {
            return _petShopRepository.DeletePet(pet);
        }

        public Pet GetPetById(int petId)
        {
            return _petShopRepository.GetPetById(petId);
        }

        public Pet GetPetByIdIncludingOwner(int id)
        {
            return _petShopRepository.GetPetByIdIncludingOwner(id);
        }
    }
}