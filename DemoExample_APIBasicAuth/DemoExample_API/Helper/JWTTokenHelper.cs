using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoExample_API.Helper
{
    public class JWTTokenHelper
    {
        public static string GenerateToken(string username, string secretKey, int expiryMinutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            if (key.Length < 32) // 32 bytes = 256 bits
            {
                throw new ArgumentException("The secret key must be at least 256 bits (32 bytes) long.");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
