using CoalStore.DB;
using CoalStore.DB.Models;
using CoalStore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CoalStore.Repositories.Repositories
{
    public class UserSessionRepository : BaseRepository<UserSession>, IUserSessionRepository
    {
        public UserSessionRepository(ApplicationDBContext context)
            : base(context)
        {
        }

        public async Task<UserSession> GetByUserIdAndRole(int userId, string userRole)
        {
            return await _context.UserSessions
                .Where(us => us.UserRole == userRole && us.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetSessionIdByUserIdAndRole(int userId, string userRole)
        {
            return await _context.UserSessions
                .Where(us => us.UserRole == userRole && us.UserId == userId)
                .Select(us => us.Id)
                .FirstOrDefaultAsync();
        }
    }
}
