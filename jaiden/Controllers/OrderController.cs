using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _Order;

        public OrderController(IOrder order)
        {
            _Order= order;
        }

        [HttpPost("PostOrdr")]
       
        public async Task<ActionResult<ApiResponse<List<OrderResponse>>>> RequestOrder(List<ProudectOrderRequest> request, Guid PaymentId)
        {

            return Ok(await _Order.RequestOrder(request,PaymentId));
        }


    }
}
