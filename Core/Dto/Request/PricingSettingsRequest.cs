using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Request
{
    public class PricingSettingsRequest
    {
        public decimal AdPricePerDay { get; set; }
        public int Type { get; set; }
        public decimal ProudectPrice { get; set; }
    }
}
