using System;
using System.Collections.Generic;
using System.Reflection;

namespace Example.CrossCutting.Container.Default
{
    internal class DefaultContainer : IContainer
    {
        private readonly IDictionary<Type, IServiceActivator> _activators = new Dictionary<Type, IServiceActivator>();

        public void Dispose()
        {
            _activators.Clear();
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));

            if (_activators.ContainsKey(serviceType))
            {
                IServiceActivator activator = _activators[serviceType];
                if (activator is TypeActivator)
                {
                    Type concreteType = ((TypeActivator)activator).Type;
                    ConstructorInfo defaultctor = concreteType.GetConstructor(Type.EmptyTypes);
                    if (defaultctor != null)
                    {
                        var value = activator.CreateInstance();
                        return value;
                    }

                    ServiceResolver resolver = new ServiceResolver(this);
                    return resolver.CreateInstance(concreteType);
                }
                else
                {
                    return activator.CreateInstance();
                }
            }

            return null;
        }

        public TService GetService<TService>()
        {
            Type serviceType = typeof(TService);
            object instance = this.GetService(serviceType);
            if (instance != null)
            {
                return (TService)(instance);
            }

            return default(TService);
        }

        public void Register<TService>() where TService : new()
        {
            Type serviceType = typeof(TService);
            if (_activators.ContainsKey(serviceType))
            {
                throw new ArgumentException(string.Format("Type {0} already registered!", serviceType));
            }

            _activators.Add(serviceType, new TypeActivator() { Type = typeof(TService) });
        }

        public void Register<TService>(TService instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            Type serviceType = typeof(TService);
            if (_activators.ContainsKey(serviceType))
            {
                throw new ArgumentException(string.Format("Type {0} already registered!", serviceType));
            }

            _activators.Add(serviceType, new InstanceActivator() { Instance = instance });
        }

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            Type serviceType = typeof(TService);
            if (_activators.ContainsKey(serviceType))
            {
                throw new ArgumentException(string.Format("Type {0} already registered!", serviceType));
            }

            _activators.Add(serviceType, new TypeActivator() { Type = typeof(TImplementation) });
        }

        public void UnRegister(Type service)
        {
            _activators.Remove(service);
        }

        public void UnRegister<TService>()
        {
            UnRegister(typeof(TService));
        }

        private interface IServiceActivator
        {
            Object CreateInstance(params Object[] args);
        }

        private class TypeActivator : IServiceActivator
        {
            public Type Type { get; set; }

            public object CreateInstance(params Object[] args)
            {
                return Activator.CreateInstance(Type, args);
            }
        }


        private class InstanceActivator : IServiceActivator
        {
            public Object Instance { get; set; }

            public object CreateInstance(params object[] args)
            {
                return Instance;                   
            }
        }
    }
}
