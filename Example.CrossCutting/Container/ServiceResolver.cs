using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Example.CrossCutting.Container
{
    public class ServiceResolver
    {
        private readonly IServiceProvider _serviceprovider;

        public ServiceResolver(IServiceProvider serviceprovider)
        {
            _serviceprovider = serviceprovider;
        }

        public Object CreateInstance(Type type)
        {
            ConstructorInfo defaultConstructor = type.GetConstructor(Type.EmptyTypes);
            if (defaultConstructor != null)
            {
                return Activator.CreateInstance(type);
            }

            foreach (ConstructorInfo ctor in type.GetConstructors())
            {
                IEnumerable<Object> services = Resolve(ctor);
                if (services != null)
                {
                    return Activator.CreateInstance(type, services.ToArray());
                }
            }

            throw new ArgumentException(string.Format("Unable to create an instance of type '{0}'", type));

        }

        public IEnumerable<Object> Resolve(ConstructorInfo ctor)
        {
            ParameterInfo[] parameters = ctor.GetParameters();
            List<Object> services = new List<object>(parameters.Length);
            foreach (ParameterInfo parameter in parameters)
            {
                object service = Resolve(parameter);
                if (service == null)
                {
                    return null; // TODO Throw Exception ?
                }

                services.Add(service);
            }

            return services;
        }

        public Object Resolve(ParameterInfo parameter)
        {
            return _serviceprovider.GetService(parameter.ParameterType);
        }
    }
}
