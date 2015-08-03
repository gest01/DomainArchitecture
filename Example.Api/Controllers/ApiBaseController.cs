using System;
using System.Web.Http;
using Example.Api.Common;
using Example.CrossCutting;
using Example.CrossCutting.Logging;

namespace Example.Api.Controllers
{
    public class ApiBaseController : ApiController
    {
        public ApiBaseController()
        {
            Logger = ObjectServices.Logger.CreateLogger(GetType());
        }

        protected ILogger Logger { get; private set; }

        /// <summary>
        /// Liefert ein 404-NotFound mit einer Message
        /// </summary>
        /// <param name="format">Format String</param>
        /// <param name="args">Args</param>
        /// <returns>ItemNotFoundActionResult</returns>
        [NonAction]
        protected IHttpActionResult ItemNotFound(String format, params Object[] args)
        {
            Logger.Warn("Item not found : {0}", String.Format(format, args));

            return new ItemNotFoundActionResult(Request, String.Format(format, args));
        }

        /// <summary>
        /// Liefert ein 404-NotFound mit einer Message
        /// </summary>
        /// <returns>ItemNotFoundActionResult</returns>
        [NonAction]
        protected IHttpActionResult ItemNotFound()
        {
            return ItemNotFound("Item Not found");
        }
    }
}
