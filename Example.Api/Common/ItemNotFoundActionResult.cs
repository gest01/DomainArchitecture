using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Example.Api.Common
{
    /// <summary>
    /// Liefert ein Http-NotFound (404) mit einer Fehlermeldung
    /// </summary>
    internal class ItemNotFoundActionResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly String _message;


        public ItemNotFoundActionResult(HttpRequestMessage request)
            : this(request, String.Empty) { }

        public ItemNotFoundActionResult(HttpRequestMessage request, String message)
        {
            _message = message;
            _request = request;
        }

        public System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            var errorObject = new
            {
                Message = _message
            };

            HttpResponseMessage response = _request.CreateResponse<Object>(HttpStatusCode.NotFound, errorObject);
            response.RequestMessage = _request;
            return Task.FromResult(response);
        }
    }
}