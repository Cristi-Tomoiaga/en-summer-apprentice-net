using tickets_net_backend.Models;

namespace tickets_net_backend.Repositories
{
    public interface ITicketCategoryRepository : IRepositoryAsync<TicketCategory, int>
    {
    }
}
