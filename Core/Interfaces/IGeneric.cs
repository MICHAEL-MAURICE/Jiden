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
    public interface IGeneric <TEntity> where TEntity : class
    {
        public Task<ApiResponse> Create(TEntity GenericRequest);
        public Task<ApiResponse<IEnumerable<TEntity>>> GetAll();
        public Task<ApiResponse> Update(TEntity GenericRequest);
        public Task<ApiResponse> Delete(Guid Id);
        public Task<ApiResponse<TEntity>> GetByID(Guid Id);



    }
}
