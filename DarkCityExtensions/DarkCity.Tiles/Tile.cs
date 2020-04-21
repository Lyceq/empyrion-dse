using DarkCity.Network;
using DarkCity.Trackers;
using System.IO;
using System.Windows.Forms;

namespace DarkCity.Tiles
{
    public partial class Tile : UserControl
    {
        private Client network = null;
        private GameStateTracker gameState = null;

        /// <summary>
        /// A DarkCity network connection that the tile can use to interact with the game.
        /// </summary>
        public Client Network
        {
            get { return this.network; }
            set
            {
                if (this.network == value) return;
                if (this.network != null) this.network.PacketReceived -= this.DispatchPacket;
                this.network = value;
                if (this.network != null) this.network.PacketReceived += this.DispatchPacket;
                this.OnNetworkChanged();
            }
        }

        public GameStateTracker GameState
        {
            get => this.gameState;
            set
            {
                if (this.gameState == value) return;
                if (this.gameState != null) this.gameState.Updated += this.OnGameStateChanged;
                this.gameState = value;
                if (this.gameState != null) this.gameState.Updated += this.OnGameStateChanged;
                this.OnGameStateChanged();
            }
        }

        public Tile()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// A network packet has been received
        /// </summary>
        /// <param name="packet"></param>
        public virtual void OnPacketReceived(Packet packet) { }
        protected virtual void OnNetworkChanged() { }
        protected virtual void OnGameStateChanged() { }

        /// <summary>
        /// Saves the state of the tile so that it can exhibit the same behavior next time it is loaded.
        /// </summary>
        /// <param name="writer">The storage medium used to retain state.</param>
        public virtual void SaveState(BinaryWriter writer)
        {

        }

        /// <summary>
        /// Loads the state of the tile so that it can exhibit the same behavior as last time it was saved.
        /// </summary>
        /// <param name="reader">The storage medium used to retain state.</param>
        public virtual void LoadState(BinaryReader reader)
        {

        }

        private void DispatchPacket(Client client, Packet packet)
        {
            this.Invoke((MethodInvoker)(() => {
                this.OnPacketReceived(packet);
            }));
        }

    }
}
