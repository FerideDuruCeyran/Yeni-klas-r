using Eticaret.Model;
using System.IdentityModel.Tokens.Jwt;

namespace Eticaret.Magaza.Helpers
{
    public class JwtToken
    {
        public Login Decrypt(string token)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var tokenHandler = new JwtSecurityTokenHandler();
            token = token.Replace("\\", "");
            token = token.Replace('"', ' ');
            token = token.Trim();

            var jwtTokenWithoutValidation = (JwtSecurityToken)tokenHandler.ReadToken(token);
            var email = jwtTokenWithoutValidation!.Payload["Email"].ToString();

            Login user = new() { Email = email! };
            return user;
        }
    }
}
