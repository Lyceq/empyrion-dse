using DarkCity.Data;
using DarkCity.Network;
using System.Drawing;
using System.Windows.Forms;

namespace DarkCity.Tiles
{
    public partial class PlayfieldMapTile : Tile
    {
        private string playfieldName = null;
        protected PlayfieldMap map = null;

        private string header = null;
        private string footer = null;
        private string message = "Waiting for map data...";
        private bool drawMeridians = true;
        private bool drawGrid = false;


        /// <summary>
        /// Name of the playfield that will be displayed. If set to null then it will track the client playfield.
        /// </summary>
        public string PlayfieldName
        {
            get { return this.playfieldName; }
            set
            {
                this.playfieldName = value?.Trim();
                this.RequestMap();
                this.Map = null;
            }
        }

        protected string TrackedPlayfieldName => this.playfieldName ?? this.GameState?.ClientPlayfieldName;

        public PlayfieldMap Map
        {
            get { return this.map; }
            set
            {
                this.map = value;
                this.header = this.map?.Name;
                this.message = null;
                this.RenderBitmap();
            }
        }

        public PlayfieldMapRender Renderer { get; set; } = new PlayfieldMapRender();

        public PlayfieldMapTile() : base()
        {
            this.InitializeComponent();
        }

        public override void OnPacketReceived(Packet packet)
        {
            base.OnPacketReceived(packet);

            PlayfieldMapPacket mapPacket = packet as PlayfieldMapPacket;
            if (this.TrackedPlayfieldName == mapPacket?.Map?.Name)
                this.Map = mapPacket?.Map;
        }

        private void RequestMap()
        {
            if (!string.IsNullOrWhiteSpace(this.TrackedPlayfieldName))
                this.Network?.Send(new RequestPacket(RequestSpecification.PlayfieldMap, this.TrackedPlayfieldName));
        }

        protected override void OnGameStateChanged()
        {
            base.OnGameStateChanged();
            if (this.playfieldName == null)
                this.RequestMap();
        }

        protected override void OnNetworkChanged()
        {
            base.OnNetworkChanged();
            this.RequestMap();
        }

        protected void RenderBitmap()
        {
            if (this.Map == null)
            {
                this.pbMap.Image = null;
            }
            else
            {
                if (this.Renderer == null) this.Renderer = new PlayfieldMapRender();
                this.Renderer.Map = this.Map;
                Bitmap image = this.Renderer.Render();

                this.pbMap.Image = image;
            }
        }

        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            // Common measurements
            Size size = this.pbMap.ClientSize;
            float halfWidth = size.Width / 2.0f, halfHeight = size.Height / 2.0f;
            Brush blackBrush = new SolidBrush(Color.Black);
            Pen blackPen = new Pen(Color.Black);

            if (this.drawGrid)
            {
                // TODO: Draw grid lines
            }

            if (this.drawMeridians)
            {
                e.Graphics.DrawLine(blackPen, 0, halfHeight, size.Width, halfHeight);
                e.Graphics.DrawLine(blackPen, halfWidth, 0, halfWidth, size.Height);
            }

            if (!string.IsNullOrWhiteSpace(this.header))
            {
                SizeF stringSize = e.Graphics.MeasureString(this.header, this.Font);
                e.Graphics.DrawString(this.header, this.Font, blackBrush, halfWidth - stringSize.Width / 2.0f, 0);
            }

            if (!string.IsNullOrWhiteSpace(this.footer))
            {
                SizeF stringSize = e.Graphics.MeasureString(this.footer, this.Font);
                e.Graphics.DrawString(this.footer, this.Font, blackBrush, halfWidth - stringSize.Width / 2.0f, size.Height - stringSize.Height);
            }

            if (!string.IsNullOrWhiteSpace(this.message))
            {
                SizeF stringSize = e.Graphics.MeasureString(this.message, this.Font);
                e.Graphics.DrawString(this.message, this.Font, blackBrush, halfWidth - stringSize.Width / 2.0f, halfHeight - stringSize.Height / 2.0f);
            }
        }
    }
}
