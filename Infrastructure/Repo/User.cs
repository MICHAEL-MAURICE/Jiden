using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.ImagesHandler;
using Core.Interfaces;
using Core.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Core.ImagesHandler.ImagesRepository;

namespace Infrastructure.Repo
{
    public class User : IUser
    {
        private readonly AppDbContext _Context;
        private readonly IRepositoryImages _repositoryImages;
        public User( AppDbContext Context, IRepositoryImages repositoryImages)
        {
            _Context = Context;
            _repositoryImages = repositoryImages;
        }

        public async Task<ApiResponse> ActiveUserByID(string UserID)
        {
             var User= _Context.Users.FirstOrDefault(user=>user.Id==UserID);

            if (User != null)
            {
                User.IsActive= true;
                _Context.SaveChanges();

                return new ApiResponse()
                {
                    Message = "The User now Is Active",

                    Status = 200,
                    isSuccess = true

                };

            }
            return new ApiResponse()
            {
                Message = "The User Is not Active",

                Status = 200,
                isSuccess = false

            };
        }

    
        public async Task<ApiResponse<List<AllUsersResponse>>> GetAllActiveUsers()
        {
            var ActiveUser = _Context.Users.Include(user => user.Image).Where(user =>  user.IsActive == true).ToList();

            if (ActiveUser.Any())
            {
                List<AllUsersResponse> ActiveUserList = new List<AllUsersResponse>();

                foreach (var user in ActiveUser)
                {
                    ActiveUserList.Add(new AllUsersResponse()
                    {
                        Id= user.Id,
                        Adress = user.Adress,
                        NameInArabic = user.NameInArabic,
                        NameInEnglish = user.NameInEnglish,
                        PhoneNumber = user.PhoneNumber,
                        ProfileImage = ImagesUtilities.GetImage(user.Image.Path),

                    });

                }


                return new ApiResponse<List<AllUsersResponse>>()
                {
                    Data = ActiveUserList,
                    Status = 200,
                    isSuccess = true
                };
            }


            return new ApiResponse<List<AllUsersResponse>>()
            {
                Data = new List<AllUsersResponse>() { },
                Status = 200,
                isSuccess = false
            };

            throw new NotImplementedException();
        }


        public async Task<ApiResponse<List<AllUsersResponse>>> GetAllNonActiveUsers()
        {
            var NonActiveUser = _Context.Users.Include(user => user.Image).Where(user => user.IsActive == null|| user.IsActive==false).ToList();

            if (NonActiveUser.Any())
            {
                List<AllUsersResponse> NonActiveUserList = new List<AllUsersResponse>();

                foreach (var user in NonActiveUser)
                {
                    NonActiveUserList.Add(new AllUsersResponse()
                    {
                        Id= user.Id,
                        Adress = user.Adress,
                        NameInArabic= user.NameInArabic,
                        NameInEnglish= user.NameInEnglish,
                        PhoneNumber= user.PhoneNumber,
                        ProfileImage = ImagesUtilities.GetImage(user.Image.Path),

                    });

                }


                return new ApiResponse<List<AllUsersResponse>>()
                {
                    Data = NonActiveUserList,
                    Status=200,
                    isSuccess=true
                };    
            }


            return new ApiResponse<List<AllUsersResponse>>()
            {
                Data = new List<AllUsersResponse>() { },
                Status = 200,
                isSuccess = false
            };

            throw new NotImplementedException();
        }

        public async Task<ApiResponse<UserResponse>> GetUserById(string ID)
        {

            var user = _Context.Users
    .Include(user => user.Proudects)
    .Include(user => user.GeographicalDistributionRanges)
    .Include(user => user.Ads)
    .Where(user => user.Id == ID)
    .Select(user => new UserResponse
    {
        NameInArabic = user.NameInArabic,
        NameInEnglish = user.NameInEnglish,
        Adress = user.Adress,
        Ads = user.Ads.Select(ads => new adsMapping()
        {
            ID = ads.Id,
            ProudectnameInArabic = ads.Proudect.NameInArabic,
            ProudectnameInEnglish = ads.Proudect.NameInEnglish,
            ProudectImage = ImagesUtilities.GetImage(ads.Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.Proudect).Path)
        }).ToList(),
        GeographicalDistributionRanges = user.GeographicalDistributionRanges.Select(geo => new GeographicalMapping()
        {
            ID = geo.Id,
            City = geo.City,
            station = geo.station,
            governmentNameInArabic = geo.Governorate.NameInArabic,
            governmentNameInEnglish = geo.Governorate.NameInEnglish,
        }).ToList(),
        PhoneNumber = user.PhoneNumber,
        Link = user.Link,
        Role = user.Role,
        ProfileImage = ImagesUtilities.GetImage(user.Image.Path),
        Proudects = user.Proudects.Select(Pr => new proudectMapping()
        {
            ID = Pr.Id,
            nameInArabic = Pr.NameInArabic,
            nameInEnglish = Pr.NameInEnglish,
            ProudectImage = ImagesUtilities.GetImage(Pr.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.Proudect).Path)
        }).ToList()
    })
    .FirstOrDefault();


            if(user != null)
            {
                return new ApiResponse<UserResponse>()
                {
                    Data = user,
                    isSuccess = true,
                    Message = "This is your Proudect",
                    Status = 200
                };
            }
            return new ApiResponse<UserResponse>()
            {
                Data = null,
                isSuccess = false,
                Message = "This is your Proudect",
                Status = 500
            };

            throw new NotImplementedException();
        }

        public  async Task<ApiResponse> UnActiveUserByID(string UserID)
        {
            var User = _Context.Users.FirstOrDefault(user => user.Id == UserID);

            if (User != null)
            {
                User.IsActive = false;
                _Context.SaveChanges();

                return new ApiResponse()
                {
                    Message = "The User now Is not Active",

                    Status = 200,
                    isSuccess = true

                };

            }
            return new ApiResponse()
            {
                Message = "The User Is Active",

                Status = 200,
                isSuccess = false

            };
        }

        public async Task<ApiResponse> DeleteUser(string UserID)
        {
            var user = _Context.Users
                .Include(user => user.Ads)
                .Include(user => user.GeographicalDistributionRanges)
                .Include(user => user.Image)
                .Include(user => user.Proudects)
                    .ThenInclude(product => product.Images).Include(Pro=>Pro.GeographicalDistributionRanges) // Include associated images
                .FirstOrDefault(user => user.Id == UserID);

            if (user != null)
            {
                try
                {
                    // Handle Images if there's a reference
                    if (user.Image != null)
                    {
                        // Assuming ImageUserId is the foreign key to the user
                        user.Image.AppUseriD = null;
                        user.Image = null;
                    }

                    foreach (var product in user.Proudects.ToList()) // To safely delete while iterating
                    {
                        // Delete associated images
                        foreach (var image in product.Images.ToList())
                        {
                            _Context.Images.Remove(image);
                        }

                        // Clear associations to related geographical distribution ranges
                        if(product.GeographicalDistributionRanges!=null)
                        foreach (var geoRange in product.GeographicalDistributionRanges.ToList())
                        {
                            geoRange.ProudectId = null;
                        }

                        _Context.Proudects.Remove(product); // Delete the Proudect after images are deleted
                    }

                    // Clear associations to related geographical distribution ranges
                    if(user.GeographicalDistributionRanges!= null)
                    _Context.RemoveRange(user.GeographicalDistributionRanges);
                    if(user.Ads!= null)
                    _Context.RemoveRange(user.Ads);

                    _Context.Users.Remove(user);

                    await _Context.SaveChangesAsync();

                    return new ApiResponse()
                    {
                        isSuccess = true,
                        Status = 200,
                        Message = "This user has been deleted."
                    };
                }
                catch (Exception ex)
                {
                    return new ApiResponse()
                    {
                        isSuccess = false,
                        Status = 500,
                        Message = "We couldn't delete this user."
                    };
                }
            }

            return new ApiResponse()
            {
                isSuccess = false,
                Status = 400,
                Message = "This ID was not found."
            };
        }



        public async Task<ApiResponse> UpdateUser(UpdateUser _updateUser)
        {
            var user = _Context.Users.Include(user => user.Image)
.FirstOrDefault(user => user.Id == _updateUser.Id);

            if (user != null) {
                try
                {
                    user.Link = _updateUser.Link;
                    user.PhoneNumber = _updateUser.PhoneNumber;
                    var imageProudect = _repositoryImages.AddImage(_updateUser.ProfileImage, (int)ImageTypes.Profile);
                    user.Image.Path = imageProudect.Fullpath;
                    _Context.SaveChanges();
                    return new ApiResponse() {
                    isSuccess=true,
                    Status = 200,
                    Message="Your Account updated"
                    };
                }
                catch (Exception ex)
                {
                    return new ApiResponse()
                    {
                        isSuccess = false,
                        Status = 500,
                        Message = "Error We Can't Update This Accout"
                    };
                }
            }


            return new ApiResponse()
            {
                Message = "This Account  no Found",
                isSuccess = false,
                Status = 400

            };
        }
    }

    

  


}

