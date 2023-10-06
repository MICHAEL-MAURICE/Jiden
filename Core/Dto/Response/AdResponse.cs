using Core.Entities;
using Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class AdResponse
    {
        public Guid Id { get; set; }
        
        public string Image { get; set; }
        public Guid ProudectId { get; set; }
      
        public string Description { get; set; }

       

       

       


    }
}
