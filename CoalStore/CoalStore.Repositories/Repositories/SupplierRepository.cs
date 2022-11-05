using CoalStore.DB.Models;
using CoalStore.DB;
using CoalStore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CoalStore.Repositories.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDBContext context)
        : base(context)
        {
        }

        public async Task<Supplier> GetSupplierByLogin(string login)
        {
            return await _context.Suppliers
                .Where(u => u.Login == login)
                .FirstOrDefaultAsync();
        }
    }
}
