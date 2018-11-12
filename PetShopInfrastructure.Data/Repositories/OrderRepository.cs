using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PetshopContext _ctx;

        public OrderRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders;
        }

        public Order CreateOrder(Order order)
        {
            if (order.Customer != null) _ctx.Attach(order.Customer);

            var newOrder = _ctx.Orders.Add(order).Entity;
            _ctx.SaveChanges();
            return newOrder;
        }

        public Order UpdateOrder(Order order)
        {
            _ctx.Attach(order).State = EntityState.Modified;
           // _ctx.Entry(order).Reference(o => o.Customer).IsModified = true;
            _ctx.SaveChanges();
            return order;
        }

        public Order DeleteOrder(Order order)
        {
            var orderRemoved = _ctx.Remove(order).Entity;
            _ctx.SaveChanges();
            return orderRemoved;
        }

        public Order GetOrderById(int orderId)
        {
            return _ctx.Orders.FirstOrDefault(ord => ord.OrderId == orderId);
        }

        public Order GetOrderByIdIncludingCustomer(int id)
        {
            return _ctx.Orders
                .Include(ord => ord.Customer)
                .FirstOrDefault(ord => ord.OrderId == id);
        }
    }
}