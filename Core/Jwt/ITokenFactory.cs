

namespace Core.Jwt
{
    public interface ITokenFactory
    {
        public (string token, DateTime expiresOn) CreateToken(JwtTokenData jwtTokenData);
    }
}
