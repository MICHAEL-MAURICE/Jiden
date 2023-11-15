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
    public class OrderDetailesResponse
    {
        public Guid Id { get; set; }

        public Guid PaymentId { get; set; }
        public string  PaymentName { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
        public int NumberOfProudects { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal FullJaidenMoney { get; set; }
        public int status { get; set; }
       
        public string ReceiptImage { get; set; }

        public List<ProudectOrderResponse> ProudectOrders { get; set; }

    }
}
