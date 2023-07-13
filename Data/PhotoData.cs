using PhotoSharingAppJessieDomingo.DataAccess;
using PhotoSharingAppJessieDomingo.Models;

namespace PhotoSharingAppJessieDomingo.Data
{
    public class PhotoData : IPhotoData
    {
        private readonly ISqlDataAccess _db;

        public PhotoData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PhotoModel>> GetPhotos() =>
           await _db.LoadData<PhotoModel, dynamic>("dbo.sp_getall_photo", new { }, "default");
        public async Task<IEnumerable<PhotoModel>> SearchPhotos(string title) =>
           await _db.LoadData<PhotoModel, dynamic>("dbo.sp_search_photo", new { Title = title }, "default");

        public async Task<PhotoModel?> GetPhoto(int photoid)
        {
            var results = await _db.LoadData<PhotoModel, dynamic>(
                "dbo.sp_get_photo",
                new { PhotoID = photoid }, "default");
            return results.FirstOrDefault();
        }

        public Task<int> InsertPhoto(PhotoModel photo) =>
        _db.SaveData("dbo.sp_insert_photo", new { photo.Title, photo.PhotoFile, photo.Description, photo.Owner }, "default");

        public Task<int> DeletePhoto(int photoid) =>
        _db.SaveData("dbo.sp_delete_photo", new { PhotoID = photoid }, "default");


    }
}
