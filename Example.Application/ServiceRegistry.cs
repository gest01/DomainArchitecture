using System;
using Example.CrossCutting.Container;

namespace Example.Application
{
    public static class ServiceRegistry
    {
        public static IContainer RegisterApplicationServices(this IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Register<IMyAppService, MyAppService>();

            return container;
        }
    }
}
