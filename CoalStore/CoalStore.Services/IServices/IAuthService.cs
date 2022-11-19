using System.Security.Claims;
using CoalStore.Shared.Models.Authorization;

namespace CoalStore.Services.IServices
{
    public interface IAuthService
    {
        Task<bool> IsPasswordValid(AuthorizationModel model);

        Task CreateSession(AuthorizationModel model);

        Task ClearSession(string login, string role);

        Task<List<Claim>> GetUserClaims(AuthorizationModel model, int sessionId);

        Task<int> GetSessionId(AuthorizationModel model);
    }
}
