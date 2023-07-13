using PhotoSharingAppJessieDomingo.Models;

namespace PhotoSharingAppJessieDomingo.Data
{
    public interface IPhotoData
    {
        Task<int> DeletePhoto(int photoid);
        Task<PhotoModel?> GetPhoto(int photoid);
        Task<IEnumerable<PhotoModel>> GetPhotos();
        Task<int> InsertPhoto(PhotoModel photo);
        Task<IEnumerable<PhotoModel>> SearchPhotos(string title);
    }
}