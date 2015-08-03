using System.Web.Http.ExceptionHandling;
using Example.CrossCutting;
using Example.CrossCutting.Logging;

namespace Example.Api.Common
{
    /// <summary>
    /// Exception Logger für API calls
    /// </summary>
    internal class ApiExceptionLogger : ExceptionLogger
    {
        private static readonly LoggerFactory _logger = ObjectServices.Logger;

        public override void Log(ExceptionLoggerContext context)
        {
            var ex = context.Exception;
            var controllerContext = context.ExceptionContext.ControllerContext;
            if (controllerContext != null)
            {
                _logger.CreateLogger(controllerContext.Controller.GetType()).Error("***** UNHANDLED API CONTROLLER EXCEPTION *****\r\n{0}", ex.ToString());
            }
            else
            {
                _logger.CreateLogger(typeof(ApiExceptionLogger)).Error("***** UNHANDLED API EXCEPTION *****\r\n{0}", ex.ToString());
            }
        }
    }
}