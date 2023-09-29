using Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Proudect
    {
        public Guid Id { get; set; }
        public string  NameInArabic { get; set; }
        public string NameInEnglish { get; set; }
        public decimal Price { get; set; }
        public string FactoryNameInEnglish { get; set; }
        public string CompanyNameInEnglish { get; set; }

        //public string? ProudectLicence { get; set; }
        //المادة الفعالة
        public string ActiveSubstances { get; set; }
        //عدد الاقراص
        public int NumberOfTablets { get; set; }
        //عدد وحدات التجزئة
        public int NumberOfRetailUnits { get; set; }
        //رقم التسجيل الضريبى
        public string TaxRegistrationNumber { get; set; }
        //سنة التسجيل الضريبي 
        public DateTime TaxRegistrationYear { get; set; }
        //جهة التسجيل الضريبي
        public string TaxRegistrationAuthority { get; set; }
        public string Discription { get; set; }
        public string InternationalBarcode { get; set; }
        public string pharmacology { get; set; }
        public int Priority { get; set; }
        public bool AgentRequest { get; set; }
        public bool ActiveProudect { get; set; }
        public decimal? Discount { get; set; }
        public decimal? AgentDiscount { get; set; }
        public decimal? ServiceAmount { get {

                return  PricingSettings?.ProudectPrice * Price ??null;


            } }

        //  public Guid? ProudectImage { get; set; }
        public Guid PharmaceuticalFormId { get; set; }
        public Guid DiscriminationId { get; set; }
        public string AppUserId { get; set; }

        public Guid WayMedicineUsedId { get; set; }
        public Guid TypeOfMedicationId { get; set; }
        public Guid? PricingSettingsId { get; set; }

        public ICollection<Image> Images { get; set; }
  
        public ICollection<GeographicalDistributionRange> GeographicalDistributionRanges { get; set; }


     
        public PharmaceuticalForm PharmaceuticalForm { get; set; }
       

        public TypeOfMedication TypeOfMedication { get; set; }
     
        public WayMedicineUsed WayMedicineUsed { get; set; }
      
        public Discrimination Discrimination { get; set; }
  
        public AppUser AppUser { get; set; }
       
        public Ad Ad { get; set; }
  
        public PricingSettings ?PricingSettings { get; set; }
        public ICollection<ProudectOrder> ProudectOrders { get; set; }

    }
}
