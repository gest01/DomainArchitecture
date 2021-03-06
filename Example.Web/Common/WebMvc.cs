﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Example.CrossCutting.Container;

namespace Example.Web.Common
{
    internal static class WebMvc
    {
        public static void Configure(IContainer compositeRoot)
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Register my poor-mans injection :-)
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory(compositeRoot));

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

    internal class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/ui-bootstrap-csp.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                     "~/Scripts/jquery-{version}.js",
                     "~/Scripts/jquery.validate.js",
                     "~/Scripts/jquery.validate.unobtrusive.js",
                     "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/Scripts/angular.js",
                     "~/Scripts/angular-resource.js",
                     "~/Scripts/angular-ui-router.js",
                     "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/app.js"));
        }
    }
}