using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Request
{
    public class PaymentRequest
    {
        public Guid? Id { get; set; }
        public string PaymentName { get; set; }
        public string Discription { get; set; }
        public string PaymentValue { get; set; }

    }
}
