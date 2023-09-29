using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Core.Mapping;

namespace Core.Dto.Response
{
    public class UserResponse
    {
        [Required]
        public string NameInArabic { get; set; }
        [Required]
        public string NameInEnglish { get; set; }
        [Required]
        public string Adress { get; set; }
        [Phone, Required]
        public string PhoneNumber { get; set; }

     
        [DataType(DataType.Url)]
        public string? Link { get; set; }
        public int Role { get; set; }
      
        public string? ProfileImage { get; set; }

      
        public List<GeographicalMapping> GeographicalDistributionRanges { get; set; }
        public List<proudectMapping>? Proudects { get; set; }
        public List<adsMapping>? Ads { get; set; }
        public List<PaymentMethod>? PaymentMethods { get; set; }
    }
}
