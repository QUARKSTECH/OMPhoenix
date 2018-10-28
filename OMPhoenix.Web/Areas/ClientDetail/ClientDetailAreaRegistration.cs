using System.Web.Mvc;

namespace OMPhoenix.Web.Areas.ClientDetail
{
    public class ClientDetailAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ClientDetail";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ClientDetail_default",
                "ClientDetail/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}