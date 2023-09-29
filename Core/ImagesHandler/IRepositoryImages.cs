using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ImagesHandler
{
    public interface IRepositoryImages 
    {
        public ReturnImagesData? AddImage(string Base64Image, int ImageType);
        public ReturnImagesData? AddImage(string Base64Image, int PerfectHeight, int PerfectWidth);


    }

}
