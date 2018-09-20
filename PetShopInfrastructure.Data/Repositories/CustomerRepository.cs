using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer ReadCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> ReadAllCustomers()
        {
            throw new NotImplementedException();
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
