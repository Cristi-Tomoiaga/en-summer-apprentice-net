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

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TicketCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TicketCategory? GetById(int id)
        {
            return GetByIdAsync(id).Result;
        }

        public async Task<TicketCategory?> GetByIdAsync(int id)
        {
            var foundTicketCategory = await _dbContext.TicketCategories
                                                .Include(tc => tc.Event)
                                                .Where(tc => tc.TicketCategoryId == id)
                                                .FirstOrDefaultAsync();

            return foundTicketCategory;
        }

        public TicketCategory Save(TicketCategory e)
        {
            throw new NotImplementedException();
        }

        public Task<TicketCategory> SaveAsync(TicketCategory e)
        {
            throw new NotImplementedException();
        }

        public TicketCategory? Update(TicketCategory e)
        {
            throw new NotImplementedException();
        }

        public Task<TicketCategory?> UpdateAsync(TicketCategory e)
        {
            throw new NotImplementedException();
        }
    }
}
