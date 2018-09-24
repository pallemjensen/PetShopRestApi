using System.Collections.Generic;
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
//            if (id < 1)
//            {
//                return BadRequest("Id must be greater then 0");
//            }

            return _customerService.FindCustomerByIdIncludeOrders(id);
            //return _customerService.FindCustomerById(id);
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            //if (string.IsNullOrEmpty(customer.FirstName))
            //{
            //    return BadRequest("Firstname is Required for Creating Customer");
            //}

            //if (string.IsNullOrEmpty(customer.LastName))
            //{
            //    return BadRequest("LastName is Required for Creating Customer");
            //}

            return _customerService.CreateCustomer(customer);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            //if (id < 1 || id != customer.CustomerId)
            //{

            //    return BadRequest("Parameter Id and customer ID must be the same.");
            //}
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