using CoalStore.DB;
using CoalStore.DB.Models;
using CoalStore.Repositories.IRepositories;

namespace CoalStore.Repositories.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context)
            : base(context)
        {
        }
    }
}
