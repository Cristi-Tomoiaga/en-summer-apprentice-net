using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tickets_net_backend.Models.Dto;
using tickets_net_backend.Repositories;

namespace tickets_net_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, ITicketCategoryRepository ticketCategoryRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderGetDto>>> GetAll()
        {
            var orders = await _orderRepository.GetAllAsync();

            var ordersDto = _mapper.Map<List<OrderGetDto>>(orders);

            return Ok(ordersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGetDto>> GetById(int id)
        {
            var foundOrder = await _orderRepository.GetByIdAsync(id);

            if (foundOrder == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderGetDto>(foundOrder);

            return Ok(orderDto);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<OrderGetDto>> Patch([FromRoute] int id, [FromBody] OrderPatchDto orderPatch)
        {
            var foundOrder = await _orderRepository.GetByIdAsync(id);

            if (foundOrder == null)
            {
                return NotFound();
            }

            var ticketCategory = await _ticketCategoryRepository.GetByIdAsync(orderPatch.TicketCategoryId);

            if (ticketCategory == null)
            {
                return BadRequest();
            }

            if (ticketCategory.EventId != (foundOrder.TicketCategory?.EventId ?? 0)) 
            {
                return BadRequest();
            }

            foundOrder.TicketCategory = ticketCategory;
            foundOrder.NumberOfTickets = orderPatch.NumberOfTickets;
            foundOrder.TotalPrice = foundOrder.NumberOfTickets * ticketCategory.Price;
            var updatedOrder = await _orderRepository.UpdateAsync(foundOrder);

            var orderGetDto = _mapper.Map<OrderGetDto>(updatedOrder);

            return Ok(orderGetDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var foundOrder = await _orderRepository.GetByIdAsync(id);

            if (foundOrder == null)
            {
                return NotFound();
            }

            await _orderRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
