﻿using System;
using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDb(PetshopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var order2 = ctx.Orders.Add(new Order
            {
                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(12)),
                DeliveryDate = DateTime.Today
            }).Entity;


            var customer1 = ctx.Customers.Add(new Customer
            {
                FirstName = "Palle",
                LastName = "Jensen",
                Address = "Birdstreet 5",
                Orders = new List<Order> {order2}
            }).Entity;

            var customer2 = ctx.Customers.Add(new Customer
            {
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Turtlestreet 10"
            });

            var order1 = ctx.Orders.Add(new Order
            {
                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(10)),
                DeliveryDate = DateTime.Today,
                Customer = customer1
            });

            var pet1 = ctx.Pets.Add(new Pet
            {
                PetName = "Buffy",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(20)),
                Color = "Black",
                PreviousOwner = "Peter",
                Price = 234,
                Type = "Dog"
            }).Entity;

            var owner1 = ctx.Owners.Add(new Owner
            {
                FirstName = "Mike",
                LastName = "Dandelion",
                Address = "Super Avenue 222",
                PhoneNumber = "22221122",
                Email = "3somethingmail@nise.org"
                //OwnedPets = new List<Pet>() { pet1 }
            }).Entity;

            var pet2 = ctx.Pets.Add(new Pet
            {
                PetName = "Titan",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(30)),
                Color = "Striped",
                PreviousOwner = "Finn",
                Price = 549,
                Type = "Horse"
                //Owner = owner2
            }).Entity;
            var owner2 = ctx.Owners.Add(new Owner
            {
                FirstName = "Pale",
                LastName = "Rider",
                Address = "Western Heliosphere 1",
                PhoneNumber = "99999992",
                Email = "theuniverseatwork@massiveblackhole.uni",
                OwnedPets = new List<Pet> {pet1, pet2}
            }).Entity;

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            ctx.Users.AddRange(users);
            ctx.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}