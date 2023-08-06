using AutoMapper;
using tickets_net_backend.Exceptions;
using tickets_net_backend.Models;
using tickets_net_backend.Models.Dto;
using tickets_net_backend.Repositories;

namespace tickets_net_backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, ITicketCategoryRepository ticketCategoryRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            var foundOrder = await _orderRepository.GetByIdAsync(id);
            if (foundOrder == null)
            {
                throw new EntityNotFoundException(id, nameof(Order));
            }

            await _orderRepository.DeleteAsync(id);
        }

        public async Task<List<OrderGetDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            var ordersDto = _mapper.Map<List<OrderGetDto>>(orders);
            return ordersDto;
        }

        public async Task<OrderGetDto> GetByIdAsync(int id)
        {
            var foundOrder = await _orderRepository.GetByIdAsync(id);
            if (foundOrder == null)
            {
                throw new EntityNotFoundException(id, nameof(Order));
            }

            var orderDto = _mapper.Map<OrderGetDto>(foundOrder);
            return orderDto;
        }

        public async Task<OrderGetDto> PatchAsync(int id, OrderPatchDto orderPatch)
        {
            var foundOrder = await _orderRepository.GetByIdAsync(id);
            if (foundOrder == null)
            {
                throw new InvalidIdException(id, nameof(Order));
            }

            var numberOfTickets = orderPatch.NumberOfTickets;
            if (numberOfTickets <= 0)
            {
                throw new InvalidNumberOfTickets(numberOfTickets);
            }

            var ticketCategory = await _ticketCategoryRepository.GetByIdAsync(orderPatch.TicketCategoryId);
            if (ticketCategory == null)
            {
                throw new InvalidIdException(orderPatch.TicketCategoryId, nameof(TicketCategory));
            }

            var eventId = foundOrder.TicketCategory?.EventId ?? 0;
            if (ticketCategory.EventId != eventId)
            {
                throw new InvalidTicketCategoryException(orderPatch.TicketCategoryId, eventId);
            }

            foundOrder.TicketCategory = ticketCategory;
            foundOrder.NumberOfTickets = orderPatch.NumberOfTickets;
            foundOrder.TotalPrice = foundOrder.NumberOfTickets * ticketCategory.Price;
            var updatedOrder = await _orderRepository.UpdateAsync(foundOrder);

            var orderGetDto = _mapper.Map<OrderGetDto>(updatedOrder);
            return orderGetDto;
        }
    }
}
