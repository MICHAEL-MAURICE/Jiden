using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WayMedicineUsed
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Proudect>Proudects { get; set; }
    }
}
