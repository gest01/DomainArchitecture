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
            container.Register<IDbContext, EfDbContext>();

            return container;
        }
    }
}
