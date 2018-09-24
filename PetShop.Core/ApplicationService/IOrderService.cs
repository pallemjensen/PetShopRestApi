using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();

        Order CreateOrder(Order order);

        Order UpdateOrder(Order order);

        Order DeleteOrder(Order order);

        Order GetOrderById(int OrderId);

        Order GetOrderByIdIncludingCustomer(int id);
    }
}