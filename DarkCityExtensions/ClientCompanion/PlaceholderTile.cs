using ClientCompanion.Properties;
using DarkCity.Tiles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientCompanion
{
    public partial class PlaceholderTile : UserControl
    {
        private static readonly Dictionary<string, Type> tileTypes = new Dictionary<string, Type>()
        {
            { "Playfield Map", typeof(PlayfieldMapTile) },
            { "Playfield Data", typeof(PlayfieldDataTile) },
            { "Configuration", typeof(ConfigurationTile) }
        };

        public PlaceholderTile()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void PlaceholderTile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                string tileType = e.Data.GetData(typeof(string)) as string;
                if (tileTypes.ContainsKey(tileType))
                {
                    e.Effect = e.AllowedEffect & DragDropEffects.Copy;
                    this.BackgroundImage = Resources.PanelDragDropTarget_16x;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void PlaceholderTile_DragLeave(object sender, System.EventArgs e)
        {
            this.BackgroundImage = null;
        }

        private void PlaceholderTile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                string tileTypeName = e.Data.GetData(typeof(string)) as string;
                if (tileTypes.ContainsKey(tileTypeName))
                {
                    Type tileType = tileTypes[tileTypeName];
                    TileLayout owner = this.Parent as TileLayout;
                    if ((owner != null) && (tileType != null))
                    {
                        Tile newTile = tileType.GetConstructor(new Type[] { }).Invoke(new object[] { }) as Tile;
                        if (newTile != null) owner.AddTile(newTile, owner.GetCellPosition(this));
                    }

                }

                this.BackgroundImage = null;
            }
        }
    }
}
