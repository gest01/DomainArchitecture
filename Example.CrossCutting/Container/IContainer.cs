using System;

namespace Example.CrossCutting.Container
{
    public interface IContainer : IServiceProvider, IDisposable
    {
        void Register<TService>(TService instance);
        void Register<TService>(Func<TService> factory);
        void Register<TService>() where TService : new();
        void Register<TService, TImplementation>() where TImplementation : TService;

        void UnRegister<TService>();
        void UnRegister(Type service);

        TService GetService<TService>();
    }
}
