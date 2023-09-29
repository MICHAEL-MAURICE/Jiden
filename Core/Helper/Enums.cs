using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public class Enums
    {
        public enum UsersTypes { 
        compony=0,
        Store=1,
        Pharmacy=2,
        Admin=3
        }

        public enum ProudectPriority {
         basic=0,
         Prime=1
        
        }
        public enum OrderStatus
        {
            RequestOrder = 0,
            PayedOrdr = 1

        }
    }
}
