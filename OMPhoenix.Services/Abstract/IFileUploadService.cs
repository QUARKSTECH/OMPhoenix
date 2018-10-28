using System.Web;

namespace OMPhoenix.Services
{
    public interface IFileUploadService
    {
        bool UploadImageAndThumbnail(HttpPostedFile postedFile, int Width, int Height, string FolderPath, string ImageName, string ThumbnailImageName, string ThumbnailImageNameSmaller);
    }
}
