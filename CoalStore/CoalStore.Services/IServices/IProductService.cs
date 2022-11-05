using CoalStore.Shared.Models.Product;

namespace CoalStore.Services.IServices
{
    public interface IProductService
    {
        Task<List<ProductSupplyModel>> GetProductsForSupplier(string login);

        Task<List<ProductSupplyModel>> GetAllCurrentSupply();

        Task AddProduct(AddSupplyModel model);
    }
}
