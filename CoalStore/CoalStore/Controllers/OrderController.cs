using CoalStore.DB.Models;
using CoalStore.Shared.Models;
using CoalStore.Services.IServices;
using CoalStore.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoalStore.Shared.Models.Order;
using CoalStore.Shared.Consts;
using CoalStore.API.Filters;
using CoalStore.Shared.Enums;

namespace CoalStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Gets order history for customer
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns>list of order history</returns>
        [HttpGet("order-customer-history/{userLogin}")]
        [CoalStoreAuthorize(AuthorizationPermissionLevel.Customer)]
        [ProducesResponseType(typeof(ICollection<OrderHistoryModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCustomerOrderHistory(string userLogin)
        {
            var result = await _orderService.GetOrderHistoryForUser(userLogin, UserRole.Customer);
            return Ok(result);
        }

        /// <summary>
        /// Gets order history for supplier
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns>list of order history</returns>
        [HttpGet("order-supplier-history/{userLogin}")]
        [CoalStoreAuthorize(AuthorizationPermissionLevel.Supplier)]
        [ProducesResponseType(typeof(ICollection<OrderHistoryModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSupplierOrderHistory(string userLogin)
        {
            var result = await _orderService.GetOrderHistoryForUser(userLogin, UserRole.Supplier);
            return Ok(result);
        }

        /// <summary>
        /// Orders products
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns></returns>
        [HttpPost("submit-order")]
        [CoalStoreAuthorize(AuthorizationPermissionLevel.Customer)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SubmitOrder([FromBody] SubmitOrderModel model)
        {
            await _orderService.SubmitOrder(model);
            return Ok();
        }
    }
}
