using System;
using Example.CrossCutting.Logging;
using Example.CrossCutting.Logging.Default;

namespace Example.CrossCutting
{
    public static class ObjectServices
    {
        private static LoggerFactory _loggerFactory = new DefaultLoggerFactory();

        public static LoggerFactory Logger { get { return _loggerFactory; } }

        public static void SetLoggerFactory(LoggerFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _loggerFactory = factory;
        }
    }
}
