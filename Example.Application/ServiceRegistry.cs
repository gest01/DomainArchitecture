using System;
using Example.CrossCutting.Container;
using Example.Domain.Repositories;

namespace Example.Application
{
    public static class ServiceRegistry
    {
        public static IContainer RegisterApplicationServices(this IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Register<IMyAppService, MyAppService>();

            Container = new ServiceContainer(container);

            return container;
        }

        internal static ServiceContainer Container { get; private set; }
    }

    public class ServiceContainer
    {
        private readonly IContainer _container;

        public ServiceContainer(IContainer container)
        {
            _container = container;
        }

        public IMyAppService MyAppService {  get { return _container.GetService<IMyAppService>(); } }
        public IMyDataRepository MyDataRepository {  get { return _container.GetService<IMyDataRepository>(); } }

    }
}
