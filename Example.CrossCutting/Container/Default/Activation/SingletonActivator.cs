using System;
using System.Collections.Generic;

namespace Example.CrossCutting.Container.Default.Activation
{
    internal class SingletonActivator : IServiceActivator
    {
        private static Dictionary<Type, Object> _instances = new Dictionary<Type, object>();

        public Type Type { get; set; }

        public object CreateInstance(params object[] args)
        {
            if (!_instances.ContainsKey(Type))
            {
                object instance = Activator.CreateInstance(Type);
                _instances.Add(Type, instance);
            }

            return _instances[Type];
        }
    }
}
