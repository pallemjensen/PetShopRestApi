using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer)
        {
            customer.CustomerId = FakeDb.CustomerId++;
            FakeDb.Customers.Add(customer);
            return customer;
        }

        public Customer ReadCustomerById(int id)
        {
            return FakeDb.Customers.
                Select(c => new Customer()
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    Address = c.Address,
                    LastName = c.LastName
            }).FirstOrDefault(c => c.CustomerId == id);
        }

        public IEnumerable<Customer> ReadAllCustomers()
        {
            return FakeDb.Customers;
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            string name;
            Customer customerToUpdate = ReadCustomerById(customerUpdate.CustomerId);
            customerToUpdate.FirstName = customerUpdate.FirstName;
            name = ReadCustomerById(2).FirstName;
            customerToUpdate.LastName = customerUpdate.LastName;
            customerToUpdate.Address = customerUpdate.Address;

            return customerToUpdate;
        }

        public Customer DeleteCustomer(int id)
        {
            var customer = ReadCustomerById(id);
            FakeDb.Customers.Remove(customer);
            return customer;
        }
    }
}
