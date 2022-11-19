using System.Net;
using CoalStore.Repositories.UnitOfWork;
using CoalStore.Shared.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CoalStore.API.Extensions;
using CoalStore.Shared.Consts;
using CoalStore.DB.Models;

namespace CoalStore.API.Filters
{
    public class CoalStoreAuthorizeAttributeFilter : IAuthorizationFilter
    {
        private readonly AuthorizationPermissionLevel _permissionLevel;
        private readonly IUnitOfWork _unitOfWork;

        public CoalStoreAuthorizeAttributeFilter(AuthorizationPermissionLevel authorizationPermissionLevel, IUnitOfWork unitOfWork)
        {
            _permissionLevel = authorizationPermissionLevel;
            _unitOfWork = unitOfWork;
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User?.Identity is null
                || !context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new ForbidResult();
                return;
            }

            var claimValues = context.HttpContext.User.Claims.Select(c => new ClaimValue
            {
                Type = c.Type,
                Value = c.Value,
            }).ToArray();

            var hasPermission = false;
            var userId = HttpContextHelper.GetUserId(context.HttpContext);
            var userLogin = HttpContextHelper.GetUserLogin(context.HttpContext);
            var userRole = HttpContextHelper.GetUserRole(context.HttpContext);
            IUser user = GetUserByLoginAndRole(userLogin, userRole).Result;
            var session = _unitOfWork.UserSession.GetByUserIdAndRole(userId, userRole).Result;
            var claimSessionId = HttpContextHelper.GetSessionId(context.HttpContext);
            hasPermission = CheckPermissionLevel(userRole, _permissionLevel);
            if (!hasPermission)
            {
                context.Result = new ForbidResult();
                await HttpContextHelper.WriteErrorResponse(context.HttpContext, HttpStatusCode.Forbidden, "User unauthorized");
                return;
            }

            if (session is null)
            {
                context.Result = new ForbidResult();
                await HttpContextHelper.WriteErrorResponse(context.HttpContext, HttpStatusCode.Forbidden, "User not authenticated");
                return;
            }

            if (session is { } && claimSessionId != session.Id)
            {
                context.Result = new ForbidResult();
                await HttpContextHelper.WriteErrorResponse(context.HttpContext, HttpStatusCode.Forbidden, "User logged in on different device");
                return;
            }
        }

        private bool CheckPermissionLevel(string userLevel, AuthorizationPermissionLevel authorizationLevel)
        {
            if (userLevel == authorizationLevel.ToString() || authorizationLevel == AuthorizationPermissionLevel.AnyUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<IUser> GetUserByLoginAndRole(string login, string role)
        {
            IUser user;
            if (role == UserRole.Customer)
            {
                user = await _unitOfWork.Customer.GetCustomerByLogin(login);
            }
            else
            {
                user = await _unitOfWork.Supplier.GetSupplierByLogin(login);
            }

            return user;
        }

        private class ClaimValue
        {
            public string Type { get; set; }

            public string Value { get; set; }
        }
    }
}
