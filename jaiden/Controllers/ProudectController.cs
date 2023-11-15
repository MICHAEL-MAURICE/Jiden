using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProudectController : ControllerBase
    {
        private readonly IProudect _Proudect;
        public ProudectController(IProudect proudect)
        {
            _Proudect = proudect;   
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ApiResponse>> CreateProudect(ProudectRequest request)
        {
            return Ok(await _Proudect.CreateProudect(request));
        }
        [HttpGet("GetAllActiveProudects")]
        public async Task<ActionResult<ApiResponse<List<AllProudectsResponse>>>> GetAllActiveProudects(int PageNumber, int Count)
        {
            return Ok(await _Proudect.GetAllActiveProudects(PageNumber,Count));
        }
        [HttpGet("GetProudectByID")]
        public async Task<ActionResult<ApiResponse<ProudectResponse>>> GetProudectByID(Guid ProudectId)
        {
            return Ok(await _Proudect.GetProudectByID(ProudectId));
        }
        
        [HttpGet("GetAllNonActiveProudects")]
        public async Task<ActionResult<ApiResponse<List<AllProudectsResponse>>>> GetAllNonActiveProudects(int PageNumber, int Count)
        {
            return Ok(await _Proudect.GetAllNonActiveProudects(PageNumber,Count));
        }

        [HttpGet("GetProudectsByLocation")]
        public async Task<ActionResult<ApiResponse<List<AllProudectsResponse>>>> GetProudectsByLocation(int PageNumber, int Count)
        {
            return Ok(await _Proudect.GetProudectsByLocation(PageNumber,Count));
        }

        [HttpPatch("UpdateProudectById")]

        public async Task<ActionResult<ApiResponse<ProudectResponse>>> UpdateProudect(Guid ProudectId, ProudectRequestUpdate UpdateRequest)
        {
            return Ok(await _Proudect.UpdateProudect(ProudectId, UpdateRequest));   
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResponse>>DeleteProudect(Guid ProudectID)
        {
            return Ok(await _Proudect.DeleteProudectByID(ProudectID));
        }

        [HttpGet("GetProudectsByEnglishName")]
        public async Task<ActionResult<ApiResponse<List<AllProudectsResponse>>>> GetProudectsByEnglishName(string EnglishName)
        {
            return Ok(await _Proudect.GetProudectsByEnglishName(EnglishName));
        }

        [HttpGet("GetProudectsByArabicName")]
        public async Task<ActionResult<ApiResponse<List<AllProudectsResponse>>>> GetProudectsByArabicName(string ArabicName)
        {
            return Ok(await _Proudect.GetProudectsByArabicName(ArabicName));
        }



        [HttpGet("GetProudectsByActiveSubstances")]
        public async Task<ActionResult<ApiResponse<List<AllProudectsResponse>>>> GetProudectsByActiveSubstances(string ActiveSubstance)
        {
            return Ok(await _Proudect.GetProudectsByArabicName(ActiveSubstance));
        }
    }
}
