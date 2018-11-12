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
        private readonly PetshopContext _ctx;

        public CustomerRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }

        public Customer CreateCustomer(Customer customer)
        {
            if (customer.Orders != null) _ctx.Attach(customer.Orders);
            var _customer = _ctx.Customers.Add(customer).Entity;
            _ctx.SaveChanges();
            return _customer;
        }

        public Customer ReadCustomerByIdIncludeOrders(int id)
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
            _ctx.Attach(customerUpdate).State = EntityState.Modified;
           // _ctx.Entry(customerUpdate).Reference(c => c.Orders).IsModified = true;
            _ctx.SaveChanges();
            return customerUpdate;          
        }

        public Customer DeleteCustomer(int id)
        {
            var customerRemoved = _ctx.Remove(new Customer {CustomerId = id}).Entity;
            _ctx.SaveChanges();
            return customerRemoved;
        }
    }
}