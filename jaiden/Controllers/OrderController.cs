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


        [HttpPost("UploadReceiptImage")]
        public async Task<ActionResult<ApiResponse>> UploadReceiptImage(OrderReceiptRequest request)
        {

            return Ok(await _Order.UploadReceiptImage(request));
        }


        [HttpGet("GetpaidOrders")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetpaidOrders()
        {

            return Ok(await _Order.GetpaidOrders());
        }

        [HttpGet("GetPendingOrders")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetPendingOrders()
        {

            return Ok(await _Order.GetPendingOrders());
        }

        [HttpGet("GetRejectedOrders")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetRejectedOrders()
        {

            return Ok(await _Order.GetRejectedOrders());
        }
        [HttpGet("GetpartialApprovalOrders")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetpartialApprovalOrders()
        {

            return Ok(await _Order.GetpartialApprovalOrders());
        }


        [HttpGet("GetneedToAttachImageOrders")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetneedToAttachImageOrders()
        {

            return Ok(await _Order.GetneedToAttachImageOrders());
        }

        [HttpGet("GetpaidOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetpaidOrdersForUser()
        {

            return Ok(await _Order.GetpaidOrdersForUser());
        }

        [HttpGet("GetPendingOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetPendingOrdersForUser()
        {

            return Ok(await _Order.GetPendingOrdersForUser());
        }

        [HttpGet("GetRejectedOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetRejectedOrdersForUser()
        {

            return Ok(await _Order.GetRejectedOrdersForUser());
        }
        [HttpGet("GetpartialApprovalOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetpartialApprovalOrdersForUser()
        {

            return Ok(await _Order.GetpartialApprovalOrdersForUser());
        }


        [HttpGet("GetneedToAttachImageOrdersForUser")]
        public async Task<ActionResult<ApiResponse<List<GetAllOrderResponse>>>> GetneedToAttachImageOrdersForUser()
        {

            return Ok(await _Order.GetneedToAttachImageOrdersForUser());
        }



       

    }
}
