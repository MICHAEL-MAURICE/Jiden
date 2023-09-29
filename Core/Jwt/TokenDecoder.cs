
//using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.IdentityModel.Tokens.Jwt;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Core.Jwt
{
    public class TokenDecoder : ITokenDecoder
    {
        private IHttpContextAccessor contextAccessor;
        
        public TokenDecoder(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }
        public JwtTokenData GetTokenData()
        {
            var Token = contextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(Token)) return null;
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(Token);
            var governoratesClaim = jwt.Claims.FirstOrDefault(OfType( ApplicationClaims.Geographical))?.Value;

            List<Guid?> governoratesGuids =new List<Guid?>();

            if (!string.IsNullOrEmpty(governoratesClaim))
            {
                governoratesGuids = governoratesClaim.Split(',')
        .Select(guidStr => Guid.TryParse(guidStr, out Guid guid) ? guid : (Guid?)null)
        .ToList();
            }

            return new JwtTokenData
            {
                UserId = jwt.Claims.First(OfType( ApplicationClaims.UserId)).Value,
                Email = jwt.Claims.First( OfType( ApplicationClaims.Email)).Value,
                Role = int.Parse(jwt.Claims.First(OfType( ApplicationClaims.Role)).Value),
                Governorates = governoratesGuids
            };

        }
        private Func<Claim,bool> OfType(ApplicationClaims type)
        {
            return claim => claim.Type == type.ToString();
        }
    }
}
