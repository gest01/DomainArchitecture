using System;

namespace Example.CrossCutting.Container.Default.Activation
{
    internal class FactoryActivator : IServiceActivator
    {
        public Func<Object> Factory { get; set; }

        public object CreateInstance(params object[] args)
        {
            return Factory();
        }
    }
}
