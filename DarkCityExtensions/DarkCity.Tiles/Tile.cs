using DarkCity.Network;
using System.IO;
using System.Windows.Forms;

namespace DarkCity.Tiles
{
    public partial class Tile : UserControl
    {
        /// <summary>
        /// A DarkCity network connection that the tile can use to interact with the game.
        /// </summary>
        public Connection Network
        {
            get { return this.network; }
            set
            {
                if (this.network != null) this.network.PacketReceived -= this.DispatchPacket;
                this.network = value;
                if (this.network != null) this.network.PacketReceived += this.DispatchPacket;
            }
        }
        private Connection network = null;

        public Tile()
        {
            InitializeComponent();
        }

        public Tile(Connection network) : this()
        {
            this.Network = network;
        }

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

        /// <summary>
        /// A network packet has been received
        /// </summary>
        /// <param name="packet"></param>
        public virtual void HandlePacket(Packet packet)
        {

        }

        protected virtual void DispatchPacket(Connection connection, Packet packet)
        {
            this.Invoke((MethodInvoker)(() => {
                this.HandlePacket(packet);
            }));
        }
    }
}
