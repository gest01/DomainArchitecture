using System;
using System.Diagnostics;

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
            WriteLog(LogLevels.Debug, String.Format(format, args));
        }

        public void Error(string format, params object[] args)
        {
            WriteLog(LogLevels.Error, String.Format(format, args));
        }

        public void Info(string format, params object[] args)
        {
            WriteLog(LogLevels.Info, String.Format(format, args));
        }

        public void Warn(string format, params object[] args)
        {
            WriteLog(LogLevels.Warn, String.Format(format, args));
        }

        private void WriteLog(LogLevels level, String message)
        {
            LogMessage lm = new LogMessage()
            {
                User = System.Threading.Thread.CurrentPrincipal.Identity.Name,
                LoggerName = _loggername,
                LogLevel = level,
                TimeStamp = DateTime.Now,
                Message = message
            };

            Trace.WriteLine( LogMessageFormatter.Default.Format(lm) );
        }
    }
}
