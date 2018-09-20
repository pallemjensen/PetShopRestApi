using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
