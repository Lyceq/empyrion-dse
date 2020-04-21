using DarkCity.Data;
using DarkCity.Network;

namespace DarkCity.Trackers
{
    public class PlayfieldDataTracker : RefreshTracker<RequestPacket>
    {
        public string PlayfieldName
        {
            get => this.RefreshPacket?.Specifier;
            set
            {
                if (value == null)
                    this.RefreshPacket = null;
                else
                    this.RefreshPacket = new RequestPacket(RequestSpecification.PlayfieldData, value);
            }
        }

        public PlayfieldData Data { get; private set; }

        public PlayfieldDataTracker() : base() { }

        public PlayfieldDataTracker(string playfield) : this()
        {
            this.PlayfieldName = playfield;
        }

        protected override void OnPacketReceived(Packet packet)
        {
            PlayfieldDataPacket data = packet as PlayfieldDataPacket;
            if (data?.Playfield?.Name == this.PlayfieldName)
            {
                this.Data = data?.Playfield;
                this.TriggerUpdate();
            }
        }
    }
}
