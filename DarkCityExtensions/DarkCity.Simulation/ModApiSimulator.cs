using Eleon.Modding;
using DarkCity;
using System;

namespace DarkCity.Simulation
{
    public class ModApiSimulator : IModApi
    {
        public IPlayfield ClientPlayfield { get; set; }

        public INetwork Network { get; set; }

        public IGui GUI { get; set; }

        public IPda PDA { get; set; }

        public IScript Scripting { get; set; }

        public ISoundPlayer SoundPlayer { get; set; }

        public IApplication Application { get; set; }

        public event GameEventDelegate GameEvent;

        public event Log.LogHandler LogEntry;

        public ModApiSimulator()
        {
        }

        public void TriggerGameEvent(GameEventType type, object arg1 = null, object arg2 = null, object arg3 = null, object arg4 = null, object arg5 = null)
        {
            if (this.GameEvent != null) this.GameEvent(type, arg1, arg2, arg3, arg4, arg5);
        }

        public void Log(string text) { if (this.LogEntry != null) this.LogEntry(LogSeverity.Info, DateTime.Now, text); }
        public void LogError(string text) { if (this.LogEntry != null) this.LogEntry(LogSeverity.Critical, DateTime.Now, text); }
        public void LogWarning(string text) { if (this.LogEntry != null) this.LogEntry(LogSeverity.Warn, DateTime.Now, text); }
    }
}
