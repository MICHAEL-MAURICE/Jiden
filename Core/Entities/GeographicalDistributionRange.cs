using Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class GeographicalDistributionRange
    {
        public Guid Id { get; set; }
        public string City { get; set; }

        public string station { get; set; }


        public Guid ? GovernorateId { get; set; }
        public string ?AppUserId { get; set; }
       
        public Guid? ProudectId { get; set; }

        [ForeignKey("ProudectAgent")]
        public Guid ?ProudectAgentId { get; set; }
       
        public ProudectAgent ProudectAgent { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }
        [JsonIgnore]
        public Proudect Proudect { get; set; }
       
        public Governorate Governorate { get; set; }



    }
}
