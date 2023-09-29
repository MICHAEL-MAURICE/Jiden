using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Request
{
    public class GenericRequest
    {
        public Guid? Id { get; set; }
        public string ?NameInArabic { get; set; }
        public string NameInEnglish { get; set; }
    }
}
