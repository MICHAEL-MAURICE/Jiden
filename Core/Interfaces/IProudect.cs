using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProudect
    {
        public Task<ApiResponse> CreateProudect(ProudectRequest proudect);
        public  Task<ApiResponse<List<AllProudectsResponse>>> GetAllActiveProudects();
        public Task<ApiResponse<ProudectResponse>> GetProudectByID(Guid ProudectId);
        public Task<ApiResponse<ProudectResponse>> UpdateProudect(Guid ProudectId, ProudectRequestUpdate proudect);
        public Task<ApiResponse<List<AllProudectsResponse>>> GetProudectsByLocation();
        public Task<ApiResponse> ActiveProudectByID(Guid ProudectId);
        public Task<ApiResponse> UnActiveProudectByID(Guid ProudectId);
        public  Task<ApiResponse<List<AllProudectsResponse>>> GetAllNonActiveProudects();

        public Task<ApiResponse> DeleteProudectByID(Guid ProudectId);
        public  Task<ApiResponse<List<AllProudectsResponse>>> GetProudectsByEnglishName(string ProudectEnglishName);
        public Task<ApiResponse<List<AllProudectsResponse>>> GetProudectsByArabicName(string ProudectArabicName);
        public Task<ApiResponse<List<AllProudectsResponse>>> GetProudectsByActiveSubstances(string ActiveSubstance);
    }
}
