using System;
using Example.CrossCutting.Caching;
using Example.CrossCutting.Caching.Default;
using Example.CrossCutting.Container;
using Example.CrossCutting.Container.Default;
using Example.CrossCutting.Logging;
using Example.CrossCutting.Logging.Default;

namespace Example.CrossCutting
{
    public static class ObjectServices
    {
        private static LoggerFactory _loggerfactory = new DefaultLoggerFactory();
        private static CacheFactory _cachefactory = new DefaultCacheFactory();
        private static ContainerFactory _containerfactory = new DefaultContainerFactory();

        public static CacheFactory Cache { get { return _cachefactory;  } }
        public static LoggerFactory Logger { get { return _loggerfactory; } }
        public static ContainerFactory Container { get { return _containerfactory; } }

        public static void SetContainerFactory(ContainerFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _containerfactory = factory;
        }

        public static void SetLoggerFactory(LoggerFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _loggerfactory = factory;
        }

        public static void SetCacheFactory(CacheFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _cachefactory = factory;
        }
    }
}
