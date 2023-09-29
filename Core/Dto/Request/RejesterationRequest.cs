using Core.Dto.Response;
using Core.Entities;
using Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Request
{
    public class RejesterationRequest
    {

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
        [DataType(DataType.Password), Required]
        public string Password { get; set; }

        [DataType(DataType.Url)]
        public string ?Link { get; set; }
        public int Role { get; set; }

        public string? ProfileImage { get; set; }

        public List<GeographicalDistributionRangRej> GeographicalDistributionRanges { get; set; }


    }

    public class GeographicalDistributionRangRej{
        public string City { get; set; }

        public string station { get; set; }


        public Guid GovernorateId { get; set; }
    }

}