
using System.ComponentModel.DataAnnotations;

namespace PhotoSharingAppJessieDomingo.Models
{
    public class CommentModel : ICommentModel
    {
        public int CommentID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Body { get; set; }
        public int PhotoID { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
