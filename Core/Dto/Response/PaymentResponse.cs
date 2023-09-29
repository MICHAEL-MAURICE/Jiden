using Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class PaymentResponse
    {
        public Guid Id { get; set; }
        public string PaymentName { get; set; }
        public string Discription { get; set; }
        public string PaymentValue { get; set; }
        public string AppUserId { get; set; }
        public string AppUserName { get; set; }
    }
}
