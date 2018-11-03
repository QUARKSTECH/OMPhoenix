using OMPhoenix.Data.Infrastructure;
using OMPhoenix.Data.Repositories;
using OMPhoenix.Entities;
using OMPhoenix.Services.Abstract;
using OMPhoenix.ViewModel;
using OMPhoenix.Web.Infrastructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OMPhoenix.Web.Areas.Machine.Controllers
{
    [RoutePrefix("api/machine")]
    public class MachineController : ApiControllerBase
    {
        private readonly IMachineService _iMachineService;

        public MachineController(
            IMachineService iMachineService,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _iMachineService = iMachineService;
        }

        [HttpPost]
        [Route("savemachinesdata")]
        public HttpResponseMessage AddOrUpdateMachine(HttpRequestMessage request, [FromBody]MachineViewModel machineVm)
        {
            return CreateHttpResponse(request, () =>
            {
                ResponseViewModel rm = new ResponseViewModel();
                _iMachineService.AddUpdateMachineRecords(machineVm);
                return Request.CreateResponse(HttpStatusCode.OK, rm);
            });
        }

        [HttpGet]
        [Route("getallmachines")]
        public HttpResponseMessage GeAllMachine(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                ResponseViewModel rm = new ResponseViewModel();
                rm = _iMachineService.GetAllMachine();
                return Request.CreateResponse(HttpStatusCode.OK, rm);
            });
        }
    }
}
