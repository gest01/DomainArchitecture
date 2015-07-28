using System;

namespace Example.CrossCutting.Logging
{
    public interface ILogger
    {
        void Debug(String format, params Object[] args);
        void Info(String format, params Object[] args);
        void Warn(String format, params Object[] args);
        void Error(String format, params Object[] args);
    }
}
