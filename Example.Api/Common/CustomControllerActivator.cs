using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Example.CrossCutting.Container;

namespace Example.Api.Common
{
    /// <summary>
    /// Custom API Controller Activator for DI using <see cref="Example.CrossCutting.Container.IContainer"/> as ioc container
    /// 
    /// NOTE : This is a self made DI/IoC Framework for demo purposes only :-)
    /// For real scenarios use NInject, Unity, Autofac or another sophisticated Framework 
    /// 
    /// </summary>
    internal class CustomControllerActivator : IHttpControllerActivator
    {
        private readonly ServiceResolver _resolver;

        public CustomControllerActivator(IContainer compositeRoot)
        {
            _resolver = new ServiceResolver(compositeRoot);
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)_resolver.CreateInstance(controllerType);
        }
    }

    public static class HttpConfigurationExtensions
    {
        /// <summary>
        /// Registers my poor-mans dependency injection controller activator using <see cref="Example.CrossCutting.Container.IContainer"/> as ioc container
        /// See http://stackoverflow.com/questions/7099406/what-is-the-real-difference-between-bastard-injection-and-poor-mans-injectio
        /// </summary>
        /// <param name="config">HttpConfiguration</param>
        /// <param name="compositeRoot">IContainer</param>
        public static void UseCustomControllerActivator(this HttpConfiguration config, IContainer compositeRoot)
        {
            config.Services.Replace(typeof(IHttpControllerActivator), new CustomControllerActivator(compositeRoot));
        }
    }
}
