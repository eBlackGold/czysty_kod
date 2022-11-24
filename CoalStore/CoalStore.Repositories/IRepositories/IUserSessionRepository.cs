using CoalStore.DB.Models;

namespace CoalStore.Repositories.IRepositories
{
    public interface IUserSessionRepository : IBaseRepository<UserSession>
    {
        Task<UserSession> GetByUserIdAndRole(int userId, string userRole);

        Task<int> GetSessionIdByUserIdAndRole(int userId, string userRole);
    }
}
