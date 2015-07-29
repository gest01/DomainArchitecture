using System;
using Example.CrossCutting.Caching;
using Example.CrossCutting.Caching.Default;
using Example.CrossCutting.Logging;
using Example.CrossCutting.Logging.Default;

namespace Example.CrossCutting
{
    public static class ObjectServices
    {
        private static LoggerFactory _loggerFactory = new DefaultLoggerFactory();
        private static CacheFactory _cachefactory = new DefaultCacheFactory();

        public static CacheFactory Cache { get { return _cachefactory;  } }
        public static LoggerFactory Logger { get { return _loggerFactory; } }

        public static void SetLoggerFactory(LoggerFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _loggerFactory = factory;
        }

        public static void SetCacheFactory(CacheFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _cachefactory = factory;
        }
    }
}
