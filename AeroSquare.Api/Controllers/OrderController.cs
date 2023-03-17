using AeroSquare.Entities;
using AeroSquare.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AeroSquare.Api.Controllers
{
    [ApiController]
    [Route("api/airplane")]
    [EnableCors("AllowAll")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<bool> Save([FromBody] Order order)
        {
            return await _orderService.SaveOrder(order);
        }
    }
}
