﻿using System;
using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Static.Data
{
    public static class FakeDb
    {
        public static int OwnerId = 1;
        public static int PetId = 1;
        public static int OrderId = 1;
        public static int CustomerId = 1;

        public static List<Customer> Customers = new List<Customer>();
        public static List<Pet> Pets = new List<Pet>();     
        public static List<Owner> Owners = new List<Owner>();
        public static List<Order>   Orders = new List<Order>();

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
            };
            var owner1 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Bill",
                LastName =  "Gates",
                Address = "Scrum Street 11",
                PhoneNumber = "11112222",
                Email = "1fakemail@whatever.gov",
            };
            var owner2 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Peter",
                LastName = "Gregorian",
                Address = "Wrong Street 3",
                PhoneNumber = "11113333",
                Email = "2truemail@something.gov",
            };
            var owner3 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Mike",
                LastName = "Dandelion",
                Address = "Super Avenue 222",
                PhoneNumber = "22221122",
                Email = "3somethingmail@nise.org",
            };
            var owner4 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Pale",
                LastName = "Rider",
                Address = "Western Heliosphere 1",
                PhoneNumber = "99999992",
                Email = "theuniverseatwork@massiveblackhole.uni",
            };
            var owner5 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Super",
                LastName = "Man",
                Address = "Wrong Universe",
                PhoneNumber = "333-call-me-for-help",
                Email = "kindalamehero@inthewronguniverse.ani",
            };
            var owner6 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Iron",
                LastName = "Ethereal",
                Address = "Marvel Universe",
                PhoneNumber = "123581321",
                Email = "madearobotofmyself@itwaseasy.all",
            };
            var owner7 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Wonder",
                LastName = "Woman",
                Address = "Marvel Universe Women Apartments",
                PhoneNumber = "000000001",
                Email = "soontobeonph@beexcited.yea",
            };
            var order1 = new Order()
            {
                OrderId = OrderId++,
                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(10)),
                DeliveryDate = DateTime.Today
            };
            var order2 = new Order()
            {
                OrderId = OrderId++,
                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(12)),
                DeliveryDate = DateTime.Today
            };
            var order3 = new Order()
            {
                OrderId = OrderId++,
                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(8)),
                DeliveryDate = DateTime.Today.Add(TimeSpan.FromDays(5))
            };
            var order4 = new Order()
            {
                OrderId = OrderId++,
                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(5)),
                DeliveryDate = DateTime.Today.Add(TimeSpan.FromDays(3))
            };
            var order5 = new Order()
            {
                OrderId = OrderId++,
                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(7)),
                DeliveryDate = DateTime.Today.Add(TimeSpan.FromDays(2))
            };
            var order6 = new Order()
            {
                OrderId = OrderId++,
                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(11)),
                DeliveryDate = DateTime.Today.Add(TimeSpan.FromDays(1))
            };
            var order7 = new Order()
            {
                OrderId = OrderId++,
                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(4)),
                DeliveryDate = DateTime.Today.Add(TimeSpan.FromDays(3))
            };
            var custumer1 = new Customer()
            {
                CustomerId = CustomerId++,
                FirstName = "Charlie",
                LastName = "Dean",
                Address = "Strawberry Street 5"
            };
            var custumer2 = new Customer()
            {
                CustomerId = CustomerId++,
                FirstName = "Finn",
                LastName = "Hammer",
                Address = "Some Avenue 7"
            };
            var custumer3 = new Customer()
            {
                CustomerId = CustomerId++,
                FirstName = "Dan",
                LastName = "Brown",
                Address = "Yellow Road 19"
            };
            var custumer4 = new Customer()
            {
                CustomerId = CustomerId++,
                FirstName = "Michael",
                LastName = "Red",
                Address = "Wall Street 25"
            };
            var custumer5 = new Customer()
            {
                CustomerId = CustomerId++,
                FirstName = "Louise",
                LastName = "Slam Dunk",
                Address = "Funny Street 1"
            };
            var custumer6 = new Customer()
            {
                CustomerId = CustomerId++,
                FirstName = "Minnie",
                LastName = "Driver",
                Address = "City Middle 345"
            };
            var custumer7 = new Customer()
            {
                CustomerId = CustomerId++,
                FirstName = "Christopher",
                LastName = "Wankel",
                Address = "Muppet Road 78"
            };

            Customers.Add(custumer1);
            Customers.Add(custumer2);
            Customers.Add(custumer3);
            Customers.Add(custumer4);
            Customers.Add(custumer5);
            Customers.Add(custumer6);
            Customers.Add(custumer7);

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

            Orders.Add(order1);
            Orders.Add(order2);
            Orders.Add(order3);
            Orders.Add(order4);
            Orders.Add(order5);
            Orders.Add(order6);
            Orders.Add(order7);
        }
    }
}
