using System;
using System.Collections.Generic;

namespace Example.CrossCutting.Container.Default
{
    internal class DefaultContainer : IContainer
    {
        private readonly IDictionary<String, IObjectActivator> _activators = new Dictionary<String, IObjectActivator>();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public TService GetService<TService>()
        {
            throw new NotImplementedException();
        }

        public void Register<TService>() where TService : new()
        {
            throw new NotImplementedException();
        }

        public void Register<TService>(Func<TService> factory)
        {
            throw new NotImplementedException();
        }

        public void Register<TService>(TService instance)
        {
            throw new NotImplementedException();
        }

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            throw new NotImplementedException();
        }

        public void UnRegister(Type service)
        {
            throw new NotImplementedException();
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
