using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Core.Jwt
{
    public class TokenFactory : ITokenFactory
    {
        private IConfiguration _config;
        
        public TokenFactory(IConfiguration _config)
        {
            this._config = _config;
        }
        public (string token,DateTime expiresOn) CreateToken(JwtTokenData jwtTokenData)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ApplicationClaims.UserId.ToString(), jwtTokenData.UserId.ToString() ),
                new Claim(ApplicationClaims.Email.ToString(),jwtTokenData.Email.ToString()),

                new Claim(ApplicationClaims.Role.ToString(),jwtTokenData.Role.ToString()),
                new Claim(ApplicationClaims.Geographical.ToString(),string.Join(",", jwtTokenData.Governorates))
            };

            var expiresOn = DateTime.UtcNow.AddDays(30);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: expiresOn,
              signingCredentials: credentials);

            return (new JwtSecurityTokenHandler().WriteToken(token), expiresOn);
        }
    }
}
