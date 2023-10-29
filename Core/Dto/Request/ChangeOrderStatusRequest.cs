using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Request
{
    public class ChangeOrderStatusRequest
    {
   
        public Guid Id { get; set; }
        public int OrderStatus { get; set; }
     
        public List<ProudectOrder> ProudectOrderList { get; set; }

    }

    public class ProudectOrder
    {
        public Guid Id { get; set; }
        public int ProudectOrderStatus { get; set; }
      
    }
}
