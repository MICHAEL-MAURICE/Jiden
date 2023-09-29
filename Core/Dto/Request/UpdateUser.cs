using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Request
{
    public class UpdateUser
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }

      
        [DataType(DataType.Url)]
        public string? Link { get; set; }
        
        public string ProfileImage { get; set; }

       
    }
}
