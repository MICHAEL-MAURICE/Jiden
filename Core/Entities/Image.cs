using Core.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public int ?Type { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUseriD { get; set; }
        [ForeignKey("Proudect")]
        public Guid? Proudectid { get; set; } 
        [ForeignKey("Ad")]
        public Guid? ADID { get; set; }
        [ForeignKey("News")]
        public Guid ? NewsId { get; set; }

        [JsonIgnore]
        public News? News { get; set; }
        public AppUser ?AppUser { get; set; }
        [JsonIgnore]
        public Proudect? Proudect { get; set; }
          [JsonIgnore]
        public Ad ?Ad { get; set; }
    }
}
