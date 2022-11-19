using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CoalStore.API.Configuration.Security
{
    internal static class JwtConfig
    {
        private const string AuthorizationHeader = "Authorization";
        private const string Bearer = "Bearer";

        internal static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = context =>
                            {
                                context.Token = (context.Request.Headers.ContainsKey(AuthorizationHeader)
                                    ? context.Request.Headers[AuthorizationHeader].FirstOrDefault().Replace(Bearer, string.Empty).Trim()
                                    : string.Empty);
                                return Task.CompletedTask;
                            },
                        };

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            RequireSignedTokens = true,
                            RequireExpirationTime = true,
                            ClockSkew = TimeSpan.Zero,
                            LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken token, TokenValidationParameters @params) =>
                            {
                                var exp = DateTimeOffset.FromUnixTimeSeconds((token as JwtSecurityToken).Claims
                                    .Where(c => c.Type.Equals("exp"))
                                    .Select(c => Convert.ToInt32(c.Value))
                                    .FirstOrDefault()).DateTime;

                                return exp > DateTime.UtcNow;
                            },

                            ValidIssuer = configuration["Auth:Jwt:Issuer"],
                            ValidAudience = configuration["Auth:Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:Jwt:Key"])),
                        };
                    });
            services.AddSingleton<IJwtFactory>(sp => new JwtFactory(configuration));
        }
    }
}
