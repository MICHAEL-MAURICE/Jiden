using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Request
{
    public class ProudectRequestUpdate
    {

       
       
            public string? NameInArabic { get; set; }
          
            public string ?NameInEnglish { get; set; }
         
            public decimal ?Price { get; set; }
            
            public string? FactoryNameInEnglish { get; set; }
            
            public string ?CompanyNameInEnglish { get; set; }

        public decimal ? Discount { get; set; }
        public string ?Discription { get; set; }
        
            public string ?InternationalBarcode { get; set; }
       
            public string? pharmacology { get; set; }
         
            public bool ?AgentRequest { get; set; }



            
            public string? ProudectImage { get; set; }
            
            public Guid ?PharmaceuticalFormId { get; set; }
           
            public Guid ?DiscriminationId { get; set; }
         
           
            

            public Guid ?WayMedicineUsedId { get; set; }
            
            public Guid ?TypeOfMedicationId { get; set; }

           
          //  public List<GeographicalDistributionRangUpdateRej> GeographicalDistributionRanges { get; set; }




        }
    public class GeographicalDistributionRangUpdateRej
    {
        public Guid Id { get; set; }
        public string City { get; set; }

        public string station { get; set; }


        public Guid GovernorateId { get; set; }
    }

}



