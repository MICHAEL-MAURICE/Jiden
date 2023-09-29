using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PricingSettings
    {
        public Guid Id { get; set; }
        public decimal AdPricePerDay { get; set; }
        public int Type { get; set; }

        public  decimal ProudectPrice { get; set; }
        ICollection<Proudect> Proudects { get; set; }
        ICollection<Ad> Ads { get; set; }

    }
}
