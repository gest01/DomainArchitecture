using System;
using System.Web.Mvc;
using Example.CrossCutting;
using Example.CrossCutting.Logging;

namespace Example.Web.Common
{
    internal sealed class MvcRequestLoggerFilter : IActionFilter
    {
        private LoggerFactory _factory = ObjectServices.Logger;

        public void OnActionExecuted(ActionExecutedContext filterContext) { }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            String request = filterContext.HttpContext.Request.HttpMethod + " -> " + filterContext.HttpContext.Request.Url.ToString();
            bool isAsync = filterContext.HttpContext.Request.IsAjaxRequest();
            if (isAsync)
            {
                request = "ASYNC " + request;
            }

            _factory.CreateLogger(filterContext.Controller.GetType()).Debug(request);
        }
    }
}