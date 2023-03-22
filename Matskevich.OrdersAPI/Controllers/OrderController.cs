using Matskevich.OrdersAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Matskevich.OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static List<Order> _orders = new List<Order>();

        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(Guid id)
        {
            var result = _orders.FirstOrDefault(o => o.Id == id);
            if (result is not null)
                return result;
            return BadRequest("There is no such Id");
        }

        [HttpPost("{buyer}")]
        public ActionResult<Order> Post(string buyer, [FromBody] List<Product> products)
        {
            var order = _orders.FirstOrDefault(x => x.Buyer.Equals(buyer));
            if (order is null) 
            {
                var newOrder = new Order { Buyer = buyer, Products = products, Total = Math.Round(products.Sum(x => x.Quantity * x.Price), 2) };
                _orders.Add(newOrder);
                return newOrder;
            }
            return BadRequest("Buyer is already exist!");
        }

        [HttpPut("{orderId}")]
        public ActionResult<Order> Put(Guid orderId, [FromBody] List<Product> products)
        {
            var order = _orders.FirstOrDefault(x => x.Id.Equals(orderId));
            if (order is not null)
            {
                string buyer = order.Buyer; 
                _orders.Remove(order);

                var newOrder = new Order { Buyer = buyer, Products = products, Total = Math.Round(products.Sum(x => x.Quantity * x.Price), 2) };
                _orders.Add(newOrder);
                return newOrder;
            }
            return BadRequest("There is no such Id");
        }

        [HttpDelete("{orderId}")]
        public ActionResult Delete(Guid orderId)
        {
            var order = _orders.FirstOrDefault(x => x.Id.Equals(orderId));
            if (order is not null)
            {
                _orders.Remove(order);
                return StatusCode(200);
            }
            return BadRequest("There is no such Id");            
        }
    }
}
