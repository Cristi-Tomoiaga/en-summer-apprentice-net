namespace TicketsNetBackend.Repositories
{
    public interface IRepositoryAsync<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class where TId : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(TId id);

        Task<TEntity> SaveAsync(TEntity e);

        Task<TEntity?> UpdateAsync(TEntity e);

        Task DeleteAsync(TId id);
    }
}
