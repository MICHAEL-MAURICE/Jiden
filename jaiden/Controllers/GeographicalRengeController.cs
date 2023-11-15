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
    public class GeographicalRengeController : ControllerBase
    {
        private readonly IGeographicalRenge _geographicalRenge;

        public GeographicalRengeController(IGeographicalRenge geographicalRenge)
        {
            _geographicalRenge = geographicalRenge;
        }

        [HttpGet("GetCitiesandStatus")]
        public async Task<ActionResult<ApiResponse<List<GeographicalResponse>>>> GetCitiesandStatus(Guid ProudectId, Guid GeolocationId)
        {
            return Ok(await _geographicalRenge.GetCitiesandStatus(ProudectId,GeolocationId));
        }
    }
}
