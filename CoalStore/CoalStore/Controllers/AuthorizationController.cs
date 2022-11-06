using CoalStore.DB.Models;
using CoalStore.Shared.Models;
using CoalStore.Services.IServices;
using CoalStore.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoalStore.Shared.Models.Order;
using CoalStore.Shared.Models.Authorization;

namespace CoalStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthorizationController(IAuthService authorizationService)
        {
            _authService = authorizationService;
        }

        /// <summary>
        /// Generates JWT token
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns>Ok - JWT token</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] AuthorizationModel model)
        {
            var isAuthenticated = await _authService.IsPasswordValid(model);
            return Ok();
        }

        /// <summary>
        /// Deletes session
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns>Ok</returns>
        [HttpPost("log-out")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Logout([FromBody] AuthorizationModel model)
        {
            return Ok();
        }
    }
}
