using TicketsNetBackend.Models;

namespace TicketsNetBackend.Repositories
{
    public interface IEventRepository : IRepositoryAsync<Event, int>
    {
    }
}
