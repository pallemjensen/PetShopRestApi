using System.Collections.Generic;
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
            foreach (var customer in FakeDb.Customers)
            {
                if (customer.CustomerId == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public IEnumerable<Customer> ReadAllCustomers()
        {
            return FakeDb.Customers;
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            Customer customerToUpdate = ReadCustomerById(customerUpdate.CustomerId);
            customerToUpdate.FirstName = customerUpdate.FirstName;
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
