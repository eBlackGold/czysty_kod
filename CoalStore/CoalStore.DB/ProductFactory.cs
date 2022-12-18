using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoalStore.Services.Factories
{
    static class ProductFactory
    {
        public static async Task<Product> AddProduct(AddSupplyModel model, Supplier supplier)
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
