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



        [HttpPost("PostOrderAgent")]

        public async Task<ActionResult<ApiResponse<List<OrderResponse>>>> RequestOrderAgent(List<ProudectAgentRequest> request, Guid PaymentId)
        {

            return Ok(await _Order.RequestOrderAgent(request,PaymentId));
        }


        [HttpPost("UploadReceiptImage")]
        public async Task<ActionResult<ApiResponse>> UploadReceiptImage(OrderReceiptRequest request)
        {

            return Ok(await _Order.UploadReceiptImage(request));
        }


       



        [HttpGet("GetOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetOrdersForUser(int Status)
        {

            return Ok(await _Order.GetOrdersForUser(Status));
        }

        //[HttpGet("GetPendingOrdersForUser")]
        //public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetPendingOrdersForUser()
        //{

        //    return Ok(await _Order.GetPendingOrdersForUser());
        //}

        //[HttpGet("GetRejectedOrdersForUser")]
        //public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetRejectedOrdersForUser()
        //{

        //    return Ok(await _Order.GetRejectedOrdersForUser());
        //}
        //[HttpGet("GetpartialApprovalOrdersForUser")]
        //public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetpartialApprovalOrdersForUser()
        //{

        //    return Ok(await _Order.GetpartialApprovalOrdersForUser());
        //}


        //[HttpGet("GetneedToAttachImageOrdersForUser")]
        //public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetneedToAttachImageOrdersForUser()
        //{

        //    return Ok(await _Order.GetneedToAttachImageOrdersForUser());
        //}



        //[HttpGet("GetpaidOrdersAgentForUser")]
        //public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetpaidOrdersAgentForUser()
        //{

        //    return Ok(await _Order.GetpaidOrdersAgentForUser());
        //}

        //[HttpGet("GetPendingOrdersAgentForUser")]
        //public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetPendingOrdersAgentForUser()
        //{

        //    return Ok(await _Order.GetPendingOrdersAgentForUser());
        //}

        //[HttpGet("GetRejectedOrdersAgentForUser")]
        //public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetRejectedOrdersAgentForUser()
        //{

        //    return Ok(await _Order.GetRejectedOrdersAgentForUser());
        //}
        //[HttpGet("GetpartialApprovalOrdersAgentForUser")]
        //public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetpartialApprovalOrdersAgentForUser()
        //{

        //    return Ok(await _Order.GetpartialApprovalOrdersAgentForUser());
        //}


        //[HttpGet("GetneedToAttachImageOrdersAgentForUser")]
        //public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetneedToAttachImageOrdersAgentForUser()
        //{

        //    return Ok(await _Order.GetneedToAttachImageOrdersAgentForUser());
        //}


        [HttpGet("GetOrderDetailes")]
        public async Task<ActionResult<ApiResponse<OrderDetailesResponse>>> GetOrderDetailes(Guid Id)
        {

            return Ok(await _Order.GetOrderDetailes(Id));
        }
        [HttpGet("GetOrderProudectDetailes")]
        public async Task<ActionResult<ApiResponse<ProudectOrderResponse>>> GetOrderProudectDetailes(Guid Id)
        {

            return Ok(await _Order.GetOrderProudectDetailes(Id));
        }

        [HttpGet("GetOrderAgentDetailes")]
        public async Task<ActionResult<ApiResponse<OrderDetailesResponse>>> GetOrderAgentDetailes(Guid Id)
        {

            return Ok(await _Order.GetOrderAgentDetailes(Id));
        }
        [HttpGet("GetOrderProudectAgentDetailes")]
        public async Task<ActionResult<ApiResponse<ProudectOrderResponse>>> GetOrderProudectAgentDetailes(Guid Id)
        {

            return Ok(await _Order.GetOrderProudectAgentDetailes(Id));
        }

    }
}
