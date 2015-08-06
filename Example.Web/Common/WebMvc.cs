using System.Web.Mvc;
using System.Web.Routing;

namespace Example.Web.Common
{
    internal static class WebMvc
    {
        public static void Configure()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }

    internal class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MvcGlobalExceptionHandler());
            filters.Add(new MvcAuthenticationFilter());
            filters.Add(new MvcAuthorizeAttribute());
            filters.Add(new MvcRequestLoggerFilter());
        }
    }

    internal class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}