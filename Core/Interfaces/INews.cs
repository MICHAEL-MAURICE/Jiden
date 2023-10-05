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
    public interface INews
    {
        public Task<ApiResponse> Create(CreateNewsRequest request);

        public Task<ApiResponse<List<AllNewsResponse>>> GetAllActive(int PageNumber, int Count);
        public Task<ApiResponse<List<AllNewsResponse>>> GetAllUnActive(int PageNumber, int Count );
        public Task<ApiResponse<NewsDetailsResponse>> GetById(Guid Id);

        public Task<ApiResponse> Delete(Guid Id);

        public Task<ApiResponse> Active(Guid Id);

        public Task<ApiResponse> UnActive(Guid Id);


    }
}
