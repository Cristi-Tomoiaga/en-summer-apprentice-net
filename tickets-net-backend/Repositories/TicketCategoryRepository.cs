using Microsoft.EntityFrameworkCore;
using tickets_net_backend.Models;

namespace tickets_net_backend.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly TicketsSystemContext _dbContext;

        public TicketCategoryRepository(TicketsSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public TicketCategory? GetById(int id)
        {
            var foundTicketCategory = _dbContext.TicketCategories
                                                .Include(tc => tc.Event)
                                                .Where(tc => tc.TicketCategoryId == id)
                                                .FirstOrDefault();

            return foundTicketCategory;
        }

        public TicketCategory Save(TicketCategory e)
        {
            throw new NotImplementedException();
        }

        public TicketCategory? Update(TicketCategory e)
        {
            throw new NotImplementedException();
        }
    }
}
