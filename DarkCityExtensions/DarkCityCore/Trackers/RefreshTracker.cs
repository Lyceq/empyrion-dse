using DarkCity.Network;
using System;
using System.Threading;

namespace DarkCity.Trackers
{
    public abstract class RefreshTracker<T> : Tracker where T : Packet
    {
        private Thread refreshThread = null;

        protected T RefreshPacket { get; set; } = null;

        public TimeSpan RefreshWait { get; set; } = TimeSpan.FromMinutes(1);

        public RefreshTracker()
        {
            this.refreshThread = new Thread(this.Refresh);
            this.refreshThread.Name = $"{this.GetType().Name} refresh thread";
            this.refreshThread.IsBackground = true;
            this.refreshThread.Start();
        }

        public void RefreshOnce()
        {
            if (this.RefreshPacket != null)
                this.Network?.Send(this.RefreshPacket);
        }

        private void Refresh()
        {
            while (true)
            {
                try
                {
                    this.RefreshOnce();
                } catch { }
                Thread.Sleep(this.RefreshWait);
            }
        }
    }
}
