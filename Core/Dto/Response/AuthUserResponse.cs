using Core.Entities;
using Core.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Dto.Response
{
    public class AuthUserResponse
    {


        public Guid Id { get; set; }
        [Required]
        public string NameInArabic { get; set; }
        [Required]
        public string NameInEnglish { get; set; }
        [Required]
        public string Adress { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
       
        [DataType(DataType.Url)]
        public string Link { get; set; }
        public int Role { get; set; }
        public DateTime TokenExpiredDate { get; set; }

        public string Token { get; set; }
        public string ProfileImage { get; set; }





    }
    }

