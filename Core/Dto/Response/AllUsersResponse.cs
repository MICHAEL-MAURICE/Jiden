using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class AllUsersResponse
    {

        public string Id { get; set; }  
        [Required]
        public string NameInArabic { get; set; }
        [Required]
        public string NameInEnglish { get; set; }
        [Required]
        public string Adress { get; set; }
        [Phone, Required]
        public string PhoneNumber { get; set; }

     
       
    
        public string? ProfileImage { get; set; }

   
   

    }
}
