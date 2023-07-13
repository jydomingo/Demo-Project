using PhotoSharingAppJessieDomingo.Models;

namespace PhotoSharingAppJessieDomingo.Data
{
    public interface ICommentData
    {
        Task<IEnumerable<CommentModel>> GetComments(int photoid);
        Task<int> InsertComment(CommentModel comment);
    }
}