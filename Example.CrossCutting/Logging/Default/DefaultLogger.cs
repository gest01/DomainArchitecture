using System;

namespace Example.CrossCutting.Logging.Default
{
    internal class DefaultLogger : ILogger
    {
        private readonly string _loggername;

        public DefaultLogger(Type type)
            :this(type.FullName)  { }

        public DefaultLogger(String name)
        {
            _loggername = name;
        }

        public void Debug(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(string format, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
