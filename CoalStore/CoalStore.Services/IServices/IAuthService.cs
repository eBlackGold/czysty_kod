using System.Security.Claims;
using CoalStore.Shared.Models.Authorization;

namespace CoalStore.Services.IServices
{
    public interface IAuthService
    {
        Task<bool> IsPasswordValid(AuthorizationModel model);

        Task CreateSession(AuthorizationModel model);

        Task ClearSession(AuthorizationModel model);

        Task<List<Claim>> GetUserClaims(AuthorizationModel model);
    }
}
