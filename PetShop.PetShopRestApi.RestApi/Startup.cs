using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Implementation;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;
using PetShop.Infrastructure.Data.Repositories;
using PetShop.Core.Entities;
using PetShop.PetShopRestApi.RestApi.Helpers;


namespace PetShop.PetShopRestApi.RestApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()

                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            JwtSecurityKey.SetSecret("a secret that needs to be at least 16 characters long");
        }    
             
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSecurityKey.Key,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(30)
                };
            });

            
            services.AddDbContext<PetshopContext>(opt => opt.UseSqlite("Data Source=PetshopApp.db"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IOrderLineRepository, OrderLineRepository>();
            services.AddScoped<IOrderLineService, OrderLineService>();

            services.AddScoped<IPetShopRepository, PetRepository>();
            services.AddScoped<IPetShopService, PetShopService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IUserRepository<User>, UserRepository>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            if (_env.IsDevelopment())
            {
                services.AddDbContext<PetshopContext>(
                opt => opt.UseSqlite("Data Source=PetshopApp.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<PetshopContext>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }
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
                    DBInitializer.SeedDb(ctx);
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetshopContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            //app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyOrigin());

            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}