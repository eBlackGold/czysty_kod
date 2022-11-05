using CoalStore.DB.Models;

namespace CoalStore.Repositories.IRepositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetCustomerByLogin(string login);
    }
}
