using OMPhoenix.Data.Infrastructure;
using OMPhoenix.Data.Repositories;
using OMPhoenix.Entity;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace OMPhoenix.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IEntityBaseRepository<ClientDetail> _clientDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FileUploadService(IEntityBaseRepository<ClientDetail> clientDetailRepository
            , IUnitOfWork unitOfWork)
        {
            _clientDetailRepository = clientDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public bool UploadImageAndThumbnail(HttpPostedFile postedFile, int Width, int Height, string FolderPath, string ImageName, string ThumbnailImageName, string ThumbnailImageNameSmaller)
        {
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(FolderPath)))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(FolderPath));
            var imagePath = System.Web.Hosting.HostingEnvironment.MapPath(FolderPath + ImageName);
            var ThumbnailImagePath = System.Web.Hosting.HostingEnvironment.MapPath(FolderPath + ThumbnailImageName);
            var ThumbnailImageNameSmallerPath = System.Web.Hosting.HostingEnvironment.MapPath(FolderPath + ThumbnailImageNameSmaller);
            if (!IsValidateMedia(postedFile, imagePath))
            {
                return false;
            }
            //check 
            if (Width < 100)
                Width = 500;
            if (Height < 100)
                Height = 400;
            //image upload
            var SourceImage = Image.FromStream(postedFile.InputStream);
            try
            {
                using (var NewImage = FixedSize(SourceImage, 400, 300, true))
                {
                    NewImage.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception)
            {
                using (var NewImage = ScaleImage(Image.FromStream(postedFile.InputStream), 400, 300))
                {
                    NewImage.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            //thumbnail upload 

            //using (var thumb = FixedSize(SourceImage, 200, 200, true))
            //{

            //    thumb.Save(ThumbnailImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
            //using (var thumb = FixedSize(SourceImage, 50, 50, true))
            //{

            //    thumb.Save(ThumbnailImageNameSmallerPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
            //Image Smallerthumb = SourceImage.GetThumbnailImage(100, 100, () => false, IntPtr.Zero);
            // Smallerthumb.Save(ThumbnailImageNameSmallerPath);
            return true;
        }

        public bool IsValidateMedia(HttpPostedFile file, string filepath)
        {
            var allowedExtensions = new string[]
            {
            ".jpeg"
            ,".jpg"
            ,".png"
            ,".gif"
            ,".bmp"
            ,".tiff"

            ,".avi"
            ,".asf"
            ,".mov"
            ,".avchd"
            ,".flv"
            ,".mp4"
            ,".wmv"
            ,".divx"

            ,".wav"
            ,".aiff"
            ,".aac"
            ,".ogg"
            ,".wma"
            ,".mp3"

            ,".7z"
            ,".zip"
            ,".rar"
            ,".tar.gz"
            ,".gz"
            ,".z"

            ,".iso"

            ,".csv"
            ,".dat"
            ,".db"
            ,".dbf"
            ,".log"
            ,".sav"
            ,".xml"
            ,".sav"

            ,".fnt"
            ,".fon"
            ,".otf"
            ,".ttf"
            ,".ppt"
            ,".pptx"
            ,".ods"
            ,".xlr"
            ,".xls"
            ,".xlsx"
            ,".doc"
            ,".docx"
            ,".odt"
            ,".pdf"
            ,".rtf"
            ,".tex"
            ,".txt"
            ,".wpd"
            ,".sav"
            ,".sav"
            };

            string extension = Path.GetExtension(filepath).ToLower();
            if ((file.ContentLength / 1024 / 1024) > 10 || !allowedExtensions.Contains(extension))
            {
                return false;
            }
            else
                //file.SaveAs(filepath);
                return true;
        }

        public Image FixedSize(Image image, int Width, int Height, bool needToFill)
        {
            #region calculations
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = ((double)Width / (double)sourceWidth);
            nScaleH = ((double)Height / (double)sourceHeight);
            if (!needToFill)
            {
                nScale = Math.Min(nScaleH, nScaleW);
            }
            else
            {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (Height - sourceHeight * nScale) / 2;
                destX = (Width - sourceWidth * nScale) / 2;
            }

            if (nScale > 1)
                nScale = 1;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);
            #endregion

            Bitmap bmPhoto = null;
            // try
            //{
            bmPhoto = new Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            //}
            //catch (Exception ex)
            //{
            //throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
            //    destWidth, destX, destHeight, destY, Width, Height), ex);
            // }
            using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
            {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;

                Rectangle to = new Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                //Console.WriteLine("From: " + from.ToString());
                //Console.WriteLine("To: " + to.ToString());
                grPhoto.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);

                return bmPhoto;
            }

        }

        public Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
    }
}
