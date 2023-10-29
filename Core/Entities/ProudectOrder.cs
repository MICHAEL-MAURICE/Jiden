using Core.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProudectOrder
    {
        public Guid Id  { get; set; }
        [ForeignKey("Proudect")]
        public Guid ProudectId { get; set; }
        public Proudect Proudect { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public int ProudectNumber { get; set; }

        [ForeignKey("AppUser")]
        public string sellerUser { get; set; }

        public AppUser AppUser { get; set; }
        public int Status { get; set; }

        public decimal PricePerUnit { get; set; }

        public decimal JaidenMoney { get; set; }
        public decimal Price { get  { return ProudectNumber * PricePerUnit;  } }

    }
}
