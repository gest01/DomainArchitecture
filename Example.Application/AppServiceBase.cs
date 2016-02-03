using System;
using System.Security.Principal;
using System.Threading;
using Example.CrossCutting;
using Example.CrossCutting.Logging;

namespace Example.Application
{
    public class AppServiceBase : IDisposable
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        #endregion

    }
}
