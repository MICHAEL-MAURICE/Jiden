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
        private readonly IAd _ad;
        private readonly IOrder _Order;

        public AdminController(IProudect proudect,ITokenDecoder tokenDecoder,IUser Users,INews news,IAd ad, IOrder order)
        {
            _Proudect = proudect;   
            _jwtTokenData=tokenDecoder.GetTokenData();
            _Users = Users; 
            _News = news;
            _ad = ad;
            _Order = order;
                
        }

        [HttpPatch("ActiveProudect")]
        public async Task<ActionResult<ApiResponse>> ActiveProudectByID(Guid ProudectId)
        {

            return Ok(await _Proudect.ActiveProudectByID(ProudectId));
        }


        [HttpPatch("ActiveAd")]
        public async Task<ActionResult<ApiResponse>> ActiveAd(Guid Id)
        {

            return Ok(await _ad.ActiveAd(Id));
        }

        [HttpPatch("unActiveAd")]
        public async Task<ActionResult<ApiResponse>> unActiveAd(Guid Id)
        {

            return Ok(await _ad.UnActiveAd(Id));
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


        [HttpGet("GetpaidOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetpaidOrdersForUser(string UserId)
        {

            return Ok(await _Order.GetpaidOrdersForUser(UserId));
        }

        [HttpGet("GetPendingOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetPendingOrdersForUser(string UserId)
        {

            return Ok(await _Order.GetPendingOrdersForUser(UserId));
        }

        [HttpGet("GetRejectedOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetRejectedOrdersForUser(string UserId)
        {

            return Ok(await _Order.GetRejectedOrdersForUser(UserId));
        }
        [HttpGet("GetpartialApprovalOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetpartialApprovalOrdersForUser(string UserId)
        {

            return Ok(await _Order.GetpartialApprovalOrdersForUser(UserId));
        }


        [HttpGet("GetneedToAttachImageOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetneedToAttachImageOrdersForUser(string UserId)
        {

            return Ok(await _Order.GetneedToAttachImageOrdersForUser(UserId));
        }




    }
}
