using CoalStore.DB.Models;
using CoalStore.Shared.Models.Order;

namespace CoalStore.Converters.Converters
{
    public static class OrderConverter
    {
        public static List<OrderHistoryModel> ConvertToOrderHistoryModel(List<Order> orders)
        {
            List<OrderHistoryModel> historyModels = new List<OrderHistoryModel>();
            foreach (var order in orders)
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    historyModels.Add(new OrderHistoryModel
                {
                    ProductName = orderDetail.Product.Name,
                    Quantity = orderDetail.Quantity,
                    Status = order.Status,
                    OrderPrice = orderDetail.Quantity * orderDetail.Product.Price,
                });
                }
            }

            return historyModels;
        }
    }
}
