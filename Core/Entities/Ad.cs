using Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Ad
    {
        public Guid Id { get; set; }
        [ForeignKey("Image")]
        public Guid ?AdImage { get; set; }
        public Guid ProudectId { get; set; }
        public string AppUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string  Description { get; set; }

        public Decimal Price { get {

                return PricingSettings.AdPricePerDay * (EndDate - StartDate).Days;
            } }
        public bool Active { get; set; }

        public AppUser AppUser { get; set; }
        public Proudect Proudect { get; set; }
        public Image Image { get; set; }

        [ForeignKey("PricingSettings")]
        public Guid PricingSettingsId { get; set; }
        public PricingSettings  PricingSettings { get; set; }



    }
}
