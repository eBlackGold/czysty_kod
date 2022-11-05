using CoalStore.DB;
using CoalStore.DB.Models;
using CoalStore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CoalStore.Repositories.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDBContext context)
            : base(context)
        {
        }
    }
}
