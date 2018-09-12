using System;
using System.Collections.Generic;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Static.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository()
        {
            if (FakeDb.Orders.Count > 0) return;

            var order8 = new Order()
            {
                OrderId = FakeDb.OrderId++,
                DeliveryDate = DateTime.Now.AddMonths(1),
                OrderDate = DateTime.Now.AddMonths(-1)
            };
            FakeDb.Orders.Add(order8);
        }


        public IEnumerable<Order> GetAllOrders()
        {
            return FakeDb.Orders;
        }

        public Order CreateOrder(Order order)
        {
            order.OrderId = FakeDb.OrderId++;
            FakeDb.Orders.Add(order);
            return order;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.OwnerId = FakeDb.OwnerId++;
            FakeDb.Owners.Add(owner);
            return owner;
        }

        public Order UpdateOrder(Order order)
        {           
            Order orderToUpdate = GetOrderById(order.OrderId);
            orderToUpdate.DeliveryDate = order.DeliveryDate;
            orderToUpdate.OrderDate = order.OrderDate;

            return order;
        }

        public Order DeleteOrder(Order order)
        {
            FakeDb.Orders.Remove(order);
            return order;
        }

        public Order GetOrderById(int orderId)
        {          
            foreach (var order in FakeDb.Orders)
            {
                if (order.OrderId == orderId)
                {
                    return order;
                }
            }
            return null;
        }
    }
}
