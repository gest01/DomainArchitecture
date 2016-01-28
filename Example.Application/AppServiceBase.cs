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
            Mapper = new ObjectMapper();
        }


        protected ILogger Logger { get; private set; }
        protected ObjectMapper Mapper { get; private set; }

        protected IPrincipal User
        {
            get
            {
                return Thread.CurrentPrincipal;
            }
        }

        
    }
}
