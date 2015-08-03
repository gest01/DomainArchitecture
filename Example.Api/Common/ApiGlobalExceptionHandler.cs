using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Example.Api.Common
{
    /// <summary>
    /// Globaler Exception Handler für API Errors. Liefert ein Fehlerobjekt als JSON an den Client.
    /// </summary>
    internal class ApiGlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new PlainExceptionResult
            {
                Request = context.ExceptionContext.Request,
                Exception = context.Exception
            };
        }

        private class PlainExceptionResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public Exception Exception { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                // Achtung : Clientseitiger Handler ist die Funktion handleError in shell.js

                var errorObject = new  {
                    ErrorMessage = Exception.Message,
                    Stacktrace = Exception.ToString()
                };

                HttpResponseMessage response = Request.CreateResponse<Object>(HttpStatusCode.InternalServerError, errorObject);
                response.RequestMessage = Request;
                return Task.FromResult(response);
            }
        }
    }
}