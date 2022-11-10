using CoalStore.DB;
using CoalStore.DB.Models;
using CoalStore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CoalStore.Repositories.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDBContext context)
            : base(context)
        {
        }

        public async Task<Customer> GetCustomerByLogin(string login)
        {
            var result = await _context.Customers
                .Where(u => u.Login == login)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
