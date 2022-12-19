using CoalStore.DB.Models;
using CoalStore.Shared.Models.Order;

namespace CoalStore.Services.Validators
{
    public static class OrderValidator
    {
        public static void ValidateProductSupply(Product product, ProductOrderModel productOrder)
        {
            if (productOrder.Quantity > product.UnitsInStock)
            {
                throw new Exception("Nie ma tyle węgla");
            }
        }
    }
}
