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
        private readonly IOrderRepository _orderRepository;

        public CustomerService(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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
            var customer = _customerRepository.ReadCustomerById(id);
            customer.Orders = _orderRepository.GetAllOrders()
                .Where(order => order.Customer.CustomerId == customer.CustomerId).ToList();
            return customer;
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
