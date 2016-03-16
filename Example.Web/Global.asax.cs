using System;
using System.Web;
using Example.Api.Common;
using Example.Application;
using Example.CrossCutting;
using Example.CrossCutting.Container;
using Example.CrossCutting.Logging;
using Example.Infrastructure;
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

            // Self made IoC Container :-) --> Better Use Automapper
            IContainer compositeRoot = ObjectServices.Container.CreateContainer("MyContainer");
            compositeRoot.RegisterApplicationServices();
            compositeRoot.RegisterInfrastructure();

            // Configure API
            WebApi.Configure(compositeRoot);

            // Configure MVC
            WebMvc.Configure(compositeRoot);
        }

#if DEBUG
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            _log.Debug("{0} -> {1}", Request.HttpMethod, Request.Url.AbsoluteUri);
        }
#endif

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