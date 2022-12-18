using CoalStore.DB.Models;
using CoalStore.Shared.Models.Product;

namespace CoalStore.Services.Factories
{
    public static class ProductFactory
    {
        public static Product CreateProduct(AddSupplyModel model, Supplier supplier)
        {
            var product = new Product
            {
                Supplier = supplier,
                Name = model.Name,
                Price = model.Price,
                UnitsInStock = model.UnitsInStock,
                CoalType = model.CoalType,
            };
            return product;
        }
    }
}
