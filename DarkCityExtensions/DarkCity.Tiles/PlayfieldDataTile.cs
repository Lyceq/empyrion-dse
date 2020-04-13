using DarkCity.Data;
using DarkCity.Network;
using System;
using System.Collections;
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
    public partial class PlayfieldDataTile : Tile
    {
        /// <summary>
        /// Name of the playfield to be displayed.
        /// </summary>
        public string PlayfieldName { get; set; }

        public PlayfieldDataTile() : base()
        {
            this.InitializeComponent();
        }

        public PlayfieldDataTile(Connection network) : base(network)
        {
            this.InitializeComponent();
        }

        public void UpdatePlayfield(PlayfieldData playfield)
        {
            this.lblName.Text = playfield.Name;
            this.lblPlayfieldType.Text = "Playfield Type: " + playfield.PlayfieldType;
            this.lblPlanetType.Text = "Planet Type: " + playfield.PlanetType;
            this.lblPlanetClass.Text = "Planet Class: " + playfield.PlanetClass;
            this.UpdateList(this.listEntities, playfield.Entities);
            this.UpdateList(this.listPlayers, playfield.Players);
        }

        protected void UpdateList(ListBox dest, IEnumerable source)
        {
            dest.BeginUpdate();
            try
            {
                dest.Items.Clear();
                foreach (object item in source)
                    dest.Items.Add(item);
            }
            finally
            {
                dest.EndUpdate();
            }
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
            else if (packet is PlayfieldDataPacket)
            {
                this.UpdatePlayfield(((PlayfieldDataPacket)packet).Playfield);
            }
        }
    }
}
