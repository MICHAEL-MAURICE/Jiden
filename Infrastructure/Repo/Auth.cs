
using AutoMapper;
using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.Identity;
using Core.ImagesHandler;
using Core.Interfaces;
using Core.Jwt;

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
    public class Auth : IAuth
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly ITokenFactory _Token;
        private readonly IRepositoryImages _RepositoryImages;
       


        public Auth(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context
            ,ITokenFactory Token,IRepositoryImages repositoryImages
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _Token= Token;
            _RepositoryImages= repositoryImages;


        }
      
        public async Task<ApiResponse<AuthUserResponse>> Login(AuthRequest LoginDto)
        {
            var user = await _userManager.FindByEmailAsync(LoginDto.Email);
            
          var auth=_context.Users.Include(Img=>Img.Image).Include(G=>G.GeographicalDistributionRanges).Include(A=>A.Ads).ToList().FirstOrDefault(e=>e.Email==LoginDto.Email); 
            if (user == null) { return new ApiResponse<AuthUserResponse>()
            { Data = null, isSuccess = false, Status = 400, Message = "This Email not Found" }; }

            var result =_signInManager.CheckPasswordSignInAsync(user, LoginDto.Password, false).GetAwaiter().GetResult();
            if (!result.Succeeded)
            {
                return new ApiResponse<AuthUserResponse>()
                { Data = null, isSuccess = false, Status = 400, Message = "This Password not Found" };
            }
            if (user.IsActive== false)
            {
                return new ApiResponse<AuthUserResponse>()
                { Data = null, isSuccess = false, Status = 200, Message = "We Review Your Account Now " };
            }

            // _mapper.Map<AppUser,UserResponse>(user)
           
                var Token = _Token.CreateToken(new JwtTokenData()
                {
                    Email = user.NormalizedEmail,
                    Role = user.Role,
                    UserId = user.Id,
                    Governorates = auth.GeographicalDistributionRanges.Select(Geo => Geo.GovernorateId).ToList()

                });
            

            return new ApiResponse<AuthUserResponse>()
            { Data = new AuthUserResponse()
            {
                NameInArabic = user.NameInArabic,
                NameInEnglish = user.NameInEnglish,
                
                Adress = user.Adress,
                Email = user.Email,
               
                Id = new Guid(user.Id),
                Link = user.Link,
                PhoneNumber = user.PhoneNumber,
              
                Role = user.Role,
                Token = Token.token,
                TokenExpiredDate = Token.expiresOn,
                ProfileImage=ImagesUtilities.GetImage(auth.Image.Path)

            }, isSuccess = true, Status = 200 };



        }


        public async Task<ApiResponse> Rejesteration(RejesterationRequest rejesterationRequest)
        {
           // var transaction = _context.Database.BeginTransaction();
            //{


                try
                {
                
                    var image = _RepositoryImages.AddImage(rejesterationRequest.ProfileImage, (int)ImageTypes.Profile);
                    var ImageDb = new Image() { Id = image.ImageId, Path = image.Fullpath,Type= (int)ImageTypes.Profile };
                    _context.Images.Add(ImageDb);
                    _context.SaveChanges();
                    var user = new AppUser()
                    {
                        NormalizedEmail = rejesterationRequest.Email,
                        NameInArabic = rejesterationRequest.NameInArabic,
                        NameInEnglish = rejesterationRequest.NameInEnglish,
                        Email = rejesterationRequest.Email,
                        UserName = rejesterationRequest.Email,
                        Adress = rejesterationRequest.Adress,
                        ProfileImage=image.ImageId,
                        IsActive=false,
                        Role = rejesterationRequest.Role,
                        Link = rejesterationRequest.Link,
                        PhoneNumber = rejesterationRequest.PhoneNumber,
                    };

                   
                 
                    var RejesterUser = await _userManager.CreateAsync(user, rejesterationRequest.Password);
                    AddGeographicalDistributionRang(rejesterationRequest.GeographicalDistributionRanges, user);
                    ImageDb.AppUseriD = user.Id;

                    if (!RejesterUser.Succeeded)
                    {
                        return new ApiResponse()
                        { isSuccess = false, Status = 400, Message = "Error We Can't Creat This Account" };

                    }
                    _context.SaveChanges();
                    return new ApiResponse()
                    { isSuccess = true, Status = 200, Message = "Account Created" };
                }

                catch (Exception ex)
                {

               //     transaction.Rollback();
                    return new ApiResponse()
                    { isSuccess = false, Status = 500, Message = "There is an Error Try again" };

                }
            }


        //}

        

        public async Task<ApiResponse> ResetPassword(AuthRequest ResetPaswordDto)
        {

            var user =  _userManager.FindByEmailAsync(ResetPaswordDto.Email).GetAwaiter().GetResult();
            if (user == null)
            {
                return new ApiResponse()
                { isSuccess = false, Status = 400, Message = "This Email not Found" };
            }

               var token=  _userManager.CreateSecurityTokenAsync(user).GetAwaiter().GetResult();
            var NewPassword= _userManager.ResetPasswordAsync(user, token.ToString(), ResetPaswordDto.Password).GetAwaiter().GetResult();

            return new ApiResponse()
            { isSuccess = true, Status = 200, Message = "Your Password Updated Successfully" };


        }


            private void AddGeographicalDistributionRang(List<GeographicalDistributionRangRej> list, AppUser user)
            {
                foreach (var item in list)
                {
                    _context.GeographicalDistributionRanges.Add(new GeographicalDistributionRange() {

                        Id = Guid.NewGuid(),
                        AppUserId = user.Id,
                 
                        City = item.City,
                        station = item.station,
                        GovernorateId = item.GovernorateId

                    });
                }

                _context.SaveChanges();
            }
        }
    }
