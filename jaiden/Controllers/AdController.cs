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
    public class AdController : ControllerBase
    {
        private readonly IAd _ad;

        public AdController(IAd ad)
        {
            _ad = ad;
        }

        [HttpPost("Create")]

        public async Task<ActionResult<ApiResponse>>Create(AdRequest request)
        {
            return Ok(await _ad.Create(request));
        }

        [HttpGet("GetAllUnActive")]
        public async Task<ActionResult<ApiResponse<List<AdResponse>>>>GetUnActive(int PageNumber, int Count)
        {
            return Ok(await _ad.GetUnActive(PageNumber, Count));
        }

        [HttpGet("GetAllActive")]
        public async Task<ActionResult<ApiResponse<List<AdResponse>>>> GetActive(int PageNumber, int Count)
        {
            return Ok(await _ad.GetActive(PageNumber, Count));
        }




    }
}
