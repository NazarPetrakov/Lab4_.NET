using BusinessLogicLayer.Common.Options;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace BusinessLogicLayer.Services
{
    public class TokenService : ITokenService
    {
        private readonly  JwtOptions _jwtOptions;

        public TokenService(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public string GenerateAccessToken(string userId, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
            new ("id", userId)
        };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience,
                    notBefore: now,
                    claims: claims,
                    expires: now.Add(TimeSpan.FromMinutes(_jwtOptions.Lifetime)),
                    signingCredentials: new SigningCredentials(
                        JwtOptions.GetSymmetricSecurityKey(_jwtOptions.SecretKey), _jwtOptions.SecurityAlgorithm));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
