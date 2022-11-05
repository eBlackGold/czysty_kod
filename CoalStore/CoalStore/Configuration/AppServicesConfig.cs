using CoalStore.Repositories.UnitOfWork;
using CoalStore.Services.IServices;
using CoalStore.Services.Services;

namespace CoalStore.API.Configuration
{
    internal static class AppServicesConfig
    {
        internal static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
