using System;

namespace Example.CrossCutting.Logging.Default
{
    internal class DefaultLoggerFactory : LoggerFactory
    {
        public override ILogger CreateLogger(string name)
        {
            return new DefaultLogger(name);
        }

        public override ILogger CreateLogger(Type type)
        {
            return new DefaultLogger(type);
        }
    }
}
