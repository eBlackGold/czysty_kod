using CoalStore.DB.Models;

namespace CoalStore.Repositories.IRepositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<ICollection<Order>> GetOrderHistoryForCustomerByLogin(string login);

        Task<ICollection<Order>> GetOrderHistoryForSupplierByLogin(string login);
    }
}
