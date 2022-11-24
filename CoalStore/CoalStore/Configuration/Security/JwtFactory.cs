using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoalStore.API.Configuration.Security
{
    internal sealed class JwtFactory : IJwtFactory
    {
        private SecurityKey _securityKey;
        private string _issuer;
        private string _audience;
        private JwtSecurityTokenHandler _handler;

        public JwtFactory(IConfiguration configuration)
        {
            var key = configuration.GetValue<string>("Auth:Jwt:Key");
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            _issuer = configuration.GetValue<string>("Auth:Jwt:Issuer");
            _audience = configuration.GetValue<string>("Auth:Jwt:Audience");
            _handler = new JwtSecurityTokenHandler();
        }

        public string CreateToken(IEnumerable<Claim> claims, DateTime expirationDate)
        {
            var signinCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    expires: expirationDate,
                    signingCredentials: signinCredentials);

            return _handler.WriteToken(token);
        }
    }
}
