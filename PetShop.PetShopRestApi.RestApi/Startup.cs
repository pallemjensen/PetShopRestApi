using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Implementation;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.Infrastructure.Data;
using PetShop.Infrastructure.Data.Repositories;

namespace PetShop.PetShopRestApi.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //FakeDb.InitData();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PetshopContext>(opt => opt.UseInMemoryDatabase("InMemDbOne"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IPetShopRepository, PetRepository>();
            services.AddScoped<IPetShopService, PetShopService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddMvc().AddJsonOptions(options => {               
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetshopContext>();

                    var order2 = ctx.Orders.Add(new Order()
                    {
                        OrderId = 2,
                        OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(12)),
                        DeliveryDate = DateTime.Today,
                    }).Entity;

                    var customer1 = ctx.Customers.Add(new Customer()
                    {
                        CustomerId = 1,
                        FirstName = "Palle",
                        LastName = "Jensen",
                        Address = "Birdstreet 5",
                        Orders = new List<Order> {order2}
                    }).Entity;
                    
                    ctx.Customers.Add(new Customer()
                    {
                        CustomerId = 2,
                        FirstName = "Hans",
                        LastName = "Hansen",
                        Address = "Turtlestreet 10"
                    });
                   
                    var order1 = ctx.Orders.Add(new Order()
                    {
                        OrderId = 1,
                        OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(10)),
                        DeliveryDate = DateTime.Today,
                        Customer = customer1
                    });                                      
                    
                    var owner1 = ctx.Owners.Add(new Owner()
                    {
                        OwnerId = 1,
                        FirstName = "Mike",
                        LastName = "Dandelion",
                        Address = "Super Avenue 222",
                        PhoneNumber = "22221122",
                        Email = "3somethingmail@nise.org"
                    }).Entity;
                    
                    var owner2 = ctx.Owners.Add(new Owner()
                    {
                        OwnerId = 2,
                        FirstName = "Pale",
                        LastName = "Rider",
                        Address = "Western Heliosphere 1",
                        PhoneNumber = "99999992",
                        Email = "theuniverseatwork@massiveblackhole.uni",
                    }).Entity;
                    
                    var pet1 = ctx.Pets.Add(new Pet()
                    {
                        PetId = 1,
                        PetName = "Buffy",
                        BirthDate = DateTime.Today,
                        SoldDate = DateTime.Today.Add(TimeSpan.FromDays(20)),
                        Color = "Black",
                        PreviousOwner = "Peter",
                        Price = 234,
                        Type = "Dog",
                    }).Entity;
                   
                    var pet2 = ctx.Pets.Add(new Pet()
                    {
                        PetId = 2,
                        PetName = "Titan",
                        BirthDate = DateTime.Today,
                        SoldDate = DateTime.Today.Add(TimeSpan.FromDays(30)),
                        Color = "Striped",
                        PreviousOwner = "Finn",
                        Price = 549,
                        Type = "Horse",
                    }).Entity;
                    ctx.SaveChanges();
                } 
            }
            else
            {
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseMvc();



        }
    }
}
