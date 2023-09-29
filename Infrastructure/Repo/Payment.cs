using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.Interfaces;
using Core.Jwt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class Payment : IPayment
    {
        private readonly AppDbContext _context;
        private readonly JwtTokenData _jwtTokenData;
        public Payment(AppDbContext context,ITokenDecoder token)
        {
            _context= context;
            _jwtTokenData=token.GetTokenData();

        }
        public async Task<ApiResponse> Create(PaymentRequest payment)
        {
            try
            {
                var Payment = new PaymentMethod()
                {
                    Id = Guid.NewGuid(),
                    PaymentName = payment.PaymentName,
                    PaymentValue = payment.PaymentValue,
                    Discription = payment.Discription,
                    AppUserId = _jwtTokenData.UserId
                };

                _context.PaymentMethods.AddAsync(Payment);
                _context.SaveChangesAsync();
                return new ApiResponse(){ isSuccess= true ,Message="Payment Created Sucssesfully", Status=200};
            } catch(Exception ex) {

                return new ApiResponse() { isSuccess = false, Message = "Payment not Created Sucssesfully", Status = 500 };
            }
        }

        public async Task<ApiResponse> Delete(Guid Id)
        {
            try { 
            var Payment=_context.PaymentMethods.FirstOrDefault(x => x.Id==Id);
                _context.Remove(Payment);
                _context.SaveChangesAsync();
                return new ApiResponse() { isSuccess = true, Status = 200, Message = "This Payment Was Deleted" };
            
            }catch(Exception ex) {

                return new ApiResponse() { isSuccess = false, Status = 500, Message = "This Payment Was not Deleted" };

            }

        }

        public  async Task<ApiResponse<List<PaymentResponse>>> GetAll()
        {
            var PaymentList= _context.PaymentMethods.Include(pay=>pay.AppUser).Select(Paym=>
            new PaymentResponse() { 
                Id=Paym.Id, AppUserId=_jwtTokenData.UserId,PaymentName=Paym.PaymentName,AppUserName=Paym.AppUser.UserName,
                Discription=Paym.Discription,PaymentValue=Paym.PaymentValue       
            }).ToList();
            if(PaymentList.Any())
            return new ApiResponse<List<PaymentResponse>>() { Data= PaymentList ,Message="This all Payments",Status=200,isSuccess=true};

            return new ApiResponse<List<PaymentResponse>>() { Data = new List<PaymentResponse>(), Message = "We Don't have Data", Status = 500, isSuccess = false };

        }


        public async Task<ApiResponse<List<PaymentResponse>>> GetByUserId()
        {

            var PaymentList = _context.PaymentMethods.Include(pay => pay.AppUser).Where(pay=>pay.AppUserId==_jwtTokenData.UserId).Select(Paym =>
             new PaymentResponse()
             {
                 Id = Paym.Id,
                 AppUserId = _jwtTokenData.UserId,
                 PaymentName = Paym.PaymentName,
                 AppUserName = Paym.AppUser.UserName,
                 Discription = Paym.Discription,
                 PaymentValue = Paym.PaymentValue
             }).ToList();
            if (PaymentList.Any())
                return new ApiResponse<List<PaymentResponse>>() { Data = PaymentList, Message = "This all Payments", Status = 200, isSuccess = true };

            return new ApiResponse<List<PaymentResponse>>() { Data = new List<PaymentResponse>(), Message = "We Don't have Data", Status = 500, isSuccess = false };

        }

        public async Task<ApiResponse<PaymentResponse>> Update(PaymentRequest request)
        {
            var payment =  _context.PaymentMethods.FirstOrDefault(py => py.Id == request.Id);
            if (payment != null)
            {
                payment.Discription = request.Discription;
                payment.PaymentValue = request.PaymentValue;
                payment.PaymentName = request.PaymentName;
                _context.SaveChangesAsync();
                return new ApiResponse<PaymentResponse>() { Data = new PaymentResponse {Id=payment.Id,
                    AppUserId=payment.AppUserId,AppUserName=payment.PaymentName,Discription=payment.Discription,
                    PaymentName=payment.PaymentName,PaymentValue=payment.PaymentValue },isSuccess=true,Status=200,Message="Your Payment Updated" };
            }


            return new ApiResponse<PaymentResponse>() { Data = null, isSuccess = false, Status = 500, Message = "There is an Error " };
            
        }
    }
}
