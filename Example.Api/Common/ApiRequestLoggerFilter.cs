using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Filters;
using Example.CrossCutting;

namespace Example.Api.Common
{
    internal sealed class ApiRequestLoggerFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            String request = actionContext.Request.Method + " -> " + actionContext.Request.RequestUri;
            bool isAsync = actionContext.Request.IsAjaxRequest();
            if (isAsync)
            {
                request = "ASYNC " + request;
            }

            ObjectServices.Logger.CreateLogger(actionContext.ControllerContext.Controller.GetType()).Info("API {0}", request);
        }
    }

    internal static class HttpRequestMessageExtensions
    {
        public static bool IsAjaxRequest(this HttpRequestMessage request)
        {
            IEnumerable<string> xRequestedWithHeaders;
            if (request.Headers.TryGetValues("X-Requested-With", out xRequestedWithHeaders))
            {
                string headerValue = xRequestedWithHeaders.FirstOrDefault();
                if (!String.IsNullOrEmpty(headerValue))
                {
                    return String.Equals(headerValue, "XMLHttpRequest", StringComparison.OrdinalIgnoreCase);
                }
            }

            return false;
        }
    }
}