using System;
using System.Text;

namespace Example.CrossCutting.Logging
{
    public abstract class LogMessageFormatter
    {
        private static LogMessageFormatter _current = new DefaultLogMessageFormatter();

        public static LogMessageFormatter Default
        {
            get { return _current; }
            set { _current = value; }
        }

        public abstract String Format(LogMessage message);

        private class DefaultLogMessageFormatter : LogMessageFormatter
        {
            public override string Format(LogMessage message)
            {
                StringBuilder builder = new StringBuilder();

                builder.AppendFormat("{0}", message.LogLevel.ToString()[0]);
                builder.Append(" | ");
                builder.AppendFormat("{0}", String.IsNullOrWhiteSpace(message.User) ? "UNKNOWN" : message.User);
                builder.Append(" | ");
                builder.AppendFormat("{0} {1}", message.TimeStamp.ToLongTimeString(), message.TimeStamp.ToShortDateString());
                builder.Append(" | ");
                builder.AppendFormat("[{0}]", message.LoggerName);
                builder.AppendFormat(" - {0}", message.Message);

                return builder.ToString();
            }
        }
    }
}
