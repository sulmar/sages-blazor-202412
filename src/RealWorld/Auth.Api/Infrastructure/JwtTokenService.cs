using Auth.Api.Abstractions;
using Auth.Api.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Api.Infrastructure;

public class JwtTokenService : ITokenService
{
    public string CreateAccessToken(UserIdentity identity)
    {
        var claims = new Dictionary<string, object>
        {
            [JwtRegisteredClaimNames.Jti] = Guid.NewGuid().ToString(),
            [JwtRegisteredClaimNames.Sub] = "public_key",
            [JwtRegisteredClaimNames.Email] = identity.Email,
            [JwtRegisteredClaimNames.Name] = identity.UserName,
            [JwtRegisteredClaimNames.GivenName] = identity.FirstName,
            [JwtRegisteredClaimNames.FamilyName] = identity.LastName,
        };

        string privateKey = "your_secret_key_your_secret_key_your_secret_key";

        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(privateKey));

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = "MyIssuer",
            Audience = "MyAudience",
            Claims = claims,
            IssuedAt = null,
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var jwt_token = new JsonWebTokenHandler().CreateToken(descriptor);

        return jwt_token;
    }
}
