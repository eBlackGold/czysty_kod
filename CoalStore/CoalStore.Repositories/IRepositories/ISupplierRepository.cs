using CoalStore.DB.Models;

namespace CoalStore.Repositories.IRepositories
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        Task<Supplier> GetSupplierByLogin(string login);
    }
}
