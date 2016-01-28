using System.Security.Principal;
using System.Threading;
using Example.CrossCutting;
using Example.CrossCutting.Logging;

namespace Example.Application
{
    internal class AppServiceBase
    {
        protected AppServiceBase()
        {
            Logger = ObjectServices.Logger.CreateLogger(GetType());
        }

        public IPrincipal User
        {
            get
            {
                return Thread.CurrentPrincipal;
            }
        }

        public ILogger Logger { get; private set; }
    }
}
