using DarkCity.Network;

namespace DarkCity.Trackers
{
    public abstract class Tracker
    {
        public event StandardEventHandler Updated;

        private Client network;

        public Client Network
        {
            get => this.network;
            set
            {
                if (this.network == value) return;

                if (this.network != null) { 
                    this.network.PacketReceived -= this.DispatchPacket;
                    this.network.ConnectSuccess -= this.Network_ConnectSuccess;
                }

                this.network = value;

                if (this.network != null)
                {
                    this.network.PacketReceived += this.DispatchPacket;
                    this.network.ConnectSuccess += this.Network_ConnectSuccess;
                }

                this.OnNetworkChanged();
            }
        }

        protected virtual void OnNetworkChanged() { }
        protected virtual void OnPacketReceived(Packet packet) { }

        protected void TriggerUpdate()
        {
            if (this.Updated != null) this.Updated();
        }

        private void DispatchPacket(object client, Packet packet)
        {
            this.OnPacketReceived(packet);
        }

        private void Network_ConnectSuccess(Client sender)
        {
            this.OnNetworkChanged();
        }

    }
}
