using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Implementation
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }       

        public Customer CreateCustomer(Customer customer)
        {
           return _customerRepository.CreateCustomer(customer);
        }

        public Customer FindCustomerById(int id)
        {
           return _customerRepository.ReadCustomerById(id);
        }

        public Customer FindCustomerByIdIncludeOrders(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.ReadAllCustomers().ToList();
        }

        public List<Customer> GetAllByFirstName()
        {
            List<Customer> customers = new List<Customer>();
            return customers = GetAllCustomers().OrderBy((custByName => custByName.FirstName)).ToList();         
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            return _customerRepository.UpdateCustomer(customerUpdate);
        }

        public Customer DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }
    }
}
