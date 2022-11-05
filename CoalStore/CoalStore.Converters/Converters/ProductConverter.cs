using CoalStore.DB.Models;
using CoalStore.Shared.Models.Product;

namespace CoalStore.Converters.Converters
{
    public static class ProductConverter
    {
        public static List<ProductSupplyModel> ConvertToProductSupplyModel(ICollection<Product> products)
        {
            List<ProductSupplyModel> productSupplyModels = new List<ProductSupplyModel>();
            foreach (var product in products)
            {
                productSupplyModels.Add(new ProductSupplyModel
                {
                    Id = product.Id,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = product.UnitsInStock,
                    CoalType = product.CoalType,
                });
            }

            return productSupplyModels;
        }
    }
}
