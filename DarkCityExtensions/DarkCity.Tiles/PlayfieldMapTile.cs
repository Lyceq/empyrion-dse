using DarkCity.Data;
using DarkCity.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DarkCity.Tiles
{
    public partial class PlayfieldMapTile : Tile
    {
        public enum DataField
        {
            None,
            PlayfieldName
        }

        private string playfieldName = null;
        protected PlayfieldMap map = null;

        private DataField header = DataField.None;
        private DataField footer = DataField.None;
        private bool meridians = false;
        private bool latLongLines = false;
        private bool pois = false;
        private bool players = false;

        private List<Marker> poiMarkers = new List<Marker>();
        private List<Marker> playerMarkers = new List<Marker>();


        #region Feature Properties

        public DataField Header
        {
            get => this.header;
            set
            {
                this.header = value;
                this.tileContextHeaderNone.Checked = (value == DataField.None);
                this.tileContextHeaderPlayfieldName.Checked = (value == DataField.PlayfieldName);
                this.pbMap.Refresh();
            }
        }

        public DataField Footer
        {
            get => this.footer;
            set
            {
                this.footer = value;
                this.tileContextFooterNone.Checked = (value == DataField.None);
                this.tileContextFooterPlayfieldName.Checked = (value == DataField.PlayfieldName);
                this.pbMap.Refresh();
            }
        }

        public bool Meridians
        {
            get => this.meridians;
            set
            {
                this.meridians = value;
                this.tileContextFeaturesMeridians.Checked = value;
                this.pbMap.Refresh();
            }
        }

        public bool LatLongLines
        {
            get => this.latLongLines;
            set
            {
                this.latLongLines = value;
                this.tileContextFeaturesLatLongLines.Checked = value;
                this.pbMap.Refresh();
            }
        }

        public bool Pois
        {
            get => this.pois;
            set
            {
                this.pois = value;
                this.tileContextFeaturesPois.Checked = value;
                this.pbMap.Refresh();
            }
        }

        public bool Players
        {
            get => this.players;
            set
            {
                this.players = value;
                this.tileContextFeaturesPlayers.Checked = value;
                this.pbMap.Refresh();
            }
        }

        #endregion

        private string message = "Waiting for map data...";


        /// <summary>
        /// Name of the playfield that will be displayed. If set to null then it will track the client playfield.
        /// </summary>
        public string PlayfieldName
        {
            get { return this.playfieldName; }
            set
            {
                this.playfieldName = value?.Trim();
                this.ClearMarkers();
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
                this.message = (value == null ? "Waiting for map data..." : null);
                this.RenderBitmap();
            }
        }

        public PlayfieldMapRender Renderer { get; set; } = new PlayfieldMapRender();

        public PlayfieldMapTile() : base()
        {
            this.InitializeComponent();
            this.Header = DataField.None;
            this.Footer = DataField.None;

            this.tileContextMenu.Items.AddRange(new ToolStripItem[]
            {
                this.tileContextSeperator1,
                this.tileContextHeader,
                this.tileContextFooter,
                this.tileContextFeatures
            });
        }

        public void ClearMarkers()
        {
            this.poiMarkers.Clear();
            this.playerMarkers.Clear();
        }

        public string GetDataField(DataField field)
        {
            switch (field)
            {
                case DataField.None: return null;
                case DataField.PlayfieldName: return this.TrackedPlayfieldName;
                default: return null;
            }
        }

        public override void OnPacketReceived(Packet packet)
        {
            base.OnPacketReceived(packet);

            if (packet is PlayfieldMapPacket)
            {
                PlayfieldMapPacket mapPacket = packet as PlayfieldMapPacket;
                if (this.TrackedPlayfieldName == mapPacket?.Map?.Name)
                    this.Map = mapPacket?.Map;
            } else if (packet is PlayfieldDataPacket)
            {
                PlayfieldDataPacket mapData = packet as PlayfieldDataPacket;
                this.ClearMarkers();
                foreach (EntityHeader entity in mapData.Playfield.Entities)
                    this.poiMarkers.Add(new Marker(entity));
                foreach (EntityHeader player in mapData.Playfield.Players)
                    this.playerMarkers.Add(new Marker(player));
            }
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

            if (this.Map != null)
            {
                if (this.LatLongLines)
                {
                    // TODO: Draw grid lines
                }

                if (this.Meridians)
                {
                    e.Graphics.DrawLine(blackPen, 0, halfHeight, size.Width, halfHeight);
                    e.Graphics.DrawLine(blackPen, halfWidth, 0, halfWidth, size.Height);
                }

                Point offset = new Point((int)halfWidth, (int)halfHeight);
                float mapAspect = (float)this.Map.MapWidth / (float)this.Map.MapHeight, pbAspect = (float)size.Width / (float)size.Height;
                float scale;
                if (mapAspect > pbAspect)
                    // Scale based on width.
                    scale = (float)size.Width / (float)this.Map.MapWidth;
                else
                    // Scale based on height.
                    scale = (float)size.Height / (float)this.map.MapHeight;
                scale *= 1.0f / this.Map.Resolution;

                if (this.Pois)
                {
                    foreach (Marker marker in this.poiMarkers)
                        marker.Draw(e.Graphics, offset, scale);
                }

                if (this.Players)
                {
                    foreach (Marker marker in this.playerMarkers)
                        marker.Draw(e.Graphics, offset, scale);
                }
            }

            string header = this.GetDataField(this.Header);
            if (!string.IsNullOrWhiteSpace(header))
            {
                SizeF stringSize = e.Graphics.MeasureString(header, this.Font);
                e.Graphics.DrawString(header, this.Font, blackBrush, halfWidth - stringSize.Width / 2.0f, 0);
            }

            string footer = this.GetDataField(this.Footer);
            if (!string.IsNullOrWhiteSpace(footer))
            {
                SizeF stringSize = e.Graphics.MeasureString(footer, this.Font);
                e.Graphics.DrawString(footer, this.Font, blackBrush, halfWidth - stringSize.Width / 2.0f, size.Height - stringSize.Height);
            }

            if (!string.IsNullOrWhiteSpace(this.message))
            {
                SizeF stringSize = e.Graphics.MeasureString(this.message, this.Font);
                e.Graphics.DrawString(this.message, this.Font, blackBrush, halfWidth - stringSize.Width / 2.0f, halfHeight - stringSize.Height / 2.0f);
            }
        }

        #region Header Event Handlers

        private void tileContextHeaderNone_Click(object sender, EventArgs e)
        {
            this.Header = DataField.None;
        }

        private void tileContextHeaderPlayfieldName_Click(object sender, EventArgs e)
        {
            this.Header = DataField.PlayfieldName;
        }

        #endregion

        #region Footer Event Handlers

        private void tileContextFooterNone_Click(object sender, EventArgs e)
        {
            this.Footer = DataField.None;
        }

        private void tileContextFooterPlayfieldName_Click(object sender, EventArgs e)
        {
            this.Footer = DataField.PlayfieldName;
        }

        #endregion

        #region Feature Event Handlers

        private void tileContextFeaturesMerdians_Click(object sender, EventArgs e)
        {
            this.Meridians = !this.Meridians;
        }

        private void tileContextFeaturesLatLongLines_Click(object sender, EventArgs e)
        {
            this.LatLongLines = !this.LatLongLines;
        }

        private void tileContextFeaturesPois_Click(object sender, EventArgs e)
        {
            this.Pois = !this.Pois;
        }

        private void tileContextFeaturesPlayers_Click(object sender, EventArgs e)
        {
            this.Players = !this.Players;
        }

        #endregion

    }
}
