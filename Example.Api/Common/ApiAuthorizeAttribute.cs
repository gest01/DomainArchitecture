using System;
using System.Web.Http;

using Example.Domain.Security;

namespace Example.Api.Common
{
    /// <summary>
    /// Authorization Attribute für Ressourcen auf die der Benutzer zugreiffen kann
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            return actionContext.RequestContext.Principal.CanRead();
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}