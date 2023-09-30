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
    public class PricingSetting : ControllerBase
    {
        private readonly IPricingSettings _pricingSettings;
        public PricingSetting( IPricingSettings pricingSettings)
        {
            _pricingSettings= pricingSettings;
        }

        [HttpPost("Create")]

        public async Task<ActionResult<ApiResponse>> Create(PricingSettingsRequest request)
        {
            return Ok(await _pricingSettings.Create(request));

        }

        [HttpGet("GetAll")]

        public async Task<ActionResult<ApiResponse<List<PricingSettingResponse>>>> GetAll()
        {
            return Ok(await _pricingSettings.GetAll());

        }

        [HttpGet("GetBYId")]
        public async Task<ActionResult< ApiResponse<PricingSettingResponse>>> GetById(Guid Id)
        {
            return Ok(await _pricingSettings.GetById(Id));

        }

        [HttpPatch("Update")]
        public async Task<ActionResult<ApiResponse>> Update (PricingSettingsRequest request)
        {
            return Ok(await _pricingSettings.Update(request));

        }


    }
}
