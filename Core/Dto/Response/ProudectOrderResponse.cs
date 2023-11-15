using Core.Entities;
using Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class ProudectOrderResponse
    {
        public Guid Id { get; set; }
        [ForeignKey("Proudect")]
        public Guid ProudectId { get; set; }
        public string NameInEnglish { get; set; }
        public string NameInArabic { get; set; }
     
        public Guid OrderId { get; set; }
     
        public int ProudectNumber { get; set; }

     
        public string sellerUser { get; set; }

       
        public int Status { get; set; }

        public decimal PricePerUnit { get; set; }

        public decimal JaidenMoney { get; set; }
        public decimal Price { get; set; }
    }
}
