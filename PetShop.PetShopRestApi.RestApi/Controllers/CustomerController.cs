using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;

namespace PetShop.PetShopRestApi.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController 
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return _customerService.GetAllCustomers();         
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return _customerService.FindCustomerById(id);
        }       

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            return _customerService.CreateCustomer(customer);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put([FromBody] Customer customer)
        {
           return _customerService.UpdateCustomer(customer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {          
            return _customerService.DeleteCustomer(id);
        }
    }
}
