using Microsoft.EntityFrameworkCore;
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
            var foundOrder = GetById(id);
            
            if (foundOrder == null)
            {
                return;
            }

            _dbContext.Orders.Remove(foundOrder);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders
                                   .Include(o => o.TicketCategory);
                                   // .Include(o => o.TicketCategory.Event);

            return orders;
        }

        public Order? GetById(int id)
        {
            var foundOrder = _dbContext.Orders
                                       .Include(o => o.TicketCategory)
                                       .Where(o => o.OrderId == id)
                                       .FirstOrDefault();

            return foundOrder;
        }

        public Order Save(Order order)
        {
            throw new NotImplementedException();
        }

        public Order? Update(Order order)
        {
            var foundOrder = GetById(order.OrderId);

            if (foundOrder == null) {
                return null;
            }

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
            return order;
        }
    }
}
