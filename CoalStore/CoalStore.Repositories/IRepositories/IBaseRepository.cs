namespace CoalStore.Repositories.IRepositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetById(int id);

        Task AddAndComplete(TEntity entity);

        Task UpdateAndComplete(TEntity entity);

        Task AddRangeAndComplete(IEnumerable<TEntity> entities);

        Task Remove(TEntity entity);

        Task DisposeContext();
    }
}
