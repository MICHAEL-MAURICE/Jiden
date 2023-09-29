using Core.Dto.Request;
using Core.Entities;
using Core.Helper;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WayMedicineUsedController : ControllerBase
    {

        private readonly IGeneric<WayMedicineUsed> _WayMedicineUsed;
        public WayMedicineUsedController(IGeneric<WayMedicineUsed> wayMedicineUsed)
        {
            _WayMedicineUsed=wayMedicineUsed;
        }


        [HttpPost("Create")]

        public async Task<ActionResult<ApiResponse>> Create(GenericRequest request)
        {
            WayMedicineUsed wayMedicineUsed = new WayMedicineUsed()
            {
                Id = Guid.NewGuid(),

                Name = request.NameInEnglish
            };
            return Ok(await _WayMedicineUsed.Create(wayMedicineUsed));
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<ApiResponse>> Delete(Guid Id)
        {
            return Ok(await _WayMedicineUsed.Delete(Id));
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResponse<IEnumerable<WayMedicineUsed>>>> GetAll()
        {

            return Ok(await _WayMedicineUsed.GetAll());
        }

        [HttpGet("GetByID")]

        public async Task<ActionResult<ApiResponse<WayMedicineUsed>>> GetByID(Guid Id)
        {

            return Ok(await _WayMedicineUsed.GetByID(Id));
        }

        [HttpPatch("Update")]
        public async Task<ActionResult<ApiResponse>> Update(GenericRequest request)
        {
            WayMedicineUsed wayMedicineUsed = new WayMedicineUsed()
            {
                Id = request.Id ?? new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),

                Name = request.NameInEnglish
            };

            return Ok(await _WayMedicineUsed.Update(wayMedicineUsed));
        }


    }

}

