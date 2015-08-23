using System;

namespace Example.CrossCutting.Logging
{
    public class LogMessage
    {
        public String Message { get; set; }
        public String User { get; set; }
        public LogLevels LogLevel { get; set; }
        public DateTime TimeStamp { get; set; }
        public String LoggerName { get; set; }

        public override string ToString()
        {
            return LogMessageFormatter.Default.Format(this);
        }
    }
}
