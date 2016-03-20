using System;

namespace Example.CrossCutting.Container.Default.Activation
{
    internal class InstanceActivator : IServiceActivator
    {
        public Object Instance { get; set; }

        public object CreateInstance(params object[] args)
        {
            return Instance;
        }
    }
}
