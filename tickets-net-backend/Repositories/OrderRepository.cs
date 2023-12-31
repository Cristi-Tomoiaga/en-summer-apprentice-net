﻿using Microsoft.EntityFrameworkCore;
using tickets_net_backend.Models;

namespace tickets_net_backend.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TicketsSystemContext _dbContext;

        public OrderRepository(TicketsSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            DeleteAsync(id).Wait();
        }

        public async Task DeleteAsync(int id)
        {
            var foundOrder = await GetByIdAsync(id);

            if (foundOrder == null)
            {
                return;
            }

            _dbContext.Orders.Remove(foundOrder);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return GetAllAsync().Result;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _dbContext.Orders
                                   .Include(o => o.TicketCategory)
                                   .Include(o => o.TicketCategory.Event)
                                   .Include(o => o.TicketCategory.Event.Venue)
                                   .Include(o => o.TicketCategory.Event.EventType)
                                   .Include(o => o.TicketCategory.Event.TicketCategories)
                                   .ToListAsync();

            return orders;
        }

        public Order? GetById(int id)
        {
            return GetByIdAsync(id).Result;
        }

        public Task<Order?> GetByIdAsync(int id)
        {
            var foundOrder = _dbContext.Orders
                                       .Include(o => o.TicketCategory)
                                       .Include(o => o.TicketCategory.Event)
                                       .Include(o => o.TicketCategory.Event.Venue)
                                       .Include(o => o.TicketCategory.Event.EventType)
                                       .Include(o => o.TicketCategory.Event.TicketCategories)
                                       .Where(o => o.OrderId == id)
                                       .FirstOrDefaultAsync();

            return foundOrder;
        }

        public Order Save(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> SaveAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Order? Update(Order order)
        {
            return UpdateAsync(order).Result;
        }

        public async Task<Order?> UpdateAsync(Order order)
        {
            var foundOrder = await GetByIdAsync(order.OrderId);

            if (foundOrder == null)
            {
                return null;
            }

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();

            var updatedOrder = await GetByIdAsync(order.OrderId);
            _dbContext.Events.Entry(updatedOrder.TicketCategory.Event).Reload();
            return updatedOrder;
        }
    }
}
