using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.ImagesHandler;
using Core.Interfaces;
using Core.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class GeographicalRengeRepo : IGeographicalRenge
    {
        private readonly AppDbContext _context;
        private readonly JwtTokenData _Token;
        private readonly IRepositoryImages _repositoryImages;



        public GeographicalRengeRepo(AppDbContext context, ITokenDecoder token, IRepositoryImages repositoryImages)
        {
            _context = context;
            _Token = token.GetTokenData();
            _repositoryImages = repositoryImages;

        }
        public async Task<ApiResponse<List<GeographicalResponse>>> GetCitiesandStatus(Guid ProudectId, Guid GeolocationId)
        {
            var ProudectsCities = _context.Proudects
        .Where(pro => pro.Id == ProudectId)
        .SelectMany(pro => pro.GeographicalDistributionRanges
            .Where(geo => geo.GovernorateId == GeolocationId)
            .Select(geo => new GeographicalResponse()
            {
                City = geo.City,
                Status = geo.station,
            }))
        .ToList();

            if (ProudectsCities.Any())
            {
                return new ApiResponse<List<GeographicalResponse>> { Data=ProudectsCities,Status=200,isSuccess=true,Message="This all Cities and stations" };
            }
            else
            {
                return new ApiResponse<List<GeographicalResponse>> { Data = new List<GeographicalResponse>(), Status = 200, isSuccess = false, Message = "we don't have Cities and stations" };
            }

        }
    }
}
