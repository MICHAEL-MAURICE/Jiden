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
    
        public Task<ApiResponse<List<GetAllOrderResponse>>> GetPendingOrders();
        public Task<ApiResponse<List<GetAllOrderResponse>>> GetRejectedOrders();
        public Task<ApiResponse<List<GetAllOrderResponse>>> GetpaidOrders();
        public Task<ApiResponse<List<GetAllOrderResponse>>> GetneedToAttachImageOrders();
        public Task<ApiResponse<List<GetAllOrderResponse>>> GetpartialApprovalOrders();

        public Task<ApiResponse<GetOrdersforUser>> GetPendingOrdersForUser();
        public Task<ApiResponse<GetOrdersforUser>> GetRejectedOrdersForUser();
        public Task<ApiResponse<GetOrdersforUser>> GetpaidOrdersForUser();
        public Task<ApiResponse<GetOrdersforUser>> GetneedToAttachImageOrdersForUser();
        public Task<ApiResponse<GetOrdersforUser>> GetpartialApprovalOrdersForUser();

        public Task<ApiResponse<OrderDetailesResponse>> GetOrderDetailes(Guid Id);

        public Task<ApiResponse<ProudectOrderResponse>>GetOrderProudectDetailes(Guid Id);
        public Task<ApiResponse<GetOrdersforUser>> GetPendingOrdersForUser(string Id);
        public Task<ApiResponse<GetOrdersforUser>> GetRejectedOrdersForUser(string Id);
        public Task<ApiResponse<GetOrdersforUser>> GetpaidOrdersForUser(string Id);
        public Task<ApiResponse<GetOrdersforUser>> GetneedToAttachImageOrdersForUser(string Id);
        public Task<ApiResponse<GetOrdersforUser>> GetpartialApprovalOrdersForUser(string Id);


        public Task<ApiResponse> UploadReceiptImage(OrderReceiptRequest request);
        public Task<ApiResponse<List<OrderResponse>>> RequestOrder(List<ProudectOrderRequest> request, Guid PaymentId);
    }
}
