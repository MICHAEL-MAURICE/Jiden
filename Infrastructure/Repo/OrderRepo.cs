using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.ImagesHandler;
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
    public class OrderRepo : IOrder
    {
        private readonly AppDbContext _Context;
        private readonly JwtTokenData _jwtTokenData;

        public OrderRepo(AppDbContext context, IRepositoryImages repositoryImages, ITokenDecoder token)
        {
            _Context = context;
            _jwtTokenData = token.GetTokenData();
        }


        public async  Task<ApiResponse<List<OrderResponse>>> RequestOrder(List<ProudectOrderRequest> request,Guid PaymentId)
        {

            bool AllProudectsAdded = true;
            var TotalPrice = 0.0;
            var ListOfProudects = new List<OrderResponse>();
            var transaction = _Context.Database.BeginTransaction();
            {
                try {

                    var orderItem = new Order()
                    {
                        Id= Guid.NewGuid(),
                        status=(int)Enums.OrderStatus.RequestOrder,
                        UserId=_jwtTokenData.UserId,
                        PaymentId=PaymentId,
                        NumberOfProudects=request.Count,
                        
                       
                    };

                    _Context.Orders.Add(orderItem); 
                    if (request.Any())
                    {
                       foreach(var ProudectItem in request)
                        {
                            var Proudect =  _Context.Proudects.Include(pro=>pro.AppUser).FirstOrDefault(pro=>pro.Id==ProudectItem.ProudectId);
                            if (Proudect != null)
                            {
                                var PriceSetting = _Context.PricingSettings.FirstOrDefault(psett=>psett.Type==Proudect.AppUser.Role);
                                var ProudectCount = Proudect.NumberOfRetailUnits - ProudectItem.ProudectCount;
                                if (ProudectCount > 0)
                                {
                                    Proudect.NumberOfRetailUnits -= ProudectItem.ProudectCount;

                                    var ProudectOrder = new ProudectOrder()
                                    {
                                        Id = Guid.NewGuid(),
                                        ProudectId = Proudect.Id,
                                        ProudectNumber = ProudectItem.ProudectCount,
                                        PricePerUnit = Proudect.Price,
                                        sellerUser = Proudect.AppUser.Id,
                                        JaidenMoney=Proudect.Price * PriceSetting.ProudectPrice,
                                        OrderId= orderItem.Id

                                    };

                                    Proudect.AppUser.MoneyForJaiden += ProudectOrder.JaidenMoney;

                                    orderItem.TotalPrice += ProudectOrder.PricePerUnit;
                                    orderItem.FullJaidenMoney+= ProudectOrder.JaidenMoney;

                                    
                                    _Context.ProudectOrders.Add(ProudectOrder);
                                }

                                else
                                {
                                    ListOfProudects.Add(new OrderResponse() { 
                                    Id=Proudect.Id,
                                    NameInArabic=Proudect.NameInArabic,
                                    NameInEnglish=Proudect.NameInEnglish,   
                                    NumberOfItems=Proudect.NumberOfRetailUnits
                                    
                                    });
                                    AllProudectsAdded = false;
                                }
                            }

                        }


                    }





                    if (!AllProudectsAdded)
                        return new ApiResponse<List<OrderResponse>>()
                        {
                            Data = ListOfProudects,
                            Status = 200,
                            isSuccess = false,
                            Message = "We Can't make this ordr because we don't have engph units from this Proudects  "
                        };

                  
                 await _Context.SaveChangesAsync();
                transaction.Commit();
                    return new ApiResponse<List<OrderResponse>>()
                    {
                        Data = new List<OrderResponse>(),
                        Status = 200,
                        isSuccess = true,
                        Message = "Order Added Successfully"
                    };
                }
                catch (Exception ex) { 
                
                transaction.Rollback();
                }
                return new ApiResponse<List<OrderResponse>>()
                {
                    Data = new List<OrderResponse>(),
                    Status = 500,
                    isSuccess = false,
                    Message = "Order not Added Successfully"
                };
            }

            throw new NotImplementedException();
        }

       
    }
}
