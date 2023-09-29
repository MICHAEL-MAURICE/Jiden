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
    public interface IPayment
    {
        public Task<ApiResponse> Create(PaymentRequest payment);
        public Task<ApiResponse<List<PaymentResponse>>> GetAll();
        public Task<ApiResponse<List<PaymentResponse>>> GetByUserId();
        public Task<ApiResponse> Delete(Guid Id);
        public Task<ApiResponse<PaymentResponse>> Update(PaymentRequest payment);



    }
}
