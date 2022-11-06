using CoalStore.DB.Models;

namespace CoalStore.Repositories.IRepositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<ICollection<Product>> GetProductsForLogin(string login);

        Task<ICollection<Product>> GetAllCurrentSupply();

        Task<ICollection<Product>> GetProductsByIds(ICollection<int> productsIds);
    }
}
