using CoalStore.Repositories.IRepositories;

namespace CoalStore.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }

        IOrderRepository Order { get; }

        IOrderDetailRepository OrderDetail { get; }

        IProductRepository Product { get; }

        ISupplierRepository Supplier { get; }

        IUserSessionRepository UserSession { get; }

        Task Complete();
    }
}
