using System;

namespace Example.CrossCutting.Logging
{
    public abstract class LoggerFactory
    {
        public abstract ILogger CreateLogger(Type type);
        public abstract ILogger CreateLogger(String name);
    }
}
