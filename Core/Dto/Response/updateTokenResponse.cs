using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Response
{
    public class updateTokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiredon { get; set; }
    }
}
