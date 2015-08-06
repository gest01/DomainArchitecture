using System;
using System.Web;
using System.Web.Mvc;
using Example.CrossCutting.Security;

namespace Example.Web.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User.IsAdmin();
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            ErrorViewBuilder.NotAuthorized(filterContext);
        }
    }
}