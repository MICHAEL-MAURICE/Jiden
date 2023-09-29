using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Governorate
    {
        public Guid Id { get; set; }

        public string ?NameInArabic { get; set; }
        public string NameInEnglish { get; set; }

        public GeographicalDistributionRange GeographicalDistributionRange { get; set; }

    }
}
