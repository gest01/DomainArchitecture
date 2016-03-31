using System;
using Example.CrossCutting.Container;

namespace Example.Domain
{
    public static class ServiceRegistry
    {
        public static IContainer RegisterDomainServices(this IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Register<IDataDomainService, DataDomainService>();

            return container;
        }
    }
}
