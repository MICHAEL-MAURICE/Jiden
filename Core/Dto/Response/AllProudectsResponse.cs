using Core.Entities;
using Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class AllProudectsResponse
    {
        public decimal? Discount { get; set; }
        public  Guid Id { get; set; }
        [Required]
        public string NameInArabic { get; set; }
        [Required]
        public string NameInEnglish { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string FactoryNameInEnglish { get; set; }
        [Required]
        public string CompanyNameInEnglish { get; set; }
        [Required]
   
       
        //المادة الفعالة
        public string ActiveSubstances { get; set; }
       
        [Required]
        public string Discription { get; set; }

        [Required]
        public bool AgentRequest { get; set; }

        [Required]
        public string? ProudectImage { get; set; }
        [Required]
        [JsonIgnore]
        public AppUser AppUser { get; set; }
       
    }
}
