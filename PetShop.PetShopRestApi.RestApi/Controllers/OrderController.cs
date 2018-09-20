using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;

namespace PetShop.PetShopRestApi.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _orderService.GetAllOrders().ToList();
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Order> Get(int id)
        {
            return _orderService.GetOrderById(id);
        }

        // POST: api/Order
        [HttpPost]
        public  ActionResult<Order> Post([FromBody] Order order)
        {
            try
            {
                return Ok(_orderService.CreateOrder(order));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            if (id < 1 || id != order.OrderId)
            {
                return BadRequest("Parameter Id and order ID must be the same.");
            }
            return Ok(_orderService.UpdateOrder(order));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var order = _orderService.GetOrderById(id);
            _orderService.DeleteOrder(order);
            return Ok("Order with id " + id + " was deleted.");
        }
    }
}
