using CoalStore.DB;
using CoalStore.Repositories.IRepositories;

namespace CoalStore.Repositories.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
    {
        protected readonly ApplicationDBContext _context;

        public BaseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task DisposeContext()
        {
            await _context.DisposeAsync();
        }
    }
}
