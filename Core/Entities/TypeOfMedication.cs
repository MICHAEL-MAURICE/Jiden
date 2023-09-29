using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //وصف الحقل السابق
    public class TypeOfMedication
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        ICollection<Proudect> Proudects { get; set; }

    }
}
