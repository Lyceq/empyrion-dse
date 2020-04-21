using DarkCity.Tiles;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClientCompanion
{
    public partial class TileSelection : Form
    {
        public TileSelection()
        {
            InitializeComponent();
        }

        private readonly Size dragBuffer = new Size(SystemInformation.DragSize.Width / 2, SystemInformation.DragSize.Height / 2);
        private Rectangle dragBounds = Rectangle.Empty;

        private void lvTiles_MouseDown(object sender, MouseEventArgs e)
        {
            this.dragBounds = new Rectangle(e.X - dragBuffer.Width, e.Y - dragBuffer.Height, e.X + dragBuffer.Width, e.Y + dragBuffer.Height);
        }

        private void lvTiles_MouseUp(object sender, MouseEventArgs e)
        {
            this.dragBounds = Rectangle.Empty;
        }

        private void lvTiles_MouseMove(object sender, MouseEventArgs e)
        {
            if ((this.dragBounds != Rectangle.Empty) && !this.dragBounds.Contains(e.X, e.Y))
            {
                this.dragBounds = Rectangle.Empty;
                if (this.lvTiles.SelectedItems.Count < 1) return;
                this.lvTiles.DoDragDrop(this.lvTiles.SelectedItems[0].Text, DragDropEffects.Copy);
            }
        }
    }
}
