using Microsoft.OpenApi.Models;

namespace CoalStore.API.Configuration.Swagger
{
    internal static class SwaggerConfig
    {
        internal static void Configure(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "eBlackGold.API",
                    Description = "API aplikacji eBlackGold",
                    Contact = new OpenApiContact
                    {
                        Name = "eBlackGold",
                        Email = string.Empty,
                        Url = new Uri("https://www.ue.katowice.pl/"),
                    },
                });

                c.CustomSchemaIds(type => type.FullName);
                c.OperationFilter<SwaggerAjaxRequestHeaderConfiguration>();
            });
        }
    }
}
