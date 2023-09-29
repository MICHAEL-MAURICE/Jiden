
using Core.Dto.Response;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Jwt
{
    public interface IupdateToken
    {

        public ApiResponse<updateTokenResponse> updateeToken();   
    }
}
