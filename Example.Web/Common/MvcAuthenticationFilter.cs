using System;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using Example.Application;
using Example.CrossCutting;
using Example.CrossCutting.Logging;

namespace Example.Web.Common
{
    public class MvcAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private readonly ILogger _log = ObjectServices.Logger.CreateLogger(typeof(MvcAuthenticationFilter));
        private readonly PrincipalFactory _userFactory = new PrincipalFactory();

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            HttpContextBase httpContext = filterContext.HttpContext;
            ClaimsPrincipal user = httpContext.User as ClaimsPrincipal;

            try
            {
                Thread.CurrentPrincipal = httpContext.User = _userFactory.TransformPrincipal(user);
            }
            catch (Exception ex)
            {
                _log.Error("*** Authentication Error ***\r\n{0}", ex.ToString());
                filterContext.Controller.TempData[ErrorViewBuilder.TempData_Key_Exception] = ex;
                Thread.CurrentPrincipal = httpContext.User = _userFactory.CreateAnonymous(user);
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext) { }
    }
}