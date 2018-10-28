using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using OMPhoenix.Web.App_Start;
using System.Web.Optimization;

namespace OMPhoenix.Web
{
    public class Global : HttpApplication
    {
        void Application_Start()
        {
            // Code that runs on application startup
            //AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            var config = GlobalConfiguration.Configuration;

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(config);
            Bootstrapper.Run();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.EnsureInitialized();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}