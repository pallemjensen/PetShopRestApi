using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
