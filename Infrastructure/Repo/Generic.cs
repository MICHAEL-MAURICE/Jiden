using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class Generic<TEntity> : IGeneric<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Generic(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public async Task<ApiResponse> Create(TEntity GenericRequest)
        {
            
           var Result= await _dbSet.AddAsync(GenericRequest);
            if (Result != null)
            {
                _dbContext.SaveChanges();
                return new ApiResponse() { isSuccess = true, Message = "Added Successfully", Status = 200 };
            }
            return new ApiResponse() { isSuccess = false, Message = "The Row Not Added Successfully", Status = 200 };
        
    }

        public async Task<ApiResponse> Delete(Guid Id)
        {
            var EntityRow = await _dbSet.FindAsync(Id);
            if (EntityRow != null) { _dbSet.Remove(EntityRow);
                _dbContext.SaveChanges();
                return new ApiResponse() { isSuccess = true, Message = "This Row Deleted Successfully", Status = 200 };

            }
            return new ApiResponse() { isSuccess = false, Message = "This Row was not Deleted ", Status = 200 };
        }

        public async Task<ApiResponse<IEnumerable<TEntity>>> GetAll()
        {
            var Result = await _dbSet.ToListAsync();
            if (Result != null)
            {

                return new ApiResponse<IEnumerable<TEntity>>()
                {
                    Data = Result,
                    isSuccess = true,
                    Message = "This Row Deleted Successfully",
                    Status = 200
                };

            }
            return new ApiResponse<IEnumerable<TEntity>>()
            {
                Data = null,
                isSuccess = false,
                Message = "This Row  Was not Deleted Successfully",
                Status = 200
            };

        }
            public async Task<ApiResponse<TEntity>> GetByID(Guid Id)
        {
            var Result=await _dbSet.FindAsync(Id);
            if (Result != null)
            {
                return new ApiResponse<TEntity>() {Data=Result, isSuccess = true, Message = "Found Successfully", Status = 200 };

            }
            return new ApiResponse < TEntity > (){Data=null, isSuccess = false, Message = "This Row was not Deleted ", Status = 200 };
        }

        public async Task<ApiResponse> Update(TEntity GenericRequest)
        {
            var Result =  _dbSet.Update(GenericRequest);
            
            if (Result != null)
            {
               await _dbContext.SaveChangesAsync();

                return new ApiResponse() { Status = 200, isSuccess = true, Message = "Your Entity Updated" };
            }
            return new ApiResponse() { Status = 200, isSuccess = false, Message = "Your Entity Not Updated" };
            }
    }
}
