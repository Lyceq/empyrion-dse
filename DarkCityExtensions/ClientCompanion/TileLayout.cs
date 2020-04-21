using DarkCity.Tiles;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientCompanion
{
    public partial class TileLayout : TableLayoutPanel
    {
        public TileLayout()
        {
            InitializeComponent();
            this.RefreshPlaceholders();
        }

        public List<Tile> CollectTiles()
        {
            List<Tile> results = new List<Tile>();
            foreach (Control control in this.Controls)
                if (control is Tile)
                    results.Add((Tile)control);
            return results;
        }

        public void AddTile(Tile tile, TableLayoutPanelCellPosition cell)
        {
            this.AddTile(tile, cell.Column, cell.Row);
        }

        public void AddTile(Tile tile, int column, int row)
        {
            if (tile == null) return;

            tile.Network = Program.Network;
            tile.GameState = Program.GameState;

            Control target = this.GetControlFromPosition(column, row);
            if (target == null)
            {
                this.Controls.Add(tile, column, row);
            }
            else
            {
                int columnSpan = this.GetColumnSpan(target);
                int rowSpan = this.GetRowSpan(target);
                this.Controls.Remove(target);
                this.Controls.Add(tile, column, row);
                this.SetColumnSpan(tile, columnSpan);
                this.SetRowSpan(tile, rowSpan);
            }
        }

        public void RemoveTile(Tile tile)
        {
            if (!this.Controls.Contains(tile)) return;

            PlaceholderTile placeholder = new PlaceholderTile();
            TableLayoutPanelCellPosition position = this.GetCellPosition(tile);
            int colSpan = this.GetColumnSpan(tile);
            int rowSpan = this.GetRowSpan(tile);
            this.Controls.Remove(tile);
            this.Controls.Add(placeholder, position.Column, position.Row);
            this.SetColumnSpan(tile, colSpan);
            this.SetRowSpan(tile, rowSpan);
        }

        public void RefreshPlaceholders()
        {
            // Remove controls that are not in a cell.
            foreach (Control control in this.Controls)
            {
                TableLayoutPanelCellPosition position = this.GetPositionFromControl(control);
                if ((position.Column < 0) || (position.Column >= this.ColumnCount) ||
                    (position.Row < 0) || (position.Row >= this.RowCount))
                    this.Controls.Remove(control);
            }

            // Insert placeholders to empty cells.
            for (int row = 0; row < this.RowCount; row++)
                for (int column = 0; column < this.ColumnCount; column++)
                    if (this.GetControlFromPosition(column, row) == null)
                        this.Controls.Add(new PlaceholderTile(), column, row);
        }
    }
}
