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
        public  Task<ApiResponse<List<GetAllOrderResponse>>> GetOrdersByusingStatus(int status);
        //  public Task<ApiResponse<List<GetAllOrderResponse>>> GetPendingOrders();
        // public Task<ApiResponse<List<GetAllOrderResponse>>> GetRejectedOrders();
        // public Task<ApiResponse<List<GetAllOrderResponse>>> GetpaidOrders();
        //public Task<ApiResponse<List<GetAllOrderResponse>>> GetneedToAttachImageOrders();
        //public Task<ApiResponse<List<GetAllOrderResponse>>> GetpartialApprovalOrders();


        //public Task<ApiResponse<List<GetAllOrderResponse>>> GetPendingOrdersAgent();
        // public Task<ApiResponse<List<GetAllOrderResponse>>> GetRejectedOrdersAgent();
        //public Task<ApiResponse<List<GetAllOrderResponse>>> GetpaidOrdersAgent();
        //public Task<ApiResponse<List<GetAllOrderResponse>>> GetneedToAttachImageOrdersAgent();
        //public Task<ApiResponse<List<GetAllOrderResponse>>> GetpartialApprovalOrdersAgent();

        public Task<ApiResponse<GetOrdersforUser>> GetOrdersForUser(int status);
        //public Task<ApiResponse<GetOrdersforUser>> GetPendingOrdersForUser();
        //public Task<ApiResponse<GetOrdersforUser>> GetRejectedOrdersForUser();
        //public Task<ApiResponse<GetOrdersforUser>> GetpaidOrdersForUser();
        //public Task<ApiResponse<GetOrdersforUser>> GetneedToAttachImageOrdersForUser();
        //public Task<ApiResponse<GetOrdersforUser>> GetpartialApprovalOrdersForUser();

        public Task<ApiResponse<GetOrdersforUser>> GetOrdersForUser(string Id,int Status);

        //public Task<ApiResponse<GetOrdersforUser>> GetPendingOrdersForUser(string Id);
        //public Task<ApiResponse<GetOrdersforUser>> GetRejectedOrdersForUser(string Id);
        //public Task<ApiResponse<GetOrdersforUser>> GetpaidOrdersForUser(string Id);
        //public Task<ApiResponse<GetOrdersforUser>> GetneedToAttachImageOrdersForUser(string Id);
        //public Task<ApiResponse<GetOrdersforUser>> GetpartialApprovalOrdersForUser(string Id);



        //public Task<ApiResponse<GetOrdersforUser>> GetPendingOrdersAgentForUser();
        //public Task<ApiResponse<GetOrdersforUser>> GetRejectedOrdersAgentForUser();
        //public Task<ApiResponse<GetOrdersforUser>> GetpaidOrdersAgentForUser();
        //public Task<ApiResponse<GetOrdersforUser>> GetneedToAttachImageOrdersAgentForUser();
        //public Task<ApiResponse<GetOrdersforUser>> GetpartialApprovalOrdersAgentForUser();



        //public Task<ApiResponse<GetOrdersforUser>> GetPendingOrdersAgentForUser(string Id);
        //public Task<ApiResponse<GetOrdersforUser>> GetRejectedOrdersAgentForUser(string Id);
        //public Task<ApiResponse<GetOrdersforUser>> GetpaidOrdersAgentForUser(string Id);
        //public Task<ApiResponse<GetOrdersforUser>> GetneedToAttachImageOrdersAgentForUser(string Id);
        //public Task<ApiResponse<GetOrdersforUser>> GetpartialApprovalOrdersAgentForUser(string Id);



        public Task<ApiResponse<OrderDetailesResponse>> GetOrderDetailes(Guid Id);

        public Task<ApiResponse<Guid>> ChangeOrderAgentStatus(ChangeOrderStatusRequest requestDto);
        public Task<ApiResponse<ProudectOrderResponse>> GetOrderProudectDetailes(Guid Id);
        public Task<ApiResponse<Guid>> ChangeOrderStatus(ChangeOrderStatusRequest requestDto);
        public Task<ApiResponse> UploadReceiptImage(OrderReceiptRequest request);
        public  Task<ApiResponse<OrderDetailesResponse>> GetOrderAgentDetailes(Guid Id);
        public  Task<ApiResponse<ProudectOrderResponse>> GetOrderProudectAgentDetailes(Guid Id);
        public Task<ApiResponse<List<OrderResponse>>> RequestOrder(List<ProudectOrderRequest> request, Guid PaymentId);
        public Task<ApiResponse<List<OrderResponse>>> RequestOrderAgent(List<ProudectAgentRequest> request, Guid PaymentId);
    }
}
