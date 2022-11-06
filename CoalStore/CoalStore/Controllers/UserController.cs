using CoalStore.Services.IServices;
using CoalStore.Shared.Models.Order;
using CoalStore.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoalStore.Shared.Models.User;
using CoalStore.Shared.Consts;

namespace CoalStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Register customer
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns></returns>
        [HttpPost("register-customer")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterUserModel model)
        {
            await _userService.RegisterUser(model, UserRole.Customer);
            return Ok();
        }

        /// <summary>
        /// Register supplier
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns></returns>
        [HttpPost("register-supplier")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RegisterSupplier([FromBody] RegisterUserModel model)
        {
            await _userService.RegisterUser(model, UserRole.Supplier);
            return Ok();
        }

        /// <summary>
        /// Edit supplier
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns></returns>
        [HttpPost("edit-supplier")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> EditSupplier([FromBody] EditSupplierModel model)
        {
            await _userService.EditUser(model, UserRole.Supplier);
            return Ok();
        }

        /// <summary>
        /// Edit customer
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns></returns>
        [HttpPost("edit-customer")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> EditCustomer([FromBody] EditCustomerModel model)
        {
            await _userService.EditUser(model, UserRole.Customer);
            return Ok();
        }
    }
}
