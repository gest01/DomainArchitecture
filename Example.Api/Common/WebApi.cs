using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Example.Api.Common
{
    public static class WebApi
    {
        public static void Configure()
        {
            GlobalConfiguration.Configure(ConfigureApi);
        }

        private static void ConfigureApi(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Add(typeof(IExceptionLogger), new ApiExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new ApiGlobalExceptionHandler());

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization#json_dates
            // http://stackoverflow.com/a/28732833
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;

            config.Filters.Add(new ApiAuthorizeAttribute());
            config.Filters.Add(new ApiAuthenticationFilter());
            config.Filters.Add(new ApiRequestLoggerFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
