using System.Web.Routing;

namespace casestudy
{
    public class RouteConfig2
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            object value = routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

