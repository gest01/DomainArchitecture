using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Example.CrossCutting.Container;

namespace Example.Api.Common
{
    internal class CustomDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public CustomDependencyResolver(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return this; // heheheh !
        }

        public void Dispose()
        {

        }

        public object GetService(Type serviceType)
        {
            return _container.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new Object[0];
        }
    }
}
