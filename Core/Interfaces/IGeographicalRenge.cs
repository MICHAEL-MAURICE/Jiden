using Core.Dto.Response;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGeographicalRenge
    {
        Task < ApiResponse< List<GeographicalResponse>>> GetCitiesandStatus(Guid ProudectId, Guid GeolocationId);
         
    }
}
