using System;

namespace Example.CrossCutting.Container.Default.Activation
{
    internal interface IServiceActivator
    {
        Object CreateInstance(params Object[] args);
    }
}
