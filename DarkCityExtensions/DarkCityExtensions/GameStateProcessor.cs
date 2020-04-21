using Eleon.Modding;
using DarkCity.Network;
using System;
using System.Threading;

namespace DarkCity
{
    public class GameStateProcessor
    {
        private Thread processor = null;

        public EmpyrionStatePacket State { get; private set; }

        public TimeSpan TickTime { get; set; } = new TimeSpan(0, 0, 1);

        public GameStateProcessor()
        {
            this.State = this.GetCurrentState();

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

        protected void Process()
        {
            try
            {
                DateTime start;

                while (true)
                {
                    start = DateTime.Now;

                    EmpyrionStatePacket currentState = this.GetCurrentState();
                    if (!this.State.Equals(currentState))
                    {
                        this.State = currentState;
                        EmpyrionExtension.Instance.NetworkServerHost.Server.Broadcast(this.State);
                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Log.Warn($"An unexpected error occurred in the game state processor. {ex.Message}");
            }
        }

        public EmpyrionStatePacket GetCurrentState()
        {
            EmpyrionStatePacket state = new EmpyrionStatePacket();
            state.State = this.GetTranslatedGameState();
            state.Mode = this.GetTranslatedApplicationMode();
            state.LocalPlayerName = EmpyrionExtension.Application?.LocalPlayer?.Name;
            state.ClientPlayfieldName = EmpyrionExtension.EmpyrionApi?.ClientPlayfield?.Name;
            return state;
        }

        public EmpyrionGameState GetTranslatedGameState()
        {
            switch (EmpyrionExtension.Application?.State ?? GameState.NotRunning)
            {
                case GameState.NotRunning: return EmpyrionGameState.NotRunning;
                case GameState.Loading: return EmpyrionGameState.Loading;
                case GameState.Running: return EmpyrionGameState.Running;
                default: return EmpyrionGameState.NotRunning;
            }
        }

        public EmpyrionApplicationMode GetTranslatedApplicationMode()
        {
            switch (EmpyrionExtension.Application?.Mode ?? ApplicationMode.Client)
            {
                case ApplicationMode.Client: return EmpyrionApplicationMode.Client;
                case ApplicationMode.DedicatedServer: return EmpyrionApplicationMode.DedicatedServer;
                case ApplicationMode.PlayfieldServer: return EmpyrionApplicationMode.PlayfieldServer;
                case ApplicationMode.SinglePlayer: return EmpyrionApplicationMode.SinglePlayer;
                default: return EmpyrionApplicationMode.Client;
            }
        }
    }
}
