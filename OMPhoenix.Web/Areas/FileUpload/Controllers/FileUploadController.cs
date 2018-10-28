using OMPhoenix.Data.Infrastructure;
using OMPhoenix.Data.Repositories;
using OMPhoenix.Entities;
using OMPhoenix.Services;
using OMPhoenix.ViewModel;
using OMPhoenix.Web.Infrastructure.Core;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OMPhoenix.Web.Areas.FileUpload.Controllers
{
    [RoutePrefix("api/fileupload")]
    public class FileUploadController : ApiControllerBase
    {
        private readonly IFileUploadService _ifileUploadService;

        public FileUploadController(
            IFileUploadService ifileUploadService,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _ifileUploadService = ifileUploadService;
        }
        [Route("images")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                ResponseViewModel rm = new ResponseViewModel();
                UploadImageViewModel pf = new UploadImageViewModel();
                var httpRequest = HttpContext.Current.Request;
                HttpResponseMessage response = null;
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var tempimagename = Guid.NewGuid();
                    var ImageName = tempimagename + ".jpg";
                    var ThumbnailImageName = tempimagename + "_thumb" + ".jpg";
                    var ThumbnailImageNameSmaller = tempimagename + "_thumbsmall" + ".jpg";
                    var FolderPath = "~" + Constants.ImagePath;
                    if (!_ifileUploadService.UploadImageAndThumbnail(postedFile, 500, 400, FolderPath, ImageName, ThumbnailImageName, ThumbnailImageNameSmaller))
                    {
                        rm.status = 0;
                        response = request.CreateResponse(HttpStatusCode.OK, rm);
                        return response;
                    }
                    //
                    pf.FileName = ImageName;
                    pf.ThumbnailFileName = ThumbnailImageName;
                    pf.FilePath = Constants.ImagePath;
                    rm.responseData = pf;
                    rm.status = 1;
                    rm.message = Constants.uploadSuccess;
                }
                response = request.CreateResponse(HttpStatusCode.OK, rm);
                return response;
            });
        }
    }
}
