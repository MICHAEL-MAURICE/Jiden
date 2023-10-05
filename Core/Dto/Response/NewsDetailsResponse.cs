using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class NewsDetailsResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Pragraph { get; set; }

        public string  Image { get; set; }

        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }

    }
}
