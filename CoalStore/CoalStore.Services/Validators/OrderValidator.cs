using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoalStore.Services.Validators
{
    static class OrderValidator
    {
        private static void ValidateProductSupply(Product product, ProductOrderModel productOrder)
        {
            if (productOrder.Quantity > product.UnitsInStock)
            {
                throw new Exception("Nie ma tyle węgla");
            }
        }
    }
}
