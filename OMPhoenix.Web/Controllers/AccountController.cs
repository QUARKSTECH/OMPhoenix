using OMPhoenix.Data.Infrastructure;
using OMPhoenix.Data.Repositories;
using OMPhoenix.Entities;
using OMPhoenix.ViewModel;
using OMPhoenix.Web.Infrastructure.Core;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace OMPhoenix.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiControllerBase
    {
        //private readonly ICommonService _commonService;
        //private readonly IMembershipService _membershipService;
        //private AuthRepository _repo = null;
        private const string URL = "http://smsp.myoperator.co/api/postsms.php";
        private const string URL1 = "http://sms.quarkstech.com/api/postsms.php";
        private const string xmlString = "";
        public AccountController(//ICommonService commonService, IMembershipService membershipService,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            //_repo = new AuthRepository();
            //_commonService = commonService;
            //_membershipService = membershipService;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, new { success = true }); ;

                if (ModelState.IsValid)
                {
                    //MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);
                    //MembershipContext _userContext = _membershipService.ValidateToken(user.Token);
                    if (user.UserName == "admin" && user.Password == "admin@123")
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
                else
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });

                return response;
            });
        }

        [AllowAnonymous]
        [Route("sendsms")]
        [HttpPost]
        public HttpResponseMessage SendSms(HttpRequestMessage request, [FromBody] string xmlString)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, new { success = true }); ;
                if (xmlString != null)
                {
                    var test = xmlString.Split(new string[] { "spc" }, StringSplitOptions.None);
                    xmlString = test[0] + "%0a" + test[1]+ "%0a" + test[2]+ "%0a"+test[3];
                    //Regex pattern = new Regex(@"(^|spc)($|)");//new Regex("[spc]");
                    //pattern.Replace(xmlString, "%0a");
                    var data = postXMLData(URL, xmlString);
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                }
                else
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });

                return response;
            });
        }

        [AllowAnonymous]
        [Route("sendsmsdynamic")]
        [HttpPost]
        public HttpResponseMessage SendSmsMultipleFileds(HttpRequestMessage request, [FromBody] string xmlString)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, new { success = true }); ;
                if (xmlString != null)
                {
                    var test = xmlString.Split(new string[] { "spc" }, StringSplitOptions.None);
                    var xmlData = "";
                    for (int i = 0; i < test.Length; i++)
                    {
                        if (i < test.Length - 1)
                            xmlData += test[i] + "%0a";
                        else
                            xmlData += test[i];
                    }
                    var data = postXMLData(URL, xmlData);
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                }
                else
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });

                return response;
            });
        }

        private static string postXMLData(string destinationUrl, string requestXml)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes;
            bytes = Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;
        }
    }
}
