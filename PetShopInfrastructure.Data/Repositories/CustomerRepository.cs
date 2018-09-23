using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly PetshopContext _ctx;

        public CustomerRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }

        public Customer CreateCustomer(Customer customer)
        {
            var cust = _ctx.Customers.Add(customer).Entity;
            _ctx.SaveChanges();
            return cust;
           
        }

        public Customer ReadyByIdIncludeOrders(int id)
        {
            return _ctx.Customers
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer ReadCustomerById(int id)
        {
            return _ctx.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public IEnumerable<Customer> ReadAllCustomers()
        {
            return _ctx.Customers;
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            throw new NotImplementedException();
        }

        public Customer DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
