using Core.Helper;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class AdRepo : IAd
    {
        public Task<ApiResponse> Create(int numberOfDays)
        {
            throw new NotImplementedException();
        }
    }
}
