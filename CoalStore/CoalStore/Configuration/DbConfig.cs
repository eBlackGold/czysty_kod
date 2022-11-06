using CoalStore.DB;
using Microsoft.EntityFrameworkCore;

namespace CoalStore.API.Configuration
{
    internal static class DbConfig
    {
        internal static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
