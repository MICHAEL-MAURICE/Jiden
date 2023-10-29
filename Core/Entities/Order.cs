using Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        [ForeignKey("PaymentMethod")]
        public Guid PaymentId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }

        
        public AppUser AppUser { get; set; }

        public int NumberOfProudects { get; set; }
        public  decimal TotalPrice { get; set; }
        public decimal FullJaidenMoney { get; set; }
        public int status { get; set; }
        [ForeignKey("Image")]
        public Guid ?ReceiptImage { get; set; }

        public Image? Image { get; set; }

        public ICollection<ProudectOrder> ProudectOrders { get; set; }

    }
}
