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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer",
                                },
                            },
                          new string[] { }
                    },
                });
            });
        }
    }
}
