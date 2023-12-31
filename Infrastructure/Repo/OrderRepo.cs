﻿using Core.Dto.Request;
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
using static Core.Helper.Enums;
using static Core.ImagesHandler.ImagesRepository;

namespace Infrastructure.Repo
{
    public class OrderRepo : IOrder
    {
        private readonly AppDbContext _Context;
        private readonly JwtTokenData _jwtTokenData;
        private readonly IRepositoryImages _repositoryImages;

        public OrderRepo(AppDbContext context, IRepositoryImages repositoryImages, ITokenDecoder token)
        {
            _Context = context;
            _jwtTokenData = token.GetTokenData();
            _repositoryImages = repositoryImages;
        }
        public async Task<ApiResponse<List<GetAllOrderResponse>>> GetOrdersByusingStatus( int status)
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == status).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>()
                    {
                        Data = Orders,
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Need To Attach Image Orders Successfully"
                    };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Need To Attach Image Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }

        }

        public async Task<ApiResponse<List<GetAllOrderResponse>>> GetneedToAttachImageOrders()
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.needToAttachImage).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>()
                    {
                        Data = Orders,
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Need To Attach Image Orders Successfully"
                    };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Need To Attach Image Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }
        public async Task<ApiResponse<List<GetAllOrderResponse>>> GetpaidOrders()
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.paid).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>() {
                        Data = Orders, isSuccess = true, Status = 200, Message = "Get paid Orders Successfully"
                    };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any paid Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<List<GetAllOrderResponse>>> GetpartialApprovalOrders()
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.partialApproval).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>() { 
                        Data = Orders, isSuccess = true, Status = 200, Message = "Get partialApproval Orders Successfully"
                    };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any partialApproval Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<List<GetAllOrderResponse>>> GetPendingOrders()
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.pennding).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>() {
                        Data = Orders, isSuccess = true, Status = 200, Message = "Get Pending Orders Successfully" };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Pending Orders"
                };
            }
            catch ( Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }

          
        }

        public async Task<ApiResponse<List<GetAllOrderResponse>>> GetRejectedOrders()
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.rejected).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>() {
                        Data = Orders, isSuccess = true, Status = 200, Message = "Get Rejected Orders Successfully"
                    };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Rejected Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }


        public async Task<ApiResponse<GetOrdersforUser>> GetneedToAttachImageOrdersForUser()
        {
            try
            {
                decimal TotalPrice = 0;
               decimal JaidenMoney = 0;
                
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.needToAttachImage && order.UserId==_jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    
                    foreach (var order in Orders) {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }




                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders=Orders,JaidenMoney=JaidenMoney,Price=TotalPrice},
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Need To Attach Image Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Need To Attach Image Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }
        public async Task<ApiResponse<GetOrdersforUser>> GetpaidOrdersForUser()
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.paid && order.UserId==_jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }

                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get paid Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any paid Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetpartialApprovalOrdersForUser()
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;

                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.partialApproval && order.UserId == _jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }
                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get partialApproval Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any partialApproval Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetPendingOrdersForUser()
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.pennding && order.UserId == _jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }
                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Pending Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Pending Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetRejectedOrdersForUser()
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.rejected && order.UserId == _jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }

                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Rejected Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Rejected Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }


        public async Task<ApiResponse<GetOrdersforUser>> GetneedToAttachImageOrdersForUser(string Id)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.needToAttachImage && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }
                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Need To Attach Image Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Need To Attach Image Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }
        public async Task<ApiResponse<GetOrdersforUser>> GetpaidOrdersForUser(string Id)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.paid && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }

                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get paid Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any paid Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetpartialApprovalOrdersForUser(string Id)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.partialApproval && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }

                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get partialApproval Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any partialApproval Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetPendingOrdersForUser(string Id)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.pennding && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }

                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Pending Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Pending Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetRejectedOrdersForUser(string Id)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.rejected && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice= order.TotalPrice,
                        JaidenMoney=order.FullJaidenMoney
                       

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }
                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Rejected Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Rejected Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }


        public async  Task<ApiResponse<List<OrderResponse>>> RequestOrder(List<ProudectOrderRequest> request,Guid PaymentId)
        {

            bool AllProudectsAdded = true;
          
            var ListOfProudects = new List<OrderResponse>();
            var transaction = _Context.Database.BeginTransaction();
            {
                try {

                    var orderItem = new Order()
                    {
                        Id= Guid.NewGuid(),
                        status=(int)Enums.OrderStatus.needToAttachImage,
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

                                    var ProudectOrder = new Core.Entities.ProudectOrder()
                                    {
                                        Id = Guid.NewGuid(),
                                        ProudectId = Proudect.Id,
                                        ProudectNumber = ProudectItem.ProudectCount,
                                        PricePerUnit = (decimal)(Proudect.Discount!=null? Proudect.Price*Proudect.Discount:Proudect.Price),
                                        sellerUser = Proudect.AppUser.Id,
                                        JaidenMoney=Proudect.Price * PriceSetting.ProudectPrice,
                                        OrderId= orderItem.Id,
                                        Status=(int)Enums.ProudectOrder.pennding
                                        

                                    };

                                    Proudect.AppUser.MoneyForJaiden += ProudectOrder.JaidenMoney;

                                    orderItem.TotalPrice += (decimal)(Proudect.Discount != null ? Proudect.Price * Proudect.Discount : Proudect.Price);
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
                        Data = new List<OrderResponse>()
                        {
                            new OrderResponse(){ 
                            OrderId=orderItem.Id
                            }
                        },
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
        }

        public async Task<ApiResponse> UploadReceiptImage(OrderReceiptRequest request)
        {

            var transaction = _Context.Database.BeginTransaction();

            {
                try
                {

                    var ReceiptImage = _repositoryImages.AddImage(request.ReceiptImage, (int)ImageTypes.ReceiptOrder);
                    var ImageDbReceipt = new Image() { Id = ReceiptImage.ImageId, Path = ReceiptImage.Fullpath, Type = (int)ImageTypes.news };

                    _Context.Images.Add(ImageDbReceipt);

                   
                    var Order = _Context.Orders.FirstOrDefault(ord => ord.Id == request.OrderId);
                    if (Order != null)
                    {
                        Order.ReceiptImage = ReceiptImage.ImageId;
                        Order.status = (int)Enums.OrderStatus.pennding;
                    }
                    else
                    {
                        return new ApiResponse() { isSuccess = false, Status = 200, Message = "We Don't have this Order" };
                    }

                    _Context.SaveChanges();
                    transaction.Commit();

                    return  new ApiResponse() { isSuccess = true,Status=200,Message= "We Added Receipt Successfully" };

                }
                catch (Exception ex) {

                    transaction.Rollback();
                    return new ApiResponse() { isSuccess = false, Status = 500, Message = "We Have An Error" };

                }

            }
         
        }

        public async Task<ApiResponse<OrderDetailesResponse>> GetOrderDetailes(Guid Id)
        {
            var OrderRequest = _Context.Orders.Include(ord => ord.AppUser)
                .Include(ord => ord.Image).Include(ord => ord.PaymentMethod).Include(ord => ord.ProudectOrders).ThenInclude(prOrder => prOrder.Proudect)
                .Where(order => order.Id == Id).Select(order => new OrderDetailesResponse() { 
                
                Id=order.Id,
                PaymentId=order.PaymentId,
                PaymentName=order.PaymentMethod.PaymentName,
                NumberOfProudects=order.NumberOfProudects,
                FullJaidenMoney=order.FullJaidenMoney,
                status=  order.status,
                TotalPrice=order.TotalPrice,
                UserId=order.UserId,
                UserName=order.AppUser.UserName,
                
                ReceiptImage= ImagesUtilities.GetImage(order.Image.Path),
                ProudectOrders= (List<ProudectOrderResponse>)order.ProudectOrders.Select(proOrder=>new ProudectOrderResponse { 
                Id=proOrder.Id,
                PricePerUnit=proOrder.PricePerUnit,
                ProudectId=proOrder.ProudectId, 
                ProudectNumber=proOrder.ProudectNumber,
                JaidenMoney=proOrder.JaidenMoney,
                Status= proOrder.Status,
                NameInArabic=proOrder.Proudect.NameInArabic,
                NameInEnglish=proOrder.Proudect.NameInEnglish,
                OrderId=order.Id,
                Price= proOrder.ProudectNumber * proOrder.PricePerUnit


        })
                }).FirstOrDefault();


            if (OrderRequest != null)
                return new ApiResponse<OrderDetailesResponse>() {
                    Data = OrderRequest, Status = 200, isSuccess = true, Message = "We Found Order Detailes Successfully" };

            else return new ApiResponse<OrderDetailesResponse>()
            {
                Data = null,
                Status = 200,
                isSuccess = false,
                Message = "We Don't Found Order Detailes Successfully"
            };




            throw new NotImplementedException();
        }

        public  async Task<ApiResponse<ProudectOrderResponse>> GetOrderProudectDetailes(Guid Id)
        {

            var orderProudect = _Context.ProudectOrders.Include(Pro => Pro.AppUser).Include(Pro => Pro.Proudect)
                .Where(pro => pro.Id == Id).Select(pro => new ProudectOrderResponse() {

                    Id = pro.Id,
                    PricePerUnit = pro.PricePerUnit,
                    ProudectId = pro.ProudectId,
                    ProudectNumber = pro.ProudectNumber,
                    JaidenMoney = pro.JaidenMoney,
                    Status =  pro.Status,
                    NameInArabic = pro.Proudect.NameInArabic,
                    NameInEnglish = pro.Proudect.NameInEnglish,
                    OrderId = pro.Id,
                    Price = pro.ProudectNumber * pro.PricePerUnit



                }).FirstOrDefault();

            if (orderProudect != null)
                return new ApiResponse<ProudectOrderResponse>() {
                Data=orderProudect,Status=200,isSuccess=true,Message="We Get The Data Successfully"
                };
            else
            return new ApiResponse<ProudectOrderResponse>()
            {
                Data = null,
                Status = 200,
                isSuccess = false,
                Message = "We Can't Get The Data Successfully"
            };
        }



        public async Task<ApiResponse<Guid>> ChangeOrderAgentStatus(ChangeOrderStatusRequest requestDto)
        {


            var Transaction = await _Context.Database.BeginTransactionAsync();
            {



                try
                {
                    foreach (var ProudectOrderitem in requestDto.ProudectOrderList)
                    {
                        var ProudecttRequest = await _Context.ProudectAgents.
                            Include(pro=>pro.GeographicalDistributionRangeForAgent).
                            Include(pro=>pro.Proudect).ThenInclude(Geo=>Geo.GeographicalDistributionRanges)
                            .FirstOrDefaultAsync(pr => pr.Id == ProudectOrderitem.Id);

                        ProudecttRequest.Status = ProudectOrderitem.ProudectOrderStatus;
                        if (ProudectOrderitem.ProudectOrderStatus == (int)Enums.ProudectOrder.rejectedAgent)
                        {
                            foreach (var item in ProudecttRequest.GeographicalDistributionRangeForAgent) {
                                var GeoItem = _Context.GeographicalDistributionRanges.FirstOrDefault(item => item.ProudectAgentId == ProudecttRequest.Id &&
                                           item.GovernorateId == item.GovernorateId
  
                                           && item.City == item.City && item.station == item.station);

                                _Context.GeographicalDistributionRanges.Remove(GeoItem);
                                GeoItem.ProudectAgentId = Guid.Empty;
                                GeoItem.ProudectId = ProudecttRequest.ProudectId;
                                _Context.GeographicalDistributionRanges.Add(GeoItem);
                            }

                        }

                    }

                    var Order = await _Context.Orders.FirstOrDefaultAsync(re => re.Id == requestDto.Id);

                    Order.status = requestDto.OrderStatus;



                    _Context.SaveChanges();

                    Transaction.CommitAsync();

                    return new ApiResponse<Guid>() { Data = Order.Id, isSuccess = true, Message = $"We{Enum.GetName(typeof(OrderStatus), requestDto.OrderStatus)}  Requestes ", Status = 200 };
                }
                catch (Exception ex)
                {
                    Transaction.RollbackAsync();
                    return new ApiResponse<Guid>() { isSuccess = false, Message = "there is an Error", Status = 200 };
                }
                throw new NotImplementedException();
            }
        }



        public async Task<ApiResponse<Guid>> ChangeOrderStatus(ChangeOrderStatusRequest requestDto)
        {
            

            var Transaction = await _Context.Database.BeginTransactionAsync();
            {



                try
                {
                    foreach (var ProudectOrderitem in requestDto.ProudectOrderList)
                    {
                        var ProudecttRequest = await _Context.ProudectOrders.FirstOrDefaultAsync(pr => pr.Id == ProudectOrderitem.Id);

                        ProudecttRequest.Status = ProudectOrderitem.ProudectOrderStatus;
                    
                    }

                    var Order = await _Context.Orders.FirstOrDefaultAsync(re => re.Id == requestDto.Id);

                    Order.status = requestDto.OrderStatus;
                  


                    _Context.SaveChanges();

                    Transaction.CommitAsync();

                    return new ApiResponse<Guid>() { Data=Order.Id,isSuccess = true, Message =  $"We{Enum.GetName(typeof(OrderStatus),requestDto.OrderStatus)}  Requestes ", Status = 200 };
                }
                catch (Exception ex)
                {
                    Transaction.RollbackAsync();
                    return new ApiResponse<Guid>() { isSuccess = false, Message = "there is an Error", Status = 200 };
                }
                throw new NotImplementedException();
            }
        }

        public async Task<ApiResponse<List<OrderResponse>>> RequestOrderAgent(List<ProudectAgentRequest> request, Guid PaymentId)
        {

            bool AllProudectsAdded = true;

            var ListOfProudects = new List<OrderResponse>();
            var transaction = _Context.Database.BeginTransaction();
            {
                try
                {

                    var orderItem = new Order()
                    {
                        Id = Guid.NewGuid(),
                        status = (int)Enums.OrderStatus.needToAttachImageAgent,
                        UserId = _jwtTokenData.UserId,
                        PaymentId = PaymentId,
                        NumberOfProudects = request.Count,


                    };

                    _Context.Orders.Add(orderItem);
                    if (request.Any())
                    {
                        foreach (var ProudectItem in request)
                        {
                            var Proudect = _Context.Proudects.Include(pro => pro.AppUser).Include(pro=>pro.GeographicalDistributionRanges).FirstOrDefault(pro => pro.Id == ProudectItem.ProudectId);
                            if (Proudect != null)
                            {
                                var PriceSetting = _Context.PricingSettings.FirstOrDefault(psett => psett.Type == Proudect.AppUser.Role);
                                var ProudectCount = Proudect.NumberOfRetailUnits - ProudectItem.ProudectCount;
                                if (ProudectCount > 0)
                                {
                                    Proudect.NumberOfRetailUnits -= ProudectItem.ProudectCount;

                                    var ProudectAgent = new Core.Entities.ProudectAgent();

                                    ProudectAgent.Id = Guid.NewGuid();
                                    ProudectAgent.ProudectId = Proudect.Id;
                                    ProudectAgent.ProudectNumber = ProudectItem.ProudectCount;
                                    ProudectAgent.PricePerUnit = (decimal)(Proudect.AgentDiscount != null && Proudect.AgentDiscount != 0 ? Proudect.Price * Proudect.AgentDiscount : Proudect.Price);

                                    ProudectAgent.sellerUser = Proudect.AppUser.Id;
                                    ProudectAgent.JaidenMoney = Proudect.Price * PriceSetting?.ProudectPrice;
                                    ProudectAgent.OrderId = orderItem.Id;
                                    ProudectAgent.Status = (int)Enums.ProudectOrder.penndingAgent;

                                   

                                    foreach(var Geoloc in ProudectItem.GeographicalDistributionRanges)
                                    {
                                        var Geographic = new GeographicalDistributionRange()
                                        {
                                            Id=Guid.NewGuid(),
                                            ProudectAgentId= ProudectAgent.Id,
                                            station=Geoloc.station,
                                            City=Geoloc.City,
                                            GovernorateId=Geoloc.GovernorateId,
                                           

                                        };
                                        var GeoItem = _Context.GeographicalDistributionRanges.FirstOrDefault(item => item.ProudectId == Proudect.Id &&
                                        item.GovernorateId == Geoloc.GovernorateId
                                        && item.City == Geoloc.City && item.station == Geoloc.station);
                                       _Context.GeographicalDistributionRanges.Remove(GeoItem); 
                                        _Context.GeographicalDistributionRanges.Add(Geographic);
                                    }

                                    Proudect.AppUser.MoneyForJaiden += ProudectAgent.JaidenMoney;

                                    orderItem.TotalPrice += (decimal)(Proudect.AgentDiscount != null && Proudect.AgentDiscount != 0 ? Proudect.Price * Proudect.AgentDiscount : Proudect.Price);
                                    orderItem.FullJaidenMoney += ProudectAgent.JaidenMoney ?? 0;



                                    _Context.ProudectAgents.Add(ProudectAgent);
                                    _Context.SaveChanges();
                                }

                                else
                                {
                                    ListOfProudects.Add(new OrderResponse()
                                    {
                                        Id = Proudect.Id,
                                        NameInArabic = Proudect.NameInArabic,
                                        NameInEnglish = Proudect.NameInEnglish,
                                        NumberOfItems = Proudect.NumberOfRetailUnits

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
                        Data = new List<OrderResponse>()
                        {
                            new OrderResponse(){
                            OrderId=orderItem.Id
                            }
                        },
                        Status = 200,
                        isSuccess = true,
                        Message = "Order Added Successfully"
                    };
                }
                catch (Exception ex)
                {

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
        }

        public  async Task<ApiResponse<List<GetAllOrderResponse>>> GetPendingOrdersAgent()
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.penndingAgent).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>()
                    {
                        Data = Orders,
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Pending Orders Successfully"
                    };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Pending Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<List<GetAllOrderResponse>>> GetRejectedOrdersAgent()
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.rejectedAgent).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>()
                    {
                        Data = Orders,
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Rejected Orders Successfully"
                    };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Rejected Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }
        }

        public async Task<ApiResponse<List<GetAllOrderResponse>>> GetpaidOrdersAgent()
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.PaidAgent).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>()
                    {
                        Data = Orders,
                        isSuccess = true,
                        Status = 200,
                        Message = "Get paid Orders Successfully"
                    };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any paid Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }
        }

        public async Task<ApiResponse<List<GetAllOrderResponse>>> GetneedToAttachImageOrdersAgent()
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.needToAttachImageAgent).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>()
                    {
                        Data = Orders,
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Need To Attach Image Orders Successfully"
                    };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Need To Attach Image Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }
        }

        public async Task<ApiResponse<List<GetAllOrderResponse>>> GetpartialApprovalOrdersAgent()
        {
            try
            {
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.partialApprovalAgent).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    return new ApiResponse<List<GetAllOrderResponse>>()
                    {
                        Data = Orders,
                        isSuccess = true,
                        Status = 200,
                        Message = "Get partialApproval Orders Successfully"
                    };
                }

                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any partialApproval Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllOrderResponse>>()
                {
                    Data = new List<GetAllOrderResponse>(),
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetPendingOrdersAgentForUser()
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.penndingAgent && order.UserId == _jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }
                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Pending Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Pending Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }

        }

        public async Task<ApiResponse<GetOrdersforUser>> GetRejectedOrdersAgentForUser()
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.rejectedAgent && order.UserId == _jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }

                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Rejected Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Rejected Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }

        }

        public async Task<ApiResponse<GetOrdersforUser>> GetpaidOrdersAgentForUser()
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.PaidAgent && order.UserId == _jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }

                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get paid Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any paid Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }
        }

        public async Task<ApiResponse<GetOrdersforUser>> GetneedToAttachImageOrdersAgentForUser()
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;

                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.needToAttachImageAgent && order.UserId == _jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }




                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Need To Attach Image Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Need To Attach Image Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetpartialApprovalOrdersAgentForUser()
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;

                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.partialApprovalAgent && order.UserId == _jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }
                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get partialApproval Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any partialApproval Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }

        }

        public async Task<ApiResponse<GetOrdersforUser>> GetneedToAttachImageOrdersAgentForUser(string Id)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.needToAttachImageAgent && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }
                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Need To Attach Image Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Need To Attach Image Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }
        public async Task<ApiResponse<GetOrdersforUser>> GetpaidOrdersAgentForUser(string Id)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.PaidAgent && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }

                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get paid Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any paid Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetpartialApprovalOrdersAgentForUser(string Id)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.partialApprovalAgent && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }

                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get partialApproval Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any partialApproval Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetPendingOrdersAgentForUser(string Id)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.penndingAgent && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }

                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Pending Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Pending Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }

        public async Task<ApiResponse<GetOrdersforUser>> GetRejectedOrdersAgentForUser(string Id)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == (int)Enums.OrderStatus.rejectedAgent && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney


                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }
                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Rejected Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Rejected Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }


        }


        public async Task<ApiResponse<OrderDetailesResponse>> GetOrderAgentDetailes(Guid Id)
        {
            var OrderRequest = _Context.Orders.Include(ord => ord.AppUser)
                .Include(ord => ord.Image).Include(ord => ord.PaymentMethod).Include(ord => ord.proudectAgents).ThenInclude(prOrder => prOrder.Proudect)
                .Where(order => order.Id == Id).Select(order => new OrderDetailesResponse()
                {

                    Id = order.Id,
                    PaymentId = order.PaymentId,
                    PaymentName = order.PaymentMethod.PaymentName,
                    NumberOfProudects = order.NumberOfProudects,
                    FullJaidenMoney = order.FullJaidenMoney,
                    status =  order.status,
                    TotalPrice = order.TotalPrice,
                    UserId = order.UserId,
                    UserName = order.AppUser.UserName,

                    ReceiptImage = ImagesUtilities.GetImage(order.Image.Path),
                    ProudectOrders = (List<ProudectOrderResponse>)order.proudectAgents.Select(proOrder => new ProudectOrderResponse
                    {
                        Id = proOrder.Id,
                        PricePerUnit = proOrder.PricePerUnit,
                        ProudectId = proOrder.ProudectId,
                        ProudectNumber = proOrder.ProudectNumber,
                        JaidenMoney = (decimal)proOrder.JaidenMoney,
                        Status =  proOrder.Status,
                        NameInArabic = proOrder.Proudect.NameInArabic,
                        NameInEnglish = proOrder.Proudect.NameInEnglish,
                        OrderId = order.Id,
                        Price = proOrder.ProudectNumber * proOrder.PricePerUnit


                    })
                }).FirstOrDefault();


            if (OrderRequest != null)
                return new ApiResponse<OrderDetailesResponse>()
                {
                    Data = OrderRequest,
                    Status = 200,
                    isSuccess = true,
                    Message = "We Found Order Detailes Successfully"
                };

            else return new ApiResponse<OrderDetailesResponse>()
            {
                Data = null,
                Status = 200,
                isSuccess = false,
                Message = "We Don't Found Order Detailes Successfully"
            };




            throw new NotImplementedException();
        }

        public async Task<ApiResponse<ProudectOrderResponse>> GetOrderProudectAgentDetailes(Guid Id)
        {

            var orderProudect = _Context.ProudectAgents.Include(Pro => Pro.AppUser).Include(Pro => Pro.Proudect)
                .Where(pro => pro.Id == Id).Select(pro => new ProudectOrderResponse()
                {

                    Id = pro.Id,
                    PricePerUnit = pro.PricePerUnit,
                    ProudectId = pro.ProudectId,
                    ProudectNumber = pro.ProudectNumber,
                    JaidenMoney = (decimal)pro.JaidenMoney,
                    Status =  pro.Status,
                    NameInArabic = pro.Proudect.NameInArabic,
                    NameInEnglish = pro.Proudect.NameInEnglish,
                    OrderId = pro.Id,
                    Price = pro.ProudectNumber * pro.PricePerUnit



                }).FirstOrDefault();

            if (orderProudect != null)
                return new ApiResponse<ProudectOrderResponse>()
                {
                    Data = orderProudect,
                    Status = 200,
                    isSuccess = true,
                    Message = "We Get The Data Successfully"
                };
            else
                return new ApiResponse<ProudectOrderResponse>()
                {
                    Data = null,
                    Status = 200,
                    isSuccess = false,
                    Message = "We Can't Get The Data Successfully"
                };
        }

        public async Task<ApiResponse<GetOrdersforUser>> GetOrdersForUser(int status)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;

                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == status && order.UserId == _jwtTokenData.UserId).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney

                    }).ToList();

                if (Orders.Any())
                {

                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }




                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Need To Attach Image Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Need To Attach Image Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }

        }

        public async Task<ApiResponse<GetOrdersforUser>> GetOrdersForUser(string Id, int Status)
        {
            try
            {
                decimal TotalPrice = 0;
                decimal JaidenMoney = 0;
                var Orders = _Context.Orders.Include(ord => ord.AppUser).
                    Include(ord => ord.PaymentMethod).
                    Where(order => order.status == Status && order.UserId == Id).Select(order =>
                    new GetAllOrderResponse()
                    {
                        Id = order.Id,
                        PaymentId = order.PaymentId,
                        PaymentName = order.PaymentMethod.PaymentName,
                        NumberOfProudects = order.NumberOfProudects,
                        UserNameInArabic = order.AppUser.NameInArabic,
                        UserId = order.AppUser.Id,
                        UserNameInEnglish = order.AppUser.NameInEnglish,
                        TotalPrice = order.TotalPrice,
                        JaidenMoney = order.FullJaidenMoney


                    }).ToList();

                if (Orders.Any())
                {
                    foreach (var order in Orders)
                    {
                        TotalPrice += order.TotalPrice;
                        JaidenMoney += order.JaidenMoney;



                    }
                    return new ApiResponse<GetOrdersforUser>()
                    {
                        Data = new GetOrdersforUser() { AllOrders = Orders, JaidenMoney = JaidenMoney, Price = TotalPrice },
                        isSuccess = true,
                        Status = 200,
                        Message = "Get Rejected Orders Successfully"
                    };
                }

                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = true,
                    Status = 200,
                    Message = "We Don't have any Rejected Orders"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrdersforUser>()
                {
                    Data = null,
                    isSuccess = false,
                    Status = 500,
                    Message = "There are an issue in Order"
                };
            }
        }
    }


}
