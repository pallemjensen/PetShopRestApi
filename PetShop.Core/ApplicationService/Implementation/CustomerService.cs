using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Implementation
{
    public class CustomerService : ICustomerService
    {
        public Customer NewCustomer(string firstName, string lastName, string address)
        {
            throw new NotImplementedException();
        }

        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllByFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
