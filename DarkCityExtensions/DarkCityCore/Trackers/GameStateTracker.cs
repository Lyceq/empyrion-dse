using DarkCity.Network;

namespace DarkCity.Trackers
{
    public class GameStateTracker : Tracker
    {
        public EmpyrionGameState State { get; private set; }

        public EmpyrionApplicationMode Mode { get; private set; }

        public int LocalPlayerEntityId { get; private set; }

        public string LocalPlayerName { get; private set; }

        public string ClientPlayfieldName { get; private set; }

        public GameStateTracker() { }

        protected override void OnPacketReceived(Packet packet)
        {
            base.OnPacketReceived(packet);

            EmpyrionStatePacket newState = packet as EmpyrionStatePacket;
            if (newState == null) return;

            this.State = newState.State;
            this.Mode = newState.Mode;
            this.LocalPlayerName = newState.LocalPlayerName;
            this.ClientPlayfieldName = newState.ClientPlayfieldName;

            this.TriggerUpdate();
        }

        protected override void OnNetworkChanged()
        {
            base.OnNetworkChanged();
            this.RequestState();
        }

        private void RequestState()
        {
            this.Network?.Send(new RequestPacket(RequestSpecification.GameState, null));
        }
    }
}
