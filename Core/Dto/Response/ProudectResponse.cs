using Core.Dto.Request;
using Core.Entities;
using Core.Helper;
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
    public class ProudectResponse
    {
        public Guid Id { get; set; }
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
        public string? ProudectLicence { get; set; }
        [Required]
        //المادة الفعالة
        public string ActiveSubstances { get; set; }
        [Required]
        //عدد الاقراص
        public int NumberOfTablets { get; set; }
        [Required]
        //عدد وحدات التجزئة
        public int NumberOfRetailUnits { get; set; }
        [Required]
        //رقم التسجيل الضريبى
        public string TaxRegistrationNumber { get; set; }
        [Required]
        //سنة التسجيل الضريبي 
        public DateTime TaxRegistrationYear { get; set; }
        [Required]
        //جهة التسجيل الضريبي
        public string TaxRegistrationAuthority { get; set; }
        [Required]
        public string Discription { get; set; }
        [Required]
        public string InternationalBarcode { get; set; }
        [Required]
        public string pharmacology { get; set; }
        [Required]
        public bool AgentRequest { get; set; }

        [Required]
        public string? ProudectImage { get; set; }
        [Required]
       
        public Guid PharmaceuticalFormId { get; set; }
        public string PharmaceuticalFormName { get; set; }
        [Required]
       
        public Guid DiscriminationId { get; set; }
        public string DiscriminationName { get; set; }
        [Required]
        
        public string AppUserId { get; set; }
        public string AppUserNameInArabic { get; set; }
        public string AppUserNameInEnglish { get; set; }
        [Required]
       
        public Guid WayMedicineUsedId { get; set; }
        public string WayMedicineUsedName { get; set; }
        [Required]
      
        public Guid TypeOfMedicationId { get; set; }
        public string TypeOfMedicationName { get; set; }

        [Required]
 
        public List<MapLocationForProudect> GeographicalDistributionRanges { get; set; }




    }
}
