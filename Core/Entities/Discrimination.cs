using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //التمييز
    public class Discrimination
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        ICollection<Proudect> Proudects { get; set; }   
    }
}
