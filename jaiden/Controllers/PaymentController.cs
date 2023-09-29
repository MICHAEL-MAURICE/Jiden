using Core.Dto.Request;
using Core.Dto.Response;
using Core.Helper;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayment _payment;
        public PaymentController(IPayment payment)
        {
            _payment = payment; 
        }
        [HttpPost("Create")]
        public async Task<ActionResult<ApiResponse>> Create(PaymentRequest payment)
        {
            return Ok(await _payment.Create(payment));  
        }
        [HttpDelete("Delete")]

        public async Task<ActionResult< ApiResponse>> Delete(Guid Id)
        {
            return Ok(await _payment.Delete(Id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult< ApiResponse<List<PaymentResponse>>>> GetAll()
        {
            return Ok(await _payment.GetAll());
        }

        [HttpGet("GetByUserId")]
        public async Task<ActionResult< ApiResponse<List<PaymentResponse>>>> GetByUserId()
        {
            return Ok(_payment.GetByUserId());
        }
        [HttpPatch("Update")]
        public async Task<ActionResult< ApiResponse<PaymentResponse>>> Update(PaymentRequest request)
        {
            return Ok(_payment.Update(request));
        }

    }
}
