using System;
using System.Web.Mvc;
using System.Web.Routing;
using Example.CrossCutting.Container;

namespace Example.Web.Common
{
    /// <summary>
    /// Custom MVC Controller Activator for DI using <see cref="Example.CrossCutting.Container.IContainer"/> as ioc container
    /// 
    /// NOTE : This is a self made DI/IoC Framework for demo purposes only :-)
    /// For real scenarios use NInject, Unity, Autofac or another sophisticated Framework 
    /// 
    /// </summary>
    internal class CustomControllerFactory : DefaultControllerFactory
    {
        private readonly ServiceResolver _resolver;

        public CustomControllerFactory(IContainer compositeRoot)
        {
            _resolver = new ServiceResolver(compositeRoot);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)_resolver.CreateInstance(controllerType);
        }
    }
}