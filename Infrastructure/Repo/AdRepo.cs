using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.Identity;
using Core.ImagesHandler;
using Core.Interfaces;
using Core.Jwt;
using Core.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.ImagesHandler.ImagesRepository;

namespace Infrastructure.Repo
{
    public class AdRepo:IAd
    {
       
        private readonly AppDbContext _context;
        private readonly JwtTokenData _Token;
        private readonly IRepositoryImages _repositoryImages;



        public AdRepo(AppDbContext context, ITokenDecoder token, IRepositoryImages repositoryImages)
        {
            _context = context;
            _Token = token.GetTokenData();
            _repositoryImages = repositoryImages;
           
        }

        public async Task<ApiResponse> ActiveAd(Guid Id)
        {
            var Ad = await _context.Ads.FirstOrDefaultAsync(ad => ad.Id == Id);
            if (Ad != null)
            {
                Ad.Active = true;
                Ad.StartDate = DateTime.UtcNow;
                Ad.EndDate = DateTime.UtcNow.AddDays(Ad.NumberOfDays);
                await _context.SaveChangesAsync();
                return new ApiResponse() { isSuccess = true, Status = 200, Message = "This Ad Is Active now" };
            }
            return new ApiResponse() { isSuccess = false, Status = 500, Message = "This Ad Is Not Active " };
        }
        public  async Task<ApiResponse> Create(AdRequest request)
        {
            try
            {
                var ProudectAd = _context.Ads.Where(ad => ad.ProudectId == request.ProudectId && ad.Active == true && ad.EndDate >= DateTime.UtcNow).FirstOrDefault();
                if (ProudectAd != null)
                {
                    return new ApiResponse() { isSuccess = false, Status = 500, Message = "This Proudect has an Active Ad" };
                }

                var Proudect = _context.Proudects.FirstOrDefault(pr => pr.Id == request.ProudectId)?.Priority;
                if (Proudect != null)
                {
                    Proudect = (int)Enums.ProudectPriority.Prime;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ApiResponse() { isSuccess = false, Message = "We don't have this Proudect", Status = 500 };
                }

                var PricingId = _context.PricingSettings?.FirstOrDefault(pr => pr.Type == _Token.Role)?.Id ?? Guid.Empty;

                var AdImage = _repositoryImages.AddImage(request.Image, (int)ImageTypes.Ad);
                var ImageDbNews = new Image() { Id = AdImage.ImageId, Path = AdImage.Fullpath, Type = (int)ImageTypes.Ad };

                _context.Images?.AddAsync(ImageDbNews);

                await _context.SaveChangesAsync();

               
                var Ad = new Ad()
                {
                    Id = Guid.NewGuid(),
                    Active = false,
                    AdImage = AdImage.ImageId,
                    AppUserId = _Token.UserId,
                    Description = request.Description,
                    PricingSettingsId = PricingId,
                    ProudectId = request.ProudectId,
                    NumberOfDays = request.NumberOfDays,
                };

                await _context.Ads.AddAsync(Ad);
                await _context.SaveChangesAsync();
                return new ApiResponse() { isSuccess = true, Status= 200, Message= "Ad Created Successfully" };
            }
            catch(Exception ex) {
                return new ApiResponse() { isSuccess = false, Status = 500, Message = "Ad not Created" };
            }
            
        }

        public  async Task<ApiResponse<List<AdResponse>>> GetActive(int PageNumber = 1, int Count = 10)
        {
            if (PageNumber > 0 && Count > 0)
            {
                int AlreadyseenCount = (PageNumber - 1) * Count;

                var Ads = await _context.Ads.Include(ad => ad.Image).Include(ad => ad.Proudect).Where(ad => ad.Active == true && ad.EndDate>=DateTime.UtcNow)
                    .Skip(AlreadyseenCount)
                    .Take(Count)
                    .Select(
                    ad => new AdResponse()
                    {
                        Id = ad.Id,
                        Image = ImagesUtilities.GetImage(ad.Image.Path),
                        ProudectId = ad.ProudectId,
                        Description = ad.Description,
                    }

                    ).ToListAsync();

                if (Ads.Any())
                {
                    return new ApiResponse<List<AdResponse>>() { Data = Ads, isSuccess = true, Status = 200 };
                }
          
            }

            return new ApiResponse<List<AdResponse>>() { Data = new List<AdResponse>(), isSuccess = false, Status = 500, Message = "We Don't have any Ads" };
        }


        public async Task<ApiResponse<List<AdResponse>>> GetUnActive(int PageNumber = 1, int Count = 10)
        {
            if (PageNumber > 0 && Count > 0)
            {
                int AlreadyseenCount = (PageNumber - 1) * Count;

                var Ads = await _context.Ads.Include(ad => ad.Image).Include(ad=>ad.Proudect).Where(ad => ad.Active == false)
                    .Skip(AlreadyseenCount)
                    .Take(Count)
                    .Select(
                    ad => new AdResponse()
                    {
                        Id = ad.Id,
                        Image = ImagesUtilities.GetImage(ad.Image.Path),
                        ProudectId=ad.ProudectId,
                        Description= ad.Description,
                    }

                    ).ToListAsync();

                if (Ads.Any())
                {
                    return  new ApiResponse<List<AdResponse>>() { Data=Ads,isSuccess=true,Status=200 };
                }
              //  return new ApiResponse<List<AdResponse>>() { Data = new List<AdResponse>(), isSuccess = false, Status = 500,Message="We Don't have any Ads" };
            }

            return new ApiResponse<List<AdResponse>>() { Data = new List<AdResponse>(), isSuccess = false, Status = 500, Message = "We Don't have any Ads" };
        }

        public async Task<ApiResponse> UnActiveAd(Guid Id)
        {
            var Ad = await _context.Ads.FirstOrDefaultAsync(ad => ad.Id == Id);
            if (Ad != null)
            {
                Ad.Active = false;
               
                await _context.SaveChangesAsync();
                return new ApiResponse() { isSuccess = true, Status = 200, Message = "This Ad Is Not Active " };
            }
            return new ApiResponse() { isSuccess = false, Status = 500, Message = "This Ad Still Active Active " };
        }
    }
}
