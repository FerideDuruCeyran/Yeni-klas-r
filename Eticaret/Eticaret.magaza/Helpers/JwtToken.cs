using Eticaret.Model;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Eticaret.magaza.Helpers
{
    public class JwtToken
    {
        public Login Decrypt(string token)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string key = configuration["jwt.Key"]!;
            var tokenHandler = new JwtSecurityTokenHandler();
            token = token.Replace("\\", "");
            token = token.Replace('"', ' ');
            token = token.Trim();
            var jwtTokenWithoutValidation = (JwtSecurityToken)tokenHandler.ReadToken(token);
            var email = jwtTokenWithoutValidation!.Payload["Email"].ToString();
            Login user = new()
            {
                Email = email!
            };
            return user;
        }
    }
}
