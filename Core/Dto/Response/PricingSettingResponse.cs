using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class PricingSettingResponse
    {
        public Guid Id { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal ProudectPrice { get; set; }
        public int Type { get; set; }
    }
}
