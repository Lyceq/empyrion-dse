using DarkCity.Data;
using DarkCity.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkCity.Tiles
{
    public partial class PlayfieldMapTile : Tile
    {
        /// <summary>
        /// Name of the playfield that will be displayed.
        /// </summary>
        public string PlayfieldName
        {
            get { return this.playfieldName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.playfieldName = null;
                }
                else
                {
                    this.playfieldName = value.Trim();
                    this.Network?.Send(new RequestPacket(RequestPacket.RequestSpecification.PlayfieldMap, this.playfieldName));
                }
                this.lblPlayfieldName.Text = this.playfieldName;
                this.Map = null;
            }
        }
        private string playfieldName = null;

        protected PlayfieldMap map = null;
        public PlayfieldMap Map
        {
            get { return this.map; }
            set
            {
                this.map = value;
                this.RenderBitmap();
            }
        }

        public PlayfieldMapRender Renderer { get; set; } = new PlayfieldMapRender();

        public PlayfieldMapTile() : base()
        {
            this.InitializeComponent();
        }

        public PlayfieldMapTile(Connection network) : base(network)
        {
            this.InitializeComponent();
        }

        public override void HandlePacket(Packet packet)
        {
            base.HandlePacket(packet);

            if (packet is RequestPacket)
            {
                RequestPacket request = (RequestPacket)packet;
                if (request.Specification == RequestPacket.RequestSpecification.ClientPlayfieldName)
                    this.PlayfieldName = request.Specifier;
            }
            else if (packet is PlayfieldMapPacket)
            {
                this.Map = ((PlayfieldMapPacket)packet).Map;
            }
        }

        protected void RenderBitmap()
        {
            if (this.Map == null)
            {
                this.pbMap.Image = null;
                this.lblWaiting.Visible = true;
            }
            else
            {
                if (this.Renderer == null) this.Renderer = new PlayfieldMapRender();
                this.Renderer.Map = this.Map;
                Bitmap image = this.Renderer.Render();

                //int width = this.map.MapWidth, height = this.map.MapHeight, color;
                //float height2color = this.map.Resolution / 1000 * 255;
                //Bitmap image = new Bitmap(width, height);
                //for (int z = 0; z < height; z++)
                //{
                //    for (int x = 0; x < width; x++)
                //    {
                //        color = (int)(this.map[x, z] * height2color);
                //        image.SetPixel(x, z, Color.FromArgb(color, color, color));
                //    }
                //}

                this.pbMap.Image = image;
                this.lblWaiting.Visible = false;
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //    int wxc = this.Width / 2, wyc = this.Height / 2; // Window centers
        //    if (this.MapImage == null)
        //    {
        //        string message = "Waiting for map data.";
        //        SizeF size = e.Graphics.MeasureString(message, this.Font);
        //        e.Graphics.DrawString(message, this.Font, new SolidBrush(this.ForeColor), wxc - size.Width / 2, wyc - size.Height / 2);
        //    }
        //    else
        //    {
        //        int mxc = this.MapImage.Width / 2, myc = this.MapImage.Height / 2; // Map centers
        //        RectangleF source = new RectangleF(0.0f, 0.0f, this.MapImage.Width, this.MapImage.Height);
        //        RectangleF dest = new RectangleF(wxc - (mxc / 2 * this.MapScale), wyc - (myc / 2 * this.MapScale), wxc + mxc * this.MapScale, wyc + myc * this.MapScale);
        //        e.Graphics.DrawImage(this.MapImage, source, dest, GraphicsUnit.Pixel);
        //    }
        //}
    }
}
