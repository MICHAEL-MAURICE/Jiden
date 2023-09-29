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
    public class TypeOfMedicationController : ControllerBase
    {

        private readonly IGeneric<TypeOfMedication> _TypeOfMedication;
        public TypeOfMedicationController(IGeneric<TypeOfMedication> typeOfMedication)
        {
            _TypeOfMedication= typeOfMedication;
        }


        [HttpPost("Create")]

        public async Task<ActionResult<ApiResponse>> Create(GenericRequest request)
        {
            TypeOfMedication typeOfMedication = new TypeOfMedication()
            {
                Id = Guid.NewGuid(),

                Name = request.NameInEnglish
            };
            return Ok(await _TypeOfMedication.Create(typeOfMedication));
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<ApiResponse>> Delete(Guid Id)
        {
            return Ok(await _TypeOfMedication.Delete(Id));
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TypeOfMedication>>>> GetAll()
        {

            return Ok(await _TypeOfMedication.GetAll());
        }

        [HttpGet("GetByID")]

        public async Task<ActionResult<ApiResponse<TypeOfMedication>>> GetByID(Guid Id)
        {

            return Ok(await _TypeOfMedication.GetByID(Id));
        }

        [HttpPatch("Update")]
        public async Task<ActionResult<ApiResponse>> Update(GenericRequest request)
        {
            TypeOfMedication typeOfMedication = new TypeOfMedication()
            {
                Id = request.Id ?? new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),

                Name = request.NameInEnglish
            };

            return Ok(await _TypeOfMedication.Update(typeOfMedication));
        }


    }

}

