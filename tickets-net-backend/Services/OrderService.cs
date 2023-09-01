using AutoMapper;
using TicketsNetBackend.Exceptions;
using TicketsNetBackend.Models;
using TicketsNetBackend.Models.Dto;
using TicketsNetBackend.Repositories;

namespace TicketsNetBackend.Services
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

        public async Task DeleteAsync(int id, int customerId)
        {
            var foundOrder = await _orderRepository.GetByIdAsync(id);
            if (foundOrder == null)
            {
                throw new EntityNotFoundException(id, nameof(Order));
            }

            if (foundOrder.CustomerId != customerId)
            {
                throw new OwnershipException(customerId, id);
            }

            await _orderRepository.DeleteAsync(id);
        }

        public async Task<OrdersDto> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            var ordersDto = _mapper.Map<OrdersDto>(orders);
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

        public async Task<OrderGetDto> PatchAsync(int id, int customerId, OrderPatchDto orderPatch)
        {
            var foundOrder = await GetOrderAsync(id);
            CheckOrderOwnership(foundOrder, customerId);

            var ticketCategory = await GetTicketCategoryAsync(orderPatch.TicketCategoryId);

            var eventId = foundOrder.TicketCategory?.EventId ?? 0;
            CheckTicketCategoryAvailability(ticketCategory, eventId);

            var numberOfTickets = orderPatch.NumberOfTickets;
            ValidateNumberOfTickets(foundOrder, numberOfTickets, eventId);
 
            var updatedOrder = await ApplyUpdatesToOrder(foundOrder, ticketCategory, numberOfTickets);

            var orderGetDto = _mapper.Map<OrderGetDto>(updatedOrder);
            return orderGetDto;
        }

        private async Task<Order> GetOrderAsync(int id)
        {
            var foundOrder = await _orderRepository.GetByIdAsync(id);
            if (foundOrder == null)
            {
                throw new InvalidIdException(id, nameof(Order));
            }

            return foundOrder;
        }

        private async Task<TicketCategory> GetTicketCategoryAsync(int id)
        {
            var ticketCategory = await _ticketCategoryRepository.GetByIdAsync(id);
            if (ticketCategory == null)
            {
                throw new InvalidIdException(id, nameof(TicketCategory));
            }

            return ticketCategory;
        }

        private static void CheckOrderOwnership(Order order, int customerId)
        {
            if (order.CustomerId != customerId)
            {
                throw new OwnershipException(customerId, order.OrderId);
            }
        }

        private static void CheckTicketCategoryAvailability(TicketCategory ticketCategory, int eventId)
        {
            if (ticketCategory.EventId != eventId)
            {
                throw new InvalidTicketCategoryException(ticketCategory.TicketCategoryId, eventId);
            }
        }

        private static void ValidateNumberOfTickets(Order order, int numberOfTickets, int eventId)
        {
            if (numberOfTickets <= 0)
            {
                throw new InvalidNumberOfTicketsException(numberOfTickets);
            }

            var availableSeats = order.TicketCategory?.Event?.AvailableSeats ?? 0;
            if (numberOfTickets > availableSeats)
            {
                throw new UnavailableSeatsException(numberOfTickets, availableSeats, eventId);
            }
        }

        private async Task<Order?> ApplyUpdatesToOrder(Order order, TicketCategory ticketCategory, int numberOfTickets)
        {
            order.TicketCategory = ticketCategory;
            order.NumberOfTickets = numberOfTickets;
            order.TotalPrice = order.NumberOfTickets * ticketCategory.Price;
            var updatedOrder = await _orderRepository.UpdateAsync(order);

            return updatedOrder;
        }
    }
}
