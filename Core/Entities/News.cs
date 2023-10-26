using Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool ActiveNews { get; set; }
        public string  Pragraph { get; set; }
        [ForeignKey("Image")]
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public string AppUserId { get; set; }
        public AppUser  AppUser { get; set; }

    }
}
