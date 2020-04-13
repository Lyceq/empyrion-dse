using Eleon.Modding;
using DarkCity.Data;
using DarkCity.Network;
using System;
using System.Threading;

namespace DarkCity
{
    public class GameStateProcessor
    {
        private Thread processor = null;

        public TimeSpan TickTime { get; set; } = new TimeSpan(0, 0, 1);

        public GameStateProcessor()
        {
            this.processor = new Thread(this.Process);
            this.processor.Name = "DCE Game State Processor";
            this.processor.IsBackground = true;
            this.processor.Start();
        }

        public void Stop()
        {
            if (this.processor != null)
            {
                this.processor.Abort();
                this.processor = null;
            }
        }

        // Variables tracking known game state. Any changes trigger an update to clients.
        IPlayfield clientPlayfield = null;


        protected void Process()
        {
            try
            {
                DateTime start;

                while (true)
                {
                    start = DateTime.Now;

                    if (this.clientPlayfield != EmpyrionExtension.EmpyrionApi?.ClientPlayfield) this.UpdateClientPlayfield();
                }
            } catch (ThreadAbortException)
            {
            } catch (Exception ex)
            {
                Log.Warn($"An unexpected error occurred in the game state processor. {ex.Message}");
            }
        }

        protected void UpdateClientPlayfield()
        {
            this.clientPlayfield = EmpyrionExtension.EmpyrionApi?.ClientPlayfield;
            RequestPacket packet = new RequestPacket(RequestPacket.RequestSpecification.ClientPlayfieldName, this.clientPlayfield?.Name);
            EmpyrionExtension.Instance.NetworkServerHost.Server.Broadcast(packet);
        }
    }
}
