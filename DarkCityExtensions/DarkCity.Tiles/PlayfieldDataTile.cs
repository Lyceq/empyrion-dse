using DarkCity.Trackers;
using System.Collections;
using System.Windows.Forms;

namespace DarkCity.Tiles
{
    public partial class PlayfieldDataTile : Tile
    {
        private string playfieldName = null;
        private PlayfieldDataTracker tracker = new PlayfieldDataTracker();

        /// <summary>
        /// Name of the playfield to be displayed.
        /// </summary>
        public string PlayfieldName
        {
            get => this.playfieldName;
            set
            {
                this.playfieldName = value?.Trim();
                this.tracker.PlayfieldName = this.TrackedPlayfieldName;
                this.tracker.RefreshOnce();
            }
        }

        protected string TrackedPlayfieldName => this.playfieldName ?? this.GameState?.ClientPlayfieldName;

        public PlayfieldDataTile() : base()
        {
            this.InitializeComponent();
            this.tracker.Updated += this.UpdatePlayfield;
        }

        protected override void OnNetworkChanged()
        {
            base.OnNetworkChanged();
            this.tracker.Network = this.Network;
            this.tracker.RefreshOnce();
        }

        protected override void OnGameStateChanged()
        {
            base.OnGameStateChanged();
            if (this.playfieldName == null)
            {
                this.tracker.PlayfieldName = this.TrackedPlayfieldName;
                this.tracker.RefreshOnce();
            }
        }

        private void UpdatePlayfield()
        {
            this.Invoke((MethodInvoker)(() =>
            {
                this.lblName.Text = this.tracker.Data.Name;
                this.lblPlayfieldType.Text = "Playfield Type: " + this.tracker.Data.PlayfieldType;
                this.lblPlanetType.Text = "Planet Type: " + this.tracker.Data.PlanetType;
                this.lblPlanetClass.Text = "Planet Class: " + this.tracker.Data.PlanetClass;
                this.UpdateList(this.listEntities, this.tracker.Data.Entities);
                this.UpdateList(this.listPlayers, this.tracker.Data.Players);
            }));
        }

        private void UpdateList(ListBox dest, IEnumerable source)
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
    }
}
