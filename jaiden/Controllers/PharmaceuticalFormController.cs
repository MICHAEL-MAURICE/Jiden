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
    public class PharmaceuticalFormController : ControllerBase
    {

        private readonly IGeneric<PharmaceuticalForm> _PharmaceuticalForm;
        public PharmaceuticalFormController(IGeneric<PharmaceuticalForm> pharmaceuticalForm)
        {
            _PharmaceuticalForm= pharmaceuticalForm;
        }


        [HttpPost("Create")]

        public async Task<ActionResult<ApiResponse>> Create(GenericRequest request)
        {
            PharmaceuticalForm pharmaceuticalForm = new PharmaceuticalForm()
            {
                Id = Guid.NewGuid(),

                Name = request.NameInEnglish
            };
            return Ok(await _PharmaceuticalForm.Create(pharmaceuticalForm));
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<ApiResponse>> Delete(Guid Id)
        {
            return Ok(await _PharmaceuticalForm.Delete(Id));
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResponse<IEnumerable<PharmaceuticalForm>>>> GetAll()
        {

            return Ok(await _PharmaceuticalForm.GetAll());
        }

        [HttpGet("GetByID")]

        public async Task<ActionResult<ApiResponse<PharmaceuticalForm>>> GetByID(Guid Id)
        {

            return Ok(await _PharmaceuticalForm.GetByID(Id));
        }

        [HttpPatch("Update")]
        public async Task<ActionResult<ApiResponse>> Update(GenericRequest request)
        {
            PharmaceuticalForm pharmaceuticalForm = new PharmaceuticalForm()
            {
                Id = request.Id ?? new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),

                Name = request.NameInEnglish
            };

            return Ok(await _PharmaceuticalForm.Update(pharmaceuticalForm));
        }


    }

}

