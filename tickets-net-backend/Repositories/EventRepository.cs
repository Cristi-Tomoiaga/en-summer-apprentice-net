using Microsoft.EntityFrameworkCore;
using TicketsNetBackend.Models;

namespace TicketsNetBackend.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketsSystemContext _dbContext;

        public EventRepository(TicketsSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            return GetAllAsync().Result;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var events = await _dbContext.Events
                                   .Include(e => e.Venue)
                                   .Include(e => e.EventType)
                                   .Include(e => e.TicketCategories)
                                   .ToListAsync();

            return events;
        }

        public Event? GetById(int id)
        {
            return GetByIdAsync(id).Result;
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            var foundEvent = await _dbContext.Events
                                       .Include(e => e.Venue)
                                       .Include(e => e.EventType)
                                       .Include(e => e.TicketCategories)
                                       .FirstOrDefaultAsync(e => e.EventId == id);

            return foundEvent;
        }

        public Event Save(Event e)
        {
            throw new NotImplementedException();
        }

        public Task<Event> SaveAsync(Event e)
        {
            throw new NotImplementedException();
        }

        public Event? Update(Event e)
        {
            throw new NotImplementedException();
        }

        public Task<Event?> UpdateAsync(Event e)
        {
            throw new NotImplementedException();
        }
    }
}
