using TicketsNetBackend.Models;

namespace TicketsNetBackend.Repositories
{
    public interface IOrderRepository : IRepositoryAsync<Order, int>
    {
    }
}
