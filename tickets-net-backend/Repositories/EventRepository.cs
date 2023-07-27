using Microsoft.EntityFrameworkCore;
using tickets_net_backend.Models;

namespace tickets_net_backend.Repositories
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

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events
                                   .Include(e => e.Venue)
                                   .Include(e => e.EventType);

            return events;
        }

        public Event? GetById(int id)
        {
            var foundEvent = _dbContext.Events
                                       .Include(e => e.Venue)
                                       .Include(e => e.EventType)
                                       .Where(e => e.EventId == id)
                                       .FirstOrDefault();

            return foundEvent;
        }

        public Event Save(Event e)
        {
            throw new NotImplementedException();
        }

        public Event? Update(Event e)
        {
            throw new NotImplementedException();
        }
    }
}
