using CoalStore.DB;
using CoalStore.DB.Models;
using CoalStore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CoalStore.Repositories.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDBContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Order>> GetOrderHistoryForCustomerByLogin(string login)
        {
            return await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Where(o => o.Customer.Login == login)
                .ToListAsync();
        }

        public async Task<ICollection<Order>> GetOrderHistoryForSupplierByLogin(string login)
        {
            return await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Where(o => o.OrderDetails.Any(od => od.Product.Supplier.Login == login))
                .ToListAsync();
        }
    }
}
