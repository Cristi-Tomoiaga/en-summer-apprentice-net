using tickets_net_backend.Models;

namespace tickets_net_backend.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Event? GetById(int id);

        Event Save(Event e);

        Event Update(Event e);

        void Delete(int id);
    }
}
