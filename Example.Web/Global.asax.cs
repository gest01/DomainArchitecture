using System;
using System.Web;
using Example.Api.Common;
using Example.CrossCutting;
using Example.CrossCutting.Logging;
using Example.Web.Common;

namespace Example.Web
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly ILogger _log = ObjectServices.Logger.CreateLogger(typeof(Global));

        protected void Application_Start(object sender, EventArgs e)
        {
            _log.Info("*** Application Start  ***");
            _log.Info("*** Version {0} / BuildDate {1} ***", EnvironmentUtil.Version, EnvironmentUtil.BuildDate);

            // Configure API
            WebApi.Configure();

            // Configure MVC
            WebMvc.Configure();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _log.Info("*** Application End  ***");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext httpContext = ((HttpApplication)sender).Context;
            Exception ex = Server.GetLastError();
            _log.Error("*** Unhandled Application Error ***\r\n{0}", ex.ToString());
        }
    }
}