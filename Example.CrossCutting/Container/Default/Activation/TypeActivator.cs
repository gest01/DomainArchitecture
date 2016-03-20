using System;

namespace Example.CrossCutting.Container.Default.Activation
{
    internal class TypeActivator : IServiceActivator
    {
        public Type Type { get; set; }

        public object CreateInstance(params Object[] args)
        {
            return Activator.CreateInstance(Type, args);
        }
    }
}
