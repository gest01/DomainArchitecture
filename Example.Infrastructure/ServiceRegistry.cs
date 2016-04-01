using System;
using Example.CrossCutting.Container;
using Example.CrossCutting.DataAccess;
using Example.Domain.Repositories;
using Example.Infrastructure.Entity;

namespace Example.Infrastructure
{
    public static class ServiceRegistry
    {
        public static IContainer RegisterInfrastructure(this IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Register<IMyDataRepository, MyDataRepository>();

            //container.Register<IUnitOfWork, EfUnitOfWork>(); // Real EF Db context
            container.Register<IUnitOfWork, DemoUnitOfWork>(); // InMemory Store for demo 

            return container;
        }
    }
}
