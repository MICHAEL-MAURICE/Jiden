
using Core.Dto.Response;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Jwt
{
    public class updateToken : IupdateToken
    {
        private readonly JwtTokenData _jwtTokenData;
        private readonly ITokenFactory _tokenFactory;
        public updateToken(ITokenDecoder tokenDecoder,ITokenFactory tokenFactory)
        {
            _jwtTokenData=tokenDecoder.GetTokenData();
            _tokenFactory=tokenFactory;
        }
        public ApiResponse<updateTokenResponse> updateeToken()
        {
            if(_jwtTokenData == null )
            {
                return new ApiResponse<updateTokenResponse>()
                {
                    Status = 200,
                    isSuccess = false,
                    Message = "Please Send Your old Token",
                    Data = null
                    
                };

            }

            return new ApiResponse<updateTokenResponse>()
            {
                Status= 200,
                isSuccess=true,
                Message="Updated Succesfullt" , Data = new updateTokenResponse() 
                { Token = _tokenFactory.CreateToken(_jwtTokenData).token, Expiredon = _tokenFactory.CreateToken(_jwtTokenData).expiresOn }
            };
            
            
            
            
        }

        
    }
}
