using System;
using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Static.Data
{
    public static class FakeDb
    {
        public static int OwnerId = 1;
        public static int PetId = 1;
        public static List<Pet> Pets = new List<Pet>();     
        public static List<Owner> Owners = new List<Owner>();

        public static void InitData()
        {
            var pet1 = new Pet()
            {              
                PetId = PetId++,
                PetName = "Fluffy",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(10)),
                Color = "White",
                PreviousOwner = "Hans",
                Price = 123,
                Type = "Dog", 
                OwnerId = 3                               
            };
            var pet2 = new Pet()
            {
                PetId = PetId++,
                PetName = "Buffy",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(20)),
                Color = "Black",
                PreviousOwner = "Peter",
                Price = 234,
                Type = "Dog",
                OwnerId = 1
            };
            var pet3 = new Pet()
            {
                PetId = PetId++,
                PetName = "Bongo",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(40)),
                Color = "Grey",
                PreviousOwner = "Bente",
                Price = 9236,
                Type = "Goat",
                OwnerId = 2

            };
            var pet4 = new Pet()
            {
                PetId = PetId++,
                PetName = "Titan",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(30)),
                Color = "Striped",
                PreviousOwner = "Finn",
                Price = 549,
                Type = "Horse",
                OwnerId = 6
            };
            var pet5 = new Pet()
            {
                PetId = PetId++,
                PetName = "Venus",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(50)),
                Color = "Yellow",
                PreviousOwner = "Jasper",
                Price = 2356,
                Type = "Bird",
                OwnerId = 7
            };
            var pet6 = new Pet()
            {
                PetId = PetId++,
                PetName = "Moron",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(5)),
                Color = "Brown",
                PreviousOwner = "Sophie",
                Price = 12,
                Type = "Cat",
                OwnerId = 2
            };
            var pet7 = new Pet()
            {
                PetId = PetId++,
                PetName = "Derp",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(100)),
                Color = "Purple",
                PreviousOwner = "Carrie",
                Price = 56,
                Type = "Cat",
                OwnerId = 4
            };
            var owner1 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Bill",
                LastName =  "Gates",
                Address = "Scrum Street 11",
                PhoneNumber = "11112222",
                Email = "1fakemail@whatever.gov",
                PetOwnedId = 4
            };
            var owner2 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Peter",
                LastName = "Gregorian",
                Address = "Wrong Street 3",
                PhoneNumber = "11113333",
                Email = "2truemail@something.gov",
                PetOwnedId = 2
            };
            var owner3 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Mike",
                LastName = "Dandelion",
                Address = "Super Avenue 222",
                PhoneNumber = "22221122",
                Email = "3somethingmail@nise.org",
                PetOwnedId = 3
            };
            var owner4 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Pale",
                LastName = "Rider",
                Address = "Western Heliosphere 1",
                PhoneNumber = "99999992",
                Email = "theuniverseatwork@massiveblackhole.uni",
                PetOwnedId = 1
            };
            var owner5 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Super",
                LastName = "Man",
                Address = "Wrong Universe",
                PhoneNumber = "333-call-me-for-help",
                Email = "kindalamehero@inthewronguniverse.ani",
                PetOwnedId = 5
            };
            var owner6 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Iron",
                LastName = "Ethereal",
                Address = "Marvel Universe",
                PhoneNumber = "123581321",
                Email = "madearobotofmyself@itwaseasy.all",
                PetOwnedId = 6
            };
            var owner7 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Wonder",
                LastName = "Woman",
                Address = "Marvel Universe Women Apartments",
                PhoneNumber = "000000001",
                Email = "soontobeonph@beexcited.yea",
                PetOwnedId = 7
            };

            Owners.Add(owner1);
            Owners.Add(owner2);
            Owners.Add(owner3);
            Owners.Add(owner4);
            Owners.Add(owner5);
            Owners.Add(owner6);
            Owners.Add(owner7);

            Pets.Add(pet1);
            Pets.Add(pet2);
            Pets.Add(pet3);
            Pets.Add(pet4);
            Pets.Add(pet5);
            Pets.Add(pet6);
            Pets.Add(pet7);
        }
    }
}
