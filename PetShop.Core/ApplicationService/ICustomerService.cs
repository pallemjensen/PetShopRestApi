using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService
{
    public interface ICustomerService
    {   
        Customer CreateCustomer(Customer customer);

        Customer FindCustomerById(int id);

        Customer FindCustomerByIdIncludeOrders(int id);

        List<Customer> GetAllCustomers();

        List<Customer> GetAllByFirstName();
     
        Customer UpdateCustomer(Customer customerUpdate);
        
        Customer DeleteCustomer(int id);
    }
}
