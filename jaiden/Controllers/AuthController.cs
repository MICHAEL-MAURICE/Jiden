using Core.Dto.Request;
using Core.Dto.Response;
using Core.Helper;
using Core.Identity;
using Core.Interfaces;
using Core.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuth _auth;
        private readonly IupdateToken _updateToken;
        public AuthController(IAuth auth,IupdateToken updateToken)
        {
            _auth= auth;
            _updateToken= updateToken;
        }

        [HttpGet("Login")]
        public async Task<ActionResult<ApiResponse<AuthUserResponse>>> Login(string Email,string password)
        {
            return Ok(_auth.Login(new AuthRequest() { Email=Email,Password=password}));

        }


        [HttpPost("RejesterationRequest")]
        public async Task<ActionResult< ApiResponse>> Rejesteration(RejesterationRequest rejesterationRequest)
        {
            return Ok(await _auth.Rejesteration(rejesterationRequest));
        }


        [HttpGet("RefreshToken")]
        public ActionResult<ApiResponse<updateTokenResponse>> RefreshToken()
        {

            return Ok(_updateToken.updateeToken());
        }

        //[HttpPost("ResetPassword")]
        //public async Task<ActionResult<ApiResponse>> ResetPassword(AuthRequest ResetPassword)
        //{
        //    return Ok(_auth.ResetPassword(ResetPassword));
        //}

    }
}
