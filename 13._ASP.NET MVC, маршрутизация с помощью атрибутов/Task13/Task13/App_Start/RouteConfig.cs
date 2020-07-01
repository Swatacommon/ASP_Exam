using System.Web.Mvc;
using System.Web.Routing;

namespace Task13
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
               name: "MResearch",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "MResearch", action = "index", id = UrlParameter.Optional }
             );
        }
    }
}
