using Core.Dto.Request;
using Core.Entities;
using Core.Helper;
using Core.Interfaces;
using Core.Jwt;
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

        public async Task<ApiResponse<decimal>> GetPriceOfAd()
        {
            var PriceOfAd = _Context.PricingSettings?.FirstOrDefault(pr => pr.Type == _jwtTokenData.Role)?.AdPricePerDay??null;
            if (PriceOfAd != null) {
            
            return new ApiResponse<decimal> { Data= PriceOfAd.Value,isSuccess= true ,Status=200};
            }
            return new ApiResponse<decimal> { isSuccess = false, Status = 500, Message = "we don't have Price For Ad" };
        }

        public async Task<ApiResponse<decimal>> GetPriceOfProudect()
        {
            var PriceOfProudect = _Context.PricingSettings?.FirstOrDefault(pr => pr.Type == _jwtTokenData.Role)?.ProudectPrice ?? null;
            if (PriceOfProudect != null)
            {

                return new ApiResponse<decimal> { Data = PriceOfProudect.Value, isSuccess = true, Status = 200 };
            }
            return new ApiResponse<decimal> { isSuccess = false, Status = 500, Message = "we don't have Price For Ad" };
        }
    }
}
