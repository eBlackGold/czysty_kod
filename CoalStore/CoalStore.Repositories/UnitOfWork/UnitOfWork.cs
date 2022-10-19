using CoalStore.DB;
using CoalStore.Repositories.IRepositories;
using CoalStore.Repositories.Repositories;

namespace CoalStore.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            User = new UserRepository(context);
        }

        public IUserRepository User { get; }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
