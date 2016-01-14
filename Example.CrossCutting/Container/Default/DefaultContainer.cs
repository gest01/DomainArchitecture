using System;
using System.Collections.Generic;

namespace Example.CrossCutting.Container.Default
{
    internal class DefaultContainer : IContainer
    {
        private readonly IDictionary<Type, IObjectActivator> _activators = new Dictionary<Type, IObjectActivator>();

        public void Dispose()
        {
            _activators.Clear();
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));

            if (_activators.ContainsKey(serviceType))
                return _activators[serviceType].CreateInstance();

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

        public void Register<TService>(Func<TService> factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            Type serviceType = typeof(TService);
            if (_activators.ContainsKey(serviceType))
            {
                throw new ArgumentException(string.Format("Type {0} already registered!", serviceType));
            }

            _activators.Add(serviceType, new FactoryActivator(() => factory()));
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

            _activators.Add(serviceType, new FactoryActivator(() => { return instance; }   ));
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

        private interface IObjectActivator
        {
            Object CreateInstance();
        }

        private class TypeActivator : IObjectActivator
        {
            public Type Type { get; set; }

            public object CreateInstance()
            {
                return Activator.CreateInstance(Type);
            }
        }

        private class FactoryActivator : IObjectActivator
        {
            private Func<Object> _factory;

            public FactoryActivator(Func<Object> factory)
            {
                _factory = factory;
            }

            public object CreateInstance()
            {
                return _factory();
            }
        }
    }
}
