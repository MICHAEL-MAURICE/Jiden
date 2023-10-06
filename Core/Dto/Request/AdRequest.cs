using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Request
{
    public class AdRequest
    {
        [Required]
        public int  NumberOfDays { get; set; }
        [Required]
        public Guid ProudectId { get; set; }

        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
