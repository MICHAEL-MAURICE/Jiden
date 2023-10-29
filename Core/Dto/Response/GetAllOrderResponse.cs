using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class GetAllOrderResponse
    {
        public Guid Id { get; set; }  
        public string UserId { get; set; }
        public string UserNameInArabic { get; set; }
        public string UserNameInEnglish { get; set; }
        public int NumberOfProudects { get; set; }
        public string PaymentName { get; set; }
        public Guid PaymentId { get; set; }
        public decimal TotalPrice { get; set; }

        public decimal JaidenMoney { get; set; }



    }
}
