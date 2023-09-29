using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class GenericResponse
    {
        public Guid Id { get; set; }

        public string NameInArabic { get; set; }
        public string NameInEnglish { get; set; }
    }
}
