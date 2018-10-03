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
using PetShop.Infrastructure.Data;
using PetShop.Infrastructure.Data.Repositories;

namespace PetShop.PetShopRestApi.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<PetshopContext>(opt => opt.UseInMemoryDatabase("InMemDbOne"));
            services.AddCors();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin());
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

            services.AddMvc().AddJsonOptions(options =>
            {
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
                    DBInitializer.SeedDb(ctx);
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowAllOrigins");

            //app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}