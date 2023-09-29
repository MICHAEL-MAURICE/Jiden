using Core.Dto.Request;
using Core.Dto.Response;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUser
    {
        public Task<ApiResponse<List<AllUsersResponse>>> GetAllNonActiveUsers();
        public  Task<ApiResponse<List<AllUsersResponse>>> GetAllActiveUsers();
        public Task<ApiResponse<UserResponse>> GetUserById(string ID);
        public Task<ApiResponse> ActiveUserByID(string UserID);
        public Task<ApiResponse> UnActiveUserByID(string UserID);
        public Task<ApiResponse> DeleteUser(string UserID);
        public Task<ApiResponse> UpdateUser(UpdateUser _updateUser);
    }
}
