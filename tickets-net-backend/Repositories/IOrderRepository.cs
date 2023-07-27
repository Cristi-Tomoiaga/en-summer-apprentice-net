using tickets_net_backend.Models;

namespace tickets_net_backend.Repositories
{
    public interface IOrderRepository : IRepositoryAsync<Order, int>
    {
    }
}
