using System.Web.Mvc;
using Example.CrossCutting;
using Example.CrossCutting.Logging;

namespace Example.Web.Common
{
    public class MvcGlobalExceptionHandler : IExceptionFilter
    {
        private static readonly ILogger _log = ObjectServices.Logger.CreateLogger(typeof(MvcGlobalExceptionHandler));

        public void OnException(ExceptionContext filterContext)
        {
            _log.Error("*** OnException ***\r\n{0}", filterContext.Exception);

            filterContext.ExceptionHandled = true;
            ErrorViewBuilder.UnhandledError(filterContext);
        }
    }
}