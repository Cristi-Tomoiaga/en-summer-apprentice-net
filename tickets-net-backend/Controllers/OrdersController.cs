using Microsoft.AspNetCore.Mvc;
using tickets_net_backend.Models.Dto;
using tickets_net_backend.Services;

namespace tickets_net_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderGetDto>>> GetAll()
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
            var orderGetDto = await _orderService.PatchAsync(id, orderPatch);

            return Ok(orderGetDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id);

            return NoContent();
        }
    }
}
