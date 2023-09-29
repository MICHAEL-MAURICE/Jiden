﻿using Core.Dto.Request;
using Core.Entities;
using Core.Helper;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscriminationController : ControllerBase
    {

        private readonly IGeneric<Discrimination> _Discrimination;
        public DiscriminationController(IGeneric<Discrimination> discrimination)
        {
            _Discrimination= discrimination;
        }


        [HttpPost("Create")]

        public async Task<ActionResult<ApiResponse>> Create(GenericRequest request)
        {
            Discrimination discrimination = new Discrimination()
            {
                Id = Guid.NewGuid(),
               
                Name = request.NameInEnglish
            };
            return Ok(await _Discrimination.Create(discrimination));
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<ApiResponse>> Delete(Guid Id)
        {
            return Ok(await _Discrimination.Delete(Id));
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Discrimination>>>> GetAll()
        {

            return Ok(await _Discrimination.GetAll());
        }

        [HttpGet("GetByID")]

        public async Task<ActionResult<ApiResponse<Discrimination>>> GetByID(Guid Id)
        {

            return Ok(await _Discrimination.GetByID(Id));
        }

        [HttpPatch("Update")]
        public async Task<ActionResult<ApiResponse>> Update(GenericRequest request)
        {
            Discrimination discrimination = new Discrimination()
            {
                Id = request.Id??new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
               
                Name = request.NameInEnglish,
            };

            return Ok(await _Discrimination.Update(discrimination));
        }


    }

}

