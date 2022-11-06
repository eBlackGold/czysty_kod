using CoalStore.Shared.Models.Authorization;

namespace CoalStore.Services.IServices
{
    public interface IAuthService
    {
        Task<bool> IsPasswordValid(AuthorizationModel model);
    }
}
