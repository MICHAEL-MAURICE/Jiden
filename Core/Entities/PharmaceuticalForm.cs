using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //الشكل الصيدلي
    public class PharmaceuticalForm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Proudect> Proudects { get; set; }
    }
}
