namespace CoalStore.Repositories.IRepositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetById(int id);

        Task DisposeContext();
    }
}
