using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class GetOrdersforUser
    {
        public decimal JaidenMoney { get; set; }
        public decimal Price { get; set; }
        public List<GetAllOrderResponse>AllOrders { get; set; }
    }
}
