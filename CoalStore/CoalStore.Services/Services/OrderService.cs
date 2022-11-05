using System.Collections.Generic;
using System.Runtime.InteropServices;
using CoalStore.Converters.Converters;
using CoalStore.DB.Models;
using CoalStore.Repositories.UnitOfWork;
using CoalStore.Services.IServices;
using CoalStore.Shared.Consts;
using CoalStore.Shared.Models.Order;
using Microsoft.Extensions.Configuration;

namespace CoalStore.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<OrderHistoryModel>> GetOrderHistoryForUser(string userLogin, string userRole)
        {
            List<Order> orderHistory;
            if (userRole == UserRole.Customer)
            {
                orderHistory = (await _unitOfWork.Order.GetOrderHistoryForCustomerByLogin(userLogin)).ToList();
            }
            else
            {
                orderHistory = (await _unitOfWork.Order.GetOrderHistoryForSupplierByLogin(userLogin)).ToList();
            }

            return OrderConverter.ConvertToOrderHistoryModel(orderHistory);
        }

        public async Task SubmitOrder(SubmitOrderModel model)
        {
            var productIds = model.ProductOrderModels.Select(p => p.ProductId).ToList();
            var productsToBuy = await _unitOfWork.Product.GetProductsByIds(productIds);
            UpdateProductStock(productsToBuy, model.ProductOrderModels);
            var order = await CreateNewOrder(model.Login);
            await CreateOrderDetails(order, model.ProductOrderModels);
        }

        private async Task<Order> CreateNewOrder(string login)
        {
            var customer = await _unitOfWork.Customer.GetCustomerByLogin(login);
            var order = new Order
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Paid,
            };
            await _unitOfWork.Order.AddAndComplete(order);
            return order;
        }

        private async Task CreateOrderDetails(Order order, ICollection<ProductOrderModel> productOrders)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var productOrder in productOrders)
            {
                orderDetails.Add(new OrderDetail
                {
                    Order = order,
                    ProductId = productOrder.ProductId,
                    Quantity = productOrder.Quantity,
                });
            }

            await _unitOfWork.OrderDetail.AddRangeAndComplete(orderDetails);
        }

        private void UpdateProductStock(ICollection<Product> productsToBuy, ICollection<ProductOrderModel> productOrders)
        {
            foreach (var product in productsToBuy)
            {
                var productOrder = productOrders.Where(o => o.ProductId == product.Id).FirstOrDefault();
                ValidateProductSupply(product, productOrder);
                product.UnitsInStock -= productOrder.Quantity;
            }
        }

        private void ValidateProductSupply(Product product, ProductOrderModel productOrder)
        {
            if (productOrder.Quantity > product.UnitsInStock)
            {
                throw new Exception("Nie ma tyle węgla");
            }
        }
    }
}
