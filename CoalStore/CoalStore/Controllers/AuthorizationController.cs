using CoalStore.Shared.Models;
using CoalStore.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoalStore.Shared.Models.Authorization;
using System.Security.Claims;
using CoalStore.Shared.Consts;

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
            if (!isAuthenticated)
            {
                throw new Exception("Nieprawidłowy login lub hasło");
            }

            var userClaims = await _authService.GetUserClaims(model);
            var userId = int.Parse(userClaims.Where(c => c.Type == Codes.ClaimTypes.UserId).First().Value);
            AssignSessionToClaims(userId, userClaims);

            await _authService.CreateSession(model);
            return Ok();
        }

        /// <summary>
        /// Deletes session
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns>Ok</returns>
        [HttpPost("log-out")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Logout([FromBody] AuthorizationModel model)
        {
            await _authService.ClearSession(model);
            return Ok();
        }

        private void AssignSessionToClaims(int userId, List<Claim> claimsList)
        {
            //var sessionId = CreateSession(userId);

            //if (HttpContext is null)
            //{
            //    return;
            //}

            //claimsList.Add(new Claim(Codes.ClaimTypes.SessionId, sessionId.ToString()));
        }
    }
}
