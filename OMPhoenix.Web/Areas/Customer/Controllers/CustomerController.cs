using OMPhoenix.Data.Infrastructure;
using OMPhoenix.Data.Repositories;
using OMPhoenix.Entities;
using OMPhoenix.Services.Abstract;
using OMPhoenix.ViewModel;
using OMPhoenix.Web.Infrastructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OMPhoenix.Web.Areas.Customer.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiControllerBase
    {
        private readonly ICustomerService _iCustomerService;

        public CustomerController(
            ICustomerService iCustomerService,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _iCustomerService = iCustomerService;
        }

        [HttpPost]
        [Route("savecustomersdata")]
        public HttpResponseMessage AddOrUpdateCustomer(HttpRequestMessage request, [FromBody]CustomerViewModel customerVm)
        {
            return CreateHttpResponse(request, () =>
            {
                ResponseViewModel rm = new ResponseViewModel();
                _iCustomerService.AddUpdateCustomerRecords(customerVm);
                return Request.CreateResponse(HttpStatusCode.OK, rm);
            });
        }

        [HttpGet]
        [Route("getallcustomers")]
        public HttpResponseMessage GeAllCustomer(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                ResponseViewModel rm = new ResponseViewModel();
                rm = _iCustomerService.GetAllCustomers();
                return Request.CreateResponse(HttpStatusCode.OK, rm);
            });
        }
    }
}