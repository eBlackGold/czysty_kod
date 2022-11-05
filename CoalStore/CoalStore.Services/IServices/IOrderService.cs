using CoalStore.Shared.Models.Order;

namespace CoalStore.Services.IServices
{
    public interface IOrderService
    {
        Task<ICollection<OrderHistoryModel>> GetOrderHistoryForUser(string userLogin, string userRole);

        Task SubmitOrder(SubmitOrderModel model);
    }
}
