using System.Net;
using System.Security.Claims;
using CoalStore.Shared.Consts;
using CoalStore.Shared.Models;

namespace CoalStore.API.Extensions
{
    public static class HttpContextHelper
    {
        public static int GetUserId(HttpContext httpContext)
        {
            int userId;
            var userIdClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == Codes.ClaimTypes.UserId);
            if (userIdClaim != null)
            {
                userId = int.TryParse(userIdClaim.Value, out userId) ? userId : -1;
                return userId;
            }

            return -1;
        }

        public static string GetUserLogin(HttpContext httpContext)
            => httpContext.User.Claims.FirstOrDefault(c => c.Type == Codes.ClaimTypes.Login)?.Value
            ?? null;

        public static string GetUserRole(HttpContext httpContext)
            => httpContext.User.Claims.FirstOrDefault(c => c.Type == Codes.ClaimTypes.Role)?.Value
            ?? null;

        public static Task WriteErrorResponse(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            var error = new ErrorDetailsModel
            {
                StatusCode = context.Response.StatusCode,
                Message = message,
            };

            return context.Response.WriteAsync(error.ToString());
        }

        public static int GetSessionId(HttpContext httpContext)
        {
            int userId;
            var userIdClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == Codes.ClaimTypes.SessionId);
            if (userIdClaim != null)
            {
                userId = int.TryParse(userIdClaim.Value, out userId) ? userId : -1;
                return userId;
            }

            return -1;
        }
    }
}
