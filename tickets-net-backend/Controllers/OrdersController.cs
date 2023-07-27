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

        public OrdersController(IOrderRepository orderRepository, ITicketCategoryRepository ticketCategoryRepository)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
        }

        [HttpGet]
        public ActionResult<List<OrderGetDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var ordersDto = orders.Select(o => new OrderGetDto
            {
                EventId = o.TicketCategory?.EventId ?? 0,
                TicketCategoryId = o.TicketCategoryId ?? 0,
                Timestamp = o.OrderedAt ?? DateTime.Now,
                NumberOfTickets = o.NumberOfTickets ?? 0,
                TotalPrice = o.TotalPrice ?? 0m,
            });

            return Ok(ordersDto);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderGetDto> GetById(int id)
        {
            var foundOrder = _orderRepository.GetById(id);

            if (foundOrder == null)
            {
                return NotFound();
            }

            var orderDto = new OrderGetDto
            {
                EventId = foundOrder.TicketCategory?.EventId ?? 0,
                TicketCategoryId = foundOrder.TicketCategoryId ?? 0,
                Timestamp = foundOrder.OrderedAt ?? DateTime.Now,
                NumberOfTickets = foundOrder.NumberOfTickets ?? 0,
                TotalPrice = foundOrder.TotalPrice ?? 0m,
            };

            return Ok(orderDto);
        }

        [HttpPatch("{id}")]
        public ActionResult<OrderGetDto> Patch([FromRoute] int id, [FromBody] OrderPatchDto orderPatch)
        {
            var foundOrder = _orderRepository.GetById(id);

            if (foundOrder == null)
            {
                return NotFound();
            }

            var ticketCategory = _ticketCategoryRepository.GetById(orderPatch.TicketCategoryId);

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
            var updatedOrder = _orderRepository.Update(foundOrder);

            var orderGetDto = new OrderGetDto
            {
                EventId = updatedOrder?.TicketCategory?.EventId ?? 0,
                TicketCategoryId = updatedOrder?.TicketCategoryId ?? 0,
                Timestamp = updatedOrder?.OrderedAt ?? DateTime.Now,
                NumberOfTickets = updatedOrder?.NumberOfTickets ?? 0,
                TotalPrice = updatedOrder?.TotalPrice ?? 0m,
            };

            return Ok(orderGetDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var foundOrder = _orderRepository.GetById(id);

            if (foundOrder == null)
            {
                return NotFound();
            }

            _orderRepository.Delete(id);

            return NoContent();
        }
    }
}
