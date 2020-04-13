using System;
using System.Text;

namespace DarkCity
{
    public enum LogSeverity
    {
        Debug = 10,
        Info = 20,
        Warn = 30,
        Critical = 40,
    }

    public static class Log
    {
        public delegate void LogHandler(LogSeverity severity, DateTime timestamp, string message);

        public static event LogHandler LogReceived;

        public static void Debug(string message)
        {
            if (LogReceived != null)
                LogReceived(LogSeverity.Debug, DateTime.Now, message);
        }

        public static void Info(string message)
        {
            if (LogReceived != null)
                LogReceived(LogSeverity.Info, DateTime.Now, message);
        }
        
        public static void Warn(string message)
        {
            if (LogReceived != null)
                LogReceived(LogSeverity.Warn, DateTime.Now, message);
        }

        public static void Critical(string message)
        {
            if (LogReceived != null)
                LogReceived(LogSeverity.Critical, DateTime.Now, message);
        }
    }
}
