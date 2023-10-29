using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Identity
{
    public class AppUser:IdentityUser
    {
       
        [Required]
        public string NameInArabic { get; set; }
        [Required]
        public string NameInEnglish { get; set; }
        [Required]
        public string Adress { get;set; }
        [Phone,Required]
        public string PhoneNumber { get; set; }

        public decimal ?MoneyForJaiden { get; set; }
        public bool? IsActive { get; set; }
        [DataType(DataType.Url)]
        public string? Link { get; set; }
        public int Role { get; set; }
        [ForeignKey("Image")]
        public Guid ?ProfileImage { get; set; }
        
        public Image Image { get; set; }
        public ICollection<GeographicalDistributionRange> GeographicalDistributionRanges { get; set; }
        public ICollection<Proudect>? Proudects { get; set; }
        public ICollection<Ad> ?Ads { get; set; }
        public ICollection<Order> ?Orders { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<ProudectOrder>? ProudectOrders { get; set; }






    }
}
