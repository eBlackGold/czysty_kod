using CoalStore.DB;
using CoalStore.DB.Models;
using CoalStore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CoalStore.Repositories.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDBContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Product>> GetProductsForLogin(string login)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.Supplier.Login == login)
                .ToListAsync();
        }

        public async Task<ICollection<Product>> GetAllCurrentSupply()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Product>> GetProductsByIds(ICollection<int> productsIds)
        {
            return await _context.Products
                .AsTracking()
                .Where(p => productsIds.Contains(p.Id))
                .ToListAsync();
        }
    }
}
