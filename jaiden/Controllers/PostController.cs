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
    public class PostController : ControllerBase
    {
        private readonly INews _News;
        public PostController(INews news)
        {
            _News = news;
        }
        [HttpPost("Create")]
        public async Task<ActionResult<ApiResponse>> Create(CreateNewsRequest request)
        {

            return Ok(await _News.Create(request));
        }
        [HttpGet ("GetAllActive")]
        public async Task<ActionResult<ApiResponse<List<AllNewsResponse>>>> GetAllActive(int PageNumber, int Count)
        {
            return Ok(await _News.GetAllActive(PageNumber, Count));
        }
        [HttpGet("GetAllUnActive")]
        public async Task<ActionResult<ApiResponse<List<AllNewsResponse>>>> GetAllUnActive(int PageNumber, int Count )
        {
            return Ok(await _News.GetAllUnActive(PageNumber, Count));
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<ApiResponse<NewsDetailsResponse>>> GetById(Guid Id)
        {
            return Ok(await _News.GetById(Id));   
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResponse>> Delete(Guid Id)
        {
            return Ok(await _News.Delete(Id));
        }


    }
}
