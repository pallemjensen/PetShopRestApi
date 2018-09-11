using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Implementation;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Static.Data;
using PetShop.Infrastructure.Static.Data.Repositories;

namespace PetShop.PetShopRestApi.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            FakeDb.InitData();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IPetShopRepository, PetShopRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPetShopService, PetShopService>();
            //services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOrderService, OrderService>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
