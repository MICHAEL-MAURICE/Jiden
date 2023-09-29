using Core.Dto.Request;
using Core.Dto.Response;
using Core.Helper;
using Core.Interfaces;
using Infrastructure.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _users;
        public UsersController(IUser users)
        {
            _users= users;
        }

        [HttpGet("GetAllNonActiveUsers")]

        public async Task<ActionResult< ApiResponse<List<AllUsersResponse>>>> GetAllNonActiveUsers()
        {
            return Ok(await _users.GetAllNonActiveUsers());    
        }


        [HttpGet("GetAllActiveUsers")]

        public async Task<ActionResult<ApiResponse<List<AllUsersResponse>>>> GetAllActiveUsers()
        {
            return Ok(await _users.GetAllActiveUsers());
        }

        [HttpGet("GetUserById")]

        public async Task<ActionResult< ApiResponse<UserResponse>>> GetUserById(string ID)
        {
            return Ok(await _users.GetUserById(ID));
        }

        //[HttpDelete("DeleteUser")]
        //public async Task<ActionResult<ApiResponse>> DeleteUser(string ID)
        //{
        //    return Ok(await _users.DeleteUser(ID));
        //}

        [HttpPatch("UpdateUser")]
        public async Task<ActionResult<ApiResponse>> UpdateUser(UpdateUser _updateUser)
        {

            return Ok(await _users.UpdateUser(_updateUser));
        }
    }
}
