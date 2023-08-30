using Microsoft.AspNetCore.Mvc;
using TicketsNetBackend.Models.Dto;
using TicketsNetBackend.Services;

namespace TicketsNetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private const int customerId = 3;
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<OrdersDto>> GetAll()
        {
            var ordersDto = await _orderService.GetAllAsync();

            return Ok(ordersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGetDto>> GetById(int id)
        {
            var orderDto = await _orderService.GetByIdAsync(id);

            return Ok(orderDto);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<OrderGetDto>> Patch([FromRoute] int id, [FromBody] OrderPatchDto orderPatch)
        {
            var orderGetDto = await _orderService.PatchAsync(id, orderPatch, customerId);

            return Ok(orderGetDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id, customerId);

            return NoContent();
        }
    }
}
