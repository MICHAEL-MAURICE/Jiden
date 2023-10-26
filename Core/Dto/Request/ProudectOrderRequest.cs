using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Request
{
    public class ProudectOrderRequest
    {
       
        public Guid ProudectId { get; set; }
        public int ProudectCount { get; set; }
      


    }
}
