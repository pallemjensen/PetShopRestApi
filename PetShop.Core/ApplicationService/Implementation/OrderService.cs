using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository,
            ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders().ToList();
        }

        public Order CreateOrder(Order order)
        {
            
            if (order.Customer == null || order.Customer.CustomerId <= 0 )
            {
                throw new InvalidDataException("To create an order, you need a customer");
            }

            if (_customerRepository.ReadCustomerById(order.Customer.CustomerId) == null)
            {
                throw new InvalidDataException("Customer was not found.");
            }

            if (order.OrderDate == null)
            {
                throw new InvalidDataException("Order needs an Order date.");
            }
            
            return _orderRepository.CreateOrder(order);
        }

        public Order UpdateOrder(Order order)
        {
            return _orderRepository.UpdateOrder(order);
        }

        public Order DeleteOrder(Order order)
        {
            return _orderRepository.DeleteOrder(order);
        }

        public Order GetOrderById(int orderID)
        {
            return _orderRepository.GetOrderById(orderID);
        }
    }
}
