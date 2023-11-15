using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Request
{
    public class ProudectAgentRequest
    {
        public Guid ProudectId { get; set; }
        public int ProudectCount { get; set; }
        public List<GeographicalDistributionRangRej> GeographicalDistributionRanges { get; set; }
    }
}
