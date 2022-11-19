using CoalStore.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CoalStore.API.Filters
{
    public class CoalStoreAuthorizeAttribute : TypeFilterAttribute
    {
        public CoalStoreAuthorizeAttribute(AuthorizationPermissionLevel permissionLevel)
            : base(typeof(CoalStoreAuthorizeAttributeFilter))
        {
            Arguments = new object[] { permissionLevel };
        }
    }
}
