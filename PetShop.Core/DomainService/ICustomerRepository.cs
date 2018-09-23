using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.DomainService
{
    public interface ICustomerRepository
    {   
        Customer CreateCustomer(Customer customer);
        
        Customer ReadCustomerById(int id);

        IEnumerable<Customer> ReadAllCustomers();
        
        Customer UpdateCustomer(Customer customerUpdate);
        
        Customer DeleteCustomer(int id);

        Customer ReadCustomerByIdIncludeOrders(int id);
    }
}
