using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class ProudectOrderSellerResponse
    {
        public Guid Id { get; set; }
        public string ProudectEnglishName { get; set; }
        public string ProudectArabicName { get; set; }
        public int MyProperty { get; set; }
    }
}
