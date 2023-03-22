using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Papko.OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return default;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderByID(Guid id)
    {
        return default;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderByID(Guid id)
    {
        return default;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> CreateOrderByID(Guid id)
    {
        return default;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderByID(Guid id)
    {
        return default;
    }
}
