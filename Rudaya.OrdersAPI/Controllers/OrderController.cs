using Microsoft.AspNetCore.Mvc;
using Rudaya.OrdersAPI.Entities;
using Rudaya.OrdersAPI.Interfaces;
using Rudaya.OrdersAPI.Repository;

namespace Rudaya.OrdersAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetOrders()
        {
            var orders = _orderRepository.GetOrders();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(orders);
        }

        [HttpGet("orderId")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrder(Guid orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order object is null");
            }

            return Ok("Order created successfully");
        }
    }
}
