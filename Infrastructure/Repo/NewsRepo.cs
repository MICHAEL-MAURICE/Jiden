using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.ImagesHandler;
using Core.Interfaces;
using Core.Jwt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.ImagesHandler.ImagesRepository;

namespace Infrastructure.Repo
{
    public class NewsRepo : INews
    {
        private readonly AppDbContext _Context;
        private readonly IRepositoryImages _repositoryImages;
        private readonly JwtTokenData _jwtTokenData;

        public NewsRepo(AppDbContext context, IRepositoryImages repositoryImages, ITokenDecoder token)
        {
            _Context = context;
            _repositoryImages = repositoryImages;
            _jwtTokenData = token.GetTokenData();
        }

        public async Task<ApiResponse> Active(Guid Id)
        {
           var news= _Context.News.Where(ne => ne.Id == Id).FirstOrDefault();

            if (news != null)
            {
                news.ActiveNews = true;
                _Context.SaveChanges();
                return new ApiResponse() { isSuccess= true ,Message="This Post Activated",Status=200};
            }
            return new ApiResponse() { isSuccess = false, Message = "We Don't Have This Post", Status = 500 };
        }

        public async Task<ApiResponse> Create(CreateNewsRequest request)
        {
            var transaction = _Context.Database.BeginTransaction();

            {
                try
                {
                    var NewsImage =  _repositoryImages.AddImage(request.Image, (int)ImageTypes.news);
                    var ImageDbNews= new Image() { Id = NewsImage.ImageId, Path = NewsImage.Fullpath, Type = (int)ImageTypes.news };
           
                    _Context.Images?.AddAsync(ImageDbNews);

                    await _Context.SaveChangesAsync();

                    var news = new News() { 
                    
                    Id=Guid.NewGuid(),
                    Title= request.Title,
                    CreatedOn= DateTime.UtcNow,
                    ImageId= NewsImage.ImageId,
                    ActiveNews= false,
                    Pragraph=request.Pragraph,
                    AppUserId=_jwtTokenData.UserId,
                    
                    
                    };
                    _Context.News?.AddAsync(news);

                   await _Context.SaveChangesAsync();
                    return new ApiResponse(){Message="Created Sucssesfully",Status=200,isSuccess=true };

                }

                catch (Exception ex) {

                    return new ApiResponse() { Message = "Not Created Sucssesfully", Status = 500, isSuccess = false };

                }
            }
            return  new ApiResponse() { Message = "Created Sucssesfully", Status = 200, isSuccess = true };

        }

        public  async Task<ApiResponse> Delete(Guid Id)
        {
            var news = _Context.News.Include(ne => ne.Image).FirstOrDefault(ne=>ne.Id==Id);
            if (news != null)
            {
                _Context.News.Remove(news);

                _Context.SaveChanges();

                return new ApiResponse() { isSuccess=true,Message="This Post Deleted",Status=200};
            }
            return  new ApiResponse() { Status=500,isSuccess=false,Message="We Don't have This Post" };



           
        }

        public async Task<ApiResponse<List<AllNewsResponse>>> GetAll(int PageNumber=1, int Count=10)
        {
            if (PageNumber > 0 && Count > 0)
            {
                int AlreadyseenCount = (PageNumber - 1) * Count;


                var AllNews = _Context.News.Include(News => News.Image)
                .OrderBy(ne => ne.CreatedOn).Where(ne=>ne.ActiveNews==true).Skip(AlreadyseenCount).
                    Take(Count)
                .Select(ne => new AllNewsResponse()
                {
                    Id = ne.Id,
                    Image = ImagesUtilities.GetImage(ne.Image.Path),
                    Date = ne.CreatedOn,
                    Title = ne.Title,
                }).ToList();


                if (AllNews.Any())
                {

                    return new ApiResponse<List<AllNewsResponse>>() { Data = AllNews, isSuccess = true, Message = "This all News", Status = 200 };

                }

            }
            return new ApiResponse<List<AllNewsResponse>>() { Data = new List<AllNewsResponse>(), Status = 500, isSuccess = false, Message = "We Don't Have Any News" };

        }

        public async Task<ApiResponse<NewsDetailsResponse>> GetById(Guid Id)
        {
            var News =  _Context.News.Include(Ne => Ne.Image).Include(Ne => Ne.AppUser).Where(ne => ne.ActiveNews == true && ne.Id == Id).Select(
                Ne => new NewsDetailsResponse()
                {
                    Id= Ne.Id,
                    Title= Ne.Title,
                    CreatedOn=Ne.CreatedOn,
                    Image=ImagesUtilities.GetImage(Ne.Image.Path),
                    Pragraph=Ne.Pragraph,
                    UserName=Ne.AppUser.UserName
                }).FirstOrDefault();

            if(News != null ) {

                return new ApiResponse<NewsDetailsResponse>() { Data=News,Message="We Have This Proudect",isSuccess=true,Status=200};
            
            }
            return new ApiResponse<NewsDetailsResponse>() { Data = null, Message = "We Don't Have This Proudect", isSuccess = false, Status = 500 };

        

            throw new NotImplementedException();
        }

        public async Task<ApiResponse> UnActive(Guid Id)
        {
            var news = _Context.News.Where(ne => ne.Id == Id).FirstOrDefault();

            if (news != null)
            {
                news.ActiveNews = false;
                _Context.SaveChanges();
                return new ApiResponse() { isSuccess = true, Message = "This Post UnActivated", Status = 200 };
            }
            return new ApiResponse() { isSuccess = false, Message = "We Don't Have This Post", Status = 500 };
        }
    }   
}
