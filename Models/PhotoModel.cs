using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoSharingAppJessieDomingo.Models
{
    public class PhotoModel : IPhotoModel
    {
        [Key]
        public int PhotoID { get; set; }
        [Display(Name = "Title:")]
        public string Title { get; set; }
        [NotMapped]
        [Display(Name = "Picture:")]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }
        [Display(Name = "Description:")]
        public string Description { get; set; }
        [Display(Name = "Date Created:")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Owner:")]

        public string Owner { get; set; }


    }
}
