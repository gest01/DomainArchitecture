using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
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

            config.Filters.Add(new ApiAuthorizeAttribute());
            config.Filters.Add(new ApiAuthenticationFilter());
            config.Filters.Add(new ApiRequestLoggerFilter());

            // Provide only JSON Formatter
            JsonMediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(new IsoDateTimeConverter());
            serializerSettings.ContractResolver = new DefaultContractResolver()
            {
                IgnoreSerializableAttribute = true // Serializable-Attribute auf den DTO's sind für Json irrelevant
            };

            // http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization#json_dates
            // http://stackoverflow.com/a/28732833
            serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            jsonFormatter.SerializerSettings = serializerSettings;

            config.Formatters.Clear();
            config.Formatters.Add(jsonFormatter);


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
