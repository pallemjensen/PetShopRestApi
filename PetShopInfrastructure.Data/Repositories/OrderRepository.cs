﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var newOrder = _ctx.Orders.Add(order).Entity;
            _ctx.SaveChanges();
            return newOrder;
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
            return _ctx.Orders.FirstOrDefault(ord => ord.OrderId == orderId);
        }
    }
}