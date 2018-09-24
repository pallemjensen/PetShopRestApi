using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.DomainService
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();

        Order CreateOrder(Order order);

        Order UpdateOrder(Order order);

        Order DeleteOrder(Order order);

        Order GetOrderById(int orderId);

        Order GetOrderByIdIncludingCustomer(int id);
    }
}