using Core.Dto.Response;
using Core.Helper;
using Core.Interfaces;
using Core.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IProudect _Proudect;
        private readonly JwtTokenData _jwtTokenData;
        private readonly IUser _Users;
        private readonly INews _News;

        public AdminController(IProudect proudect,ITokenDecoder tokenDecoder,IUser Users,INews news)
        {
            _Proudect = proudect;   
            _jwtTokenData=tokenDecoder.GetTokenData();
            _Users = Users; 
            _News = news;
                
        }

        [HttpPatch("ActiveProudect")]
        public async Task<ActionResult<ApiResponse>> ActiveProudectByID(Guid ProudectId)
        {

            return Ok(await _Proudect.ActiveProudectByID(ProudectId));
        }



        [HttpPatch("ActiveUserByID")]
        public async Task<ActionResult<ApiResponse>> ActiveUserByID(string UserId)
        {

            return Ok(await _Users.ActiveUserByID(UserId));
        }


        [HttpPatch("UnActiveUserByID")]
        public async Task<ActionResult<ApiResponse>> UnActiveUserByID(string userId)
        {

            return Ok(await _Users.UnActiveUserByID(userId));
        }

        [HttpPatch("UnActiveProudect")]
        public async Task<ActionResult<ApiResponse>> UnActiveProudect(Guid ProudectId)
        {

            return Ok(await _Proudect.UnActiveProudectByID(ProudectId));
        }


        [HttpPatch("UnActivePost")]
        public async Task<ActionResult<ApiResponse>> UnActivePost(Guid Id)
        {

            return Ok(await _News.UnActive(Id));
        }
        [HttpPatch("ActivePost")]
        public async Task<ActionResult<ApiResponse>> ActivePost(Guid Id)
        {

            return Ok(await _News.Active(Id));
        }

    }
}
