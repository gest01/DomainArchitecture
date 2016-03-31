using System;
using System.Net.Http;
using System.Web.Http;

using Example.Domain.Security;

namespace Example.Api.Common
{
    /// <summary>
    /// Authorization Attribute für Ressourcen die Admin-Berechtigungen benötigen
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ApiAdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            return actionContext.RequestContext.Principal.IsAdmin();
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
            {
                Content = new StringContent("Unauthorized request " + actionContext.Request.RequestUri)
            };

            //base.HandleUnauthorizedRequest(actionContext);
        }
    }
}