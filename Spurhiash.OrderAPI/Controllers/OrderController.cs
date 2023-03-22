using Microsoft.AspNetCore.Mvc;
using Spurhiash.OrderAPI.Data;
using Spurhiash.OrderAPI.Models;

namespace Spurhiash.OrderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            return OrderData.Orders;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(Guid id)
        {
            var order = OrderData.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrderById(Guid id)
        {
            var order = OrderData.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            OrderData.Orders.Remove(order);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            order.Id = Guid.NewGuid();
            OrderData.Orders.Add(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrderById(Guid id, Order updatedOrder)
        {
            var order = OrderData.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            order.Total = updatedOrder.Total;
            order.BuyerId = updatedOrder.BuyerId;
            order.ProductItems = updatedOrder.ProductItems;
            return NoContent();
        }

    }
}
    
