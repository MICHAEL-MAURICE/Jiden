using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{

    public class GeographicalMapping
    {


        public Guid ID { get; set; }
        public string City { get; set; }
        public string station { get; set; }
        public string governmentNameInArabic { get; set; }
        public string governmentNameInEnglish { get; set; }
    }
}
