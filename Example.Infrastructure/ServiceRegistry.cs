using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.CrossCutting.Container;
using Example.Domain.Repositories;

namespace Example.Infrastructure
{
    public static class ServiceRegistry
    {
        public static IContainer RegisterInfrastructure(this IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Register<IMyDataRepository, MyDataRepository>();


            return container;
        }
    }
}
