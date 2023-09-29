

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Core.Entities;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace Core.ImagesHandler
{

  
    public class ImagesRepository : IRepositoryImages
    {
       IConfiguration _configuration;
        public ImagesRepository(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public enum ImageTypes
        {
            Profile = 1 , 
            Proudect  = 2 ,
            Ad = 3,
            ProudectLicence=4

        }
        public ReturnImagesData? AddImage(string Base64Image , int PerfectHeight , int PerfectWidth)
        {
           
            Guid ImageId = Guid.NewGuid();
            var ImageFullPath = ImagesUtilities.AddImage(Base64Image, ImageId.ToString(), PerfectHeight, PerfectWidth);
            if (ImageFullPath != null) {
               

                return new ReturnImagesData() { ImageId=ImageId,Fullpath=ImageFullPath};
            }
            return null;
        }
        public ReturnImagesData? AddImage(string Base64Image , int ImageType)
        {
            switch (ImageType)
            {
                case(int)ImageTypes.Ad:
                    return AddImage(Base64Image, 400, 1600);
                case (int)ImageTypes.Profile:
                    return AddImage(Base64Image, 400, 400);
                case (int)ImageTypes.Proudect:
                    return AddImage(Base64Image, 400, 400);
                case (int)ImageTypes.ProudectLicence:
                    return AddImage(Base64Image, 400, 400);
                default: return AddImage(Base64Image, 400, 400);
            }
                
        }
    }
}
