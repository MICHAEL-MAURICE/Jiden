using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Net;


namespace Core.ImagesHandler
{
    public static class ImagesUtilities
    {

        //Deafult Images / paths / base64s Configuration 
        private  static IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("ImagesConfig.json");

        private static IConfiguration Configuration = builder.Build();
        //Folders
        public static string? FlagsDeafultFolderPath = Configuration["FlagsDeafultFolder"];
        public static string? DeafultPathToAddImage = Configuration["DeafultPathToAddImage"];
        public static string? DeafultProvidersIconsFolder = Configuration["DeafultProvidersIconsFolder"]; 

        //base64 
        public static string DeafultBase64ImageOnIOFailure = Configuration["DeafultBase64ImageOnIOFailure"];
        public static string DeafultBase64Image = Configuration["DeafultImage"];
        //images
        public static string? DeafultLogoImagePath = Configuration["DeafultBase64ImageOnIOFailure"];
        public static string? DeafultAvatarImagePath = Configuration["DeafultAvatarImagePath"];
        public static string? DeafultCoverImagePath = Configuration["DeafultCoverImagePath"];
        //1me logo 
        public static string? _1meLogoPath = Configuration["_1meLogoPath"];
        public static string? QRColorTheme = Configuration["QRColorTheme"]; 
        //apply one of 2 Perfects Dimensions while keeping the orginal ratio 
        //only for the images that one of its Dimensions is taller than the perfect Dimension
        public static byte[] ResizeImage(byte[] data, int PerfectHeight, int PerfectWidth)
        {
            using (var ms = new MemoryStream(data))
            {
                var image = Image.FromStream(ms); // windows only 
                var width =  image.Width;
                var height = image.Height;

                if (height >= width && height >= PerfectHeight)
                {
                    double ratio = (double)width / height;
                    height = PerfectHeight;
                    width = (int)(ratio * height);
                    return ChangeImageRatio(image, height, width);
                }
                else if (width > height && width >= PerfectWidth)
                {
                    double ratio = (double)height / width;
                    width = PerfectWidth;
                    height = (int)(ratio * width);
                    return ChangeImageRatio(image, height, width);
                }
                return data;
            }
        }
        public static  string? AddImage(string Base64Image, string ImageName, int PerfectHeight, int PerfectWidth)
        {
            if (Base64Image == null||string.IsNullOrEmpty(Base64Image)) Base64Image = DeafultBase64Image;
            string ImagePathFullPath = $"{DeafultPathToAddImage}{ImageName}{GetImageExt(Base64Image.Substring(0, 5))}";
            try
            {
                var ImageAsBytes = Convert.FromBase64String(Base64Image);
                ImageAsBytes = ResizeImage(ImageAsBytes, PerfectHeight, PerfectWidth);
                File.WriteAllBytes(ImagePathFullPath, ImageAsBytes);
                return ImagePathFullPath;
            }
            catch 
            {
                return null;
            }
        }
        public static string GetFlag (string CountryCode)
        {
            string CountryFlagPath = Path.Combine(FlagsDeafultFolderPath, $"{CountryCode.ToLower()}.png");
            return GetImage(CountryFlagPath);
        }

        public static string ConverttFromURLTOBase64(string ImageURL){

            try {
                using (var webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(ImageURL);
                    string Imagebase64 = Convert.ToBase64String(imageData);
                    return Imagebase64;
                }
            }
            catch {

                return null;
            }
            return null;    
           
        }

        public static string GetProvderIcon (string ProviderImgPath)
        {
            string ProviderIconFullPath = Path.Combine(DeafultProvidersIconsFolder, $"{ProviderImgPath}");
            return GetImage(ProviderIconFullPath);
        }
        public static string? GetImage(string? Path)
        {
            if (string.IsNullOrEmpty(Path))
            {
                return null;
            }
            try
            {
                byte[] ImageAsBytes = File.ReadAllBytes(Path);
                return Convert.ToBase64String(ImageAsBytes);
            }
            catch
            {
                return null;
            }
        }
        private static string GetImageExt(string Base64Ext)
        {
            switch (Base64Ext.ToUpper())
            {
                case "IVBOR":
                    return ".png";
                case "/9J/4":
                    return ".jpg";
                default: return string.Empty; // save it as type File 
            }
        }
        private static byte[] ChangeImageRatio(Image image, int height, int width)
        {
            var newImage = new Bitmap(width, height);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, width, height);
            Bitmap bmp = new Bitmap(newImage);
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }

    }
}
