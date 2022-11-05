using CoalStore.DB;
using CoalStore.DB.Models;
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
            Customer = new CustomerRepository(context);
            Order = new OrderRepository(context);
            OrderDetail = new OrderDetailRepository(context);
            Product = new ProductRepository(context);
            Supplier = new SupplierRepository(context);
        }

        public ICustomerRepository Customer { get; }

        public IOrderRepository Order { get; }

        public IOrderDetailRepository OrderDetail { get; }

        public IProductRepository Product { get; }

        public ISupplierRepository Supplier { get; }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
