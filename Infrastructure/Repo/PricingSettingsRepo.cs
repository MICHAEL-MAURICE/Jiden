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
    public class PricingSettingsRepo : IPricingSettings
    {
        private readonly AppDbContext _Context;
        private readonly JwtTokenData _jwtTokenData;
        public PricingSettingsRepo(AppDbContext context, ITokenDecoder token)
        {
            _Context = context;
            _jwtTokenData = token.GetTokenData();
        }

        public async Task<ApiResponse> Create(PricingSettingsRequest request)
        {
            try
            {
                var PricingSetting = new PricingSettings()
                {
                    Id = Guid.NewGuid(),
                    ProudectPrice = request.ProudectPrice,
                    Type= request.Type,
                    AdPricePerDay = request.AdPricePerDay,

                };

                _Context.PricingSettings.Add(PricingSetting);
                _Context.SaveChanges();
                return new ApiResponse() {  isSuccess = true, Status = 200, Message = "This Price Setting Created Succefully" };
            }
            catch(Exception ex)
            {
                return new ApiResponse() {  isSuccess = false, Status = 500, Message = "This Price Setting not Created Succefully" };
            }
        }

        public async Task<ApiResponse<List<PricingSettingResponse>>> GetAll()
        {
           var PricingSeting =  await _Context.PricingSettings.Select(pric => new PricingSettingResponse() { 
            Id=pric.Id,
            PricePerDay=pric.AdPricePerDay,
            ProudectPrice=pric.ProudectPrice,
            Type=pric.Type,
            
            }).ToListAsync();

            if (PricingSeting.Any())
            {
                return new ApiResponse<List<PricingSettingResponse>>() { Data = PricingSeting, isSuccess = true, Status = 200, };
            }
            return new ApiResponse<List<PricingSettingResponse>>() { Data = new List<PricingSettingResponse>(), isSuccess = false, Status = 500};
        }

        public async Task<ApiResponse<PricingSettingResponse>> GetById(Guid Id)
        {
           var PricingSetting= await  _Context.PricingSettings.Where(Pric=>Pric.Id==Id).Select(
               
               Pric=>new PricingSettingResponse() { 
                   Id= Pric.Id,
                   PricePerDay=Pric.AdPricePerDay,
                   ProudectPrice=Pric.ProudectPrice,
                   Type=Pric.Type,
               }).FirstOrDefaultAsync();

            if(PricingSetting!=null)
            {
                return new ApiResponse<PricingSettingResponse>() { Data = PricingSetting, isSuccess = true, Status = 200 };  
            }
            return new ApiResponse<PricingSettingResponse>() { Data = null, isSuccess = false, Status = 500 };

        }

        public async Task<ApiResponse> Update(PricingSettingsRequest request)
        {
            var PricingSetting = await _Context.PricingSettings.FirstOrDefaultAsync(Pric => Pric.Id == request.Id);

            if(PricingSetting != null)
            {
                PricingSetting.ProudectPrice = request.ProudectPrice;
                PricingSetting.Type = request.Type; 
                PricingSetting.ProudectPrice=request.ProudectPrice;
                _Context.SaveChanges();
                return new ApiResponse() { isSuccess=true, Status = 200, 
                Message="Updated Successfuly"};
            }
            return new ApiResponse()
            {
                isSuccess = false,
                Status = 500,
                Message = "We Can't Update Pricing Setting"
            };

        }
    }
}
