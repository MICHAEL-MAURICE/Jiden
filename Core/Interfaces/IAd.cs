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
    public interface IAd
    {
        public Task<ApiResponse> Create(AdRequest request);

        public Task<ApiResponse> ActiveAd(Guid Id);
        public Task<ApiResponse> UnActiveAd(Guid Id);

        public Task<ApiResponse<List<AdResponse>>> GetUnActive(int PageNumber , int Count );
        public Task<ApiResponse<List<AdResponse>>> GetActive(int PageNumber, int Count );

    }
}
