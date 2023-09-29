using Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public string PaymentName { get; set; }
        public string Discription { get; set; }
        public string PaymentValue { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        ICollection<Order> Orders { get; set; } 
    }
}
