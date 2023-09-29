

namespace Core.Jwt
{
    public interface ITokenDecoder
    {
        public JwtTokenData GetTokenData();

    }
}
