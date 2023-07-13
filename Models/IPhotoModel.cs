namespace PhotoSharingAppJessieDomingo.Models
{
    public interface IPhotoModel
    {
        DateTime CreatedDate { get; set; }
        string Description { get; set; }
        string ImageMimeType { get; set; }
        string ImageName { get; set; }
        string Owner { get; set; }
        IFormFile PhotoAvatar { get; set; }
        byte[] PhotoFile { get; set; }
        int PhotoID { get; set; }
        string Title { get; set; }
    }
}