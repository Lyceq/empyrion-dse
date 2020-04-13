using System;
using System.IO;

namespace DarkCity
{
    public class FileLog : IDisposable
    {
        protected FileStream file = null;
        protected StreamWriter writer;

        private LogSeverity level = LogSeverity.Warn;
        public LogSeverity Level
        {
            get { return this.level; }
            set
            {
                Log_LogReceived(LogSeverity.Critical, DateTime.Now, $"Logging level changed from {this.level} to {value}.");
                this.level = value;
            }
        }

        public string TimestampFormat { get; set; }

        public FileLog(string path)
        {
            file = File.OpenWrite(path);
            writer = new StreamWriter(file);
            Log.LogReceived += Log_LogReceived;
        }

        private void Log_LogReceived(LogSeverity severity, DateTime timestamp, string message)
        {
            if (severity >= this.Level)
            {
                if (this.TimestampFormat == null)
                    writer.WriteLine(message);
                else
                    writer.WriteLine($"{timestamp.ToString(this.TimestampFormat)} - {severity} - {message}");
            }
        }

        public void Dispose()
        {
            if (file != null)
                file.Dispose();
        }
    }
}
