
namespace TicketsNetBackend.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : class 
                                               where TId : struct
    {
        IEnumerable<TEntity> GetAll();

        TEntity? GetById(TId id);

        TEntity Save(TEntity e);

        TEntity? Update(TEntity e);

        void Delete(TId id);
    }
}
