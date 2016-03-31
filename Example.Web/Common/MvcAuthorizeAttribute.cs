using System;
using System.Web;
using System.Web.Mvc;
using Example.Domain.Security;

namespace Example.Web.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class MvcAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User.CanRead();
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            ErrorViewBuilder.NotAuthorized(filterContext);
        }
    }
}