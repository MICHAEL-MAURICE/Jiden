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
            pennding = 0,
            rejected = 1,
            paid = 2,
            partialApproval=3,
            needToAttachImage=4,
            penndingAgent = 5,
            rejectedAgent = 6,
            PaidAgent = 7,
            partialApprovalAgent = 8,
            needToAttachImageAgent=9
        }

        public enum ProudectOrder
        {
            pennding=0,
            rejected=1,
            paid = 2,
            penndingAgent =3,
            rejectedAgent = 4,
            AcceptAgent = 2
        }
    }
}
