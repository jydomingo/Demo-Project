namespace PhotoSharingAppJessieDomingo.Models
{
    public interface ICommentModel
    {
        string Body { get; set; }
        int CommentID { get; set; }
        DateTime DateCreated { get; set; }
        int PhotoID { get; set; }
        string UserID { get; set; }
        string UserName { get; set; }
    }
}