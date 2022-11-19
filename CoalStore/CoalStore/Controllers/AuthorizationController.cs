using CoalStore.Shared.Models;
using CoalStore.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoalStore.Shared.Models.Authorization;
using System.Security.Claims;
using CoalStore.Shared.Consts;
using CoalStore.API.Configuration.Security;
using CoalStore.Shared.Enums;
using CoalStore.API.Filters;
using CoalStore.API.Extensions;

namespace CoalStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtFactory _jwtFactory;
        private readonly int tokenValidityInMinutes = 240;

        public AuthorizationController(IAuthService authorizationService, IJwtFactory jwtFactory)
        {
            _authService = authorizationService;
            _jwtFactory = jwtFactory;
        }

        /// <summary>
        /// Generates JWT token
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns>Ok - JWT token</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthorizationResultModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] AuthorizationModel model)
        {
            var isAuthenticated = await _authService.IsPasswordValid(model);
            if (!isAuthenticated)
            {
                throw new Exception("Nieprawidłowy login lub hasło");
            }
            await _authService.CreateSession(model);
            var sessionId = await _authService.GetSessionId(model);
            var userClaims = await _authService.GetUserClaims(model, sessionId);

            var userId = int.Parse(userClaims.Where(c => c.Type == Codes.ClaimTypes.UserId).First().Value);
            DateTime dateTo = DateTime.Now.AddMinutes(tokenValidityInMinutes);
            var tokenString = _jwtFactory.CreateToken(userClaims, dateTo);
            var result = new AuthorizationResultModel(
                    dateTo,
                    userClaims.Select(c => new ClaimResult(c.Type, c.Value)),
                    tokenString);
            return Ok(result);
        }

        /// <summary>
        /// Deletes session
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns>Ok</returns>
        [HttpPost("log-out")]
        [CoalStoreAuthorize(AuthorizationPermissionLevel.AnyUser)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Logout()
        {
            var userLogin = HttpContextHelper.GetUserLogin(HttpContext);
            var userRole = HttpContextHelper.GetUserRole(HttpContext);
            await _authService.ClearSession(userLogin, userRole);
            return Ok();
        }
    }
}
