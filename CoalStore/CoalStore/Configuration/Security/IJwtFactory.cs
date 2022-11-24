using System.Security.Claims;

namespace CoalStore.API.Configuration.Security
{
    /// <summary>
    /// Factory of Json Web Tokens
    /// </summary>
    public interface IJwtFactory
    {
        /// <summary>
        /// Creates new token based on parameters
        /// </summary>
        /// <param name="claims">Claims to add in token</param>
        /// <param name="expirationDate">Token expiration date</param>
        /// <returns></returns>
        string CreateToken(IEnumerable<Claim> claims, DateTime expirationDate);
    }
}
