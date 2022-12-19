using CoalStore.Converters.Converters;
using CoalStore.Repositories.UnitOfWork;
using CoalStore.Services.IServices;
using CoalStore.Shared.Models.Product;
using CoalStore.Services.Factories;

namespace CoalStore.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
    }

        public async Task<List<ProductSupplyModel>> GetProductsForSupplier(string login)
        {
            var products = await _unitOfWork.Product.GetProductsForLogin(login);
            return ProductConverter.ConvertToProductSupplyModel(products);
        }

        public async Task<List<ProductSupplyModel>> GetAllCurrentSupply()
        {
            var products = await _unitOfWork.Product.GetAllCurrentSupply();
            return ProductConverter.ConvertToProductSupplyModel(products);
        }

        public async Task AddProduct(AddSupplyModel model)
        {
            var supplier = await _unitOfWork.Supplier.GetSupplierByLogin(model.Login);
            var product = ProductFactory.CreateProduct(model, supplier);
            await _unitOfWork.Product.AddAndComplete(product);
        }
    }
}
