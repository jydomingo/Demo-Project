using PhotoSharingAppJessieDomingo.DataAccess;
using PhotoSharingAppJessieDomingo.Models;

namespace PhotoSharingAppJessieDomingo.Data
{
    public class CommentData : ICommentData
    {
        private readonly ISqlDataAccess _db;

        public CommentData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CommentModel>> GetComments(int photoid) =>
           await _db.LoadData<CommentModel, dynamic>("dbo.sp_get_comments", new { PhotoID = photoid }, "default");


        public Task<int> InsertComment(CommentModel comment) =>
        _db.SaveData("dbo.sp_insert_Comment", new { comment.UserID, comment.Body, comment.PhotoID }, "default");


    }
}
