using Core.Dto.Request;
using Core.Entities;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPricingSettings
    {
        public Task<ApiResponse> Create(PricingSettingsRequest request);

        public Task<ApiResponse<decimal>> GetPriceOfProudect();

        public Task<ApiResponse<decimal>> GetPriceOfAd();
    }
}
