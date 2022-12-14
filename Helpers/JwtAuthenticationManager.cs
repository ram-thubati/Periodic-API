using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Periodic.Helpers
{
    public class JwtAuthenticationManager
    {

        public static string GetToken(int userId, string role, string signingKey)
        {

            var tokenhndlr = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(signingKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Role, role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenhndlr.CreateToken(tokenDescriptor);
            return tokenhndlr.WriteToken(token);
        }
    }
}
