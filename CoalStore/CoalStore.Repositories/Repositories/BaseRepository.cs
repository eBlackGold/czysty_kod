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

        public async Task AddAndComplete(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAndComplete(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DisposeContext()
        {
            await _context.DisposeAsync();
        }

        public async Task Remove(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
        }

        public async Task AddRangeAndComplete(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
    }
}
