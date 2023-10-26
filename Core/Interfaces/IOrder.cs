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
    public interface IOrder
    {
        public Task<ApiResponse<List<OrderResponse>>> RequestOrder(List<ProudectOrderRequest> request, Guid PaymentId);
    }
}
