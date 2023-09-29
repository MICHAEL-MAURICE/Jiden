using Core.Dto.Request;
using Core.Dto.Response;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuth
    {
        public Task<ApiResponse<AuthUserResponse>>Login(AuthRequest LoginDto);

        public Task<ApiResponse> Rejesteration(RejesterationRequest rejesterationRequest);
        public Task<ApiResponse> ResetPassword(AuthRequest ResetPaswordDto);
    }
}
