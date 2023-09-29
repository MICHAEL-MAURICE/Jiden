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
    public class GovernorateController : ControllerBase
    {

        private readonly IGeneric<Governorate> _Governorate;
        public GovernorateController(IGeneric<Governorate> governorate)
        {
            _Governorate = governorate;
        }


        [HttpPost("Create")]

        public async Task<ActionResult<ApiResponse>>Create(GenericRequest request)
        {
            Governorate governorate=new Governorate()
            {
                Id=Guid.NewGuid(),
                NameInArabic=request.NameInArabic,
                NameInEnglish=request.NameInEnglish,
            };
            return Ok(await _Governorate.Create(governorate));
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult< ApiResponse>> Delete(Guid Id)
        {
            return Ok(await _Governorate.Delete(Id));
        }


        [HttpGet("GetAll")]
        public async Task< ActionResult< ApiResponse<IEnumerable<Governorate>>>> GetAll()
        {

            return Ok(await _Governorate.GetAll());
        }

        [HttpGet("GetByID")]

        public async Task<ActionResult< ApiResponse<Governorate>>> GetByID(Guid Id)
        {

            return Ok(await _Governorate.GetByID(Id));
        }

        [HttpPatch("Update")]
        public async Task<ActionResult< ApiResponse>> Update(GenericRequest request)
        {
            Governorate governorate = new Governorate()
            {
                Id = request.Id ?? new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                NameInArabic = request.NameInArabic,
                NameInEnglish = request.NameInEnglish,
            };

            return Ok(await _Governorate.Update(governorate));   
        }
        

        }

    }

