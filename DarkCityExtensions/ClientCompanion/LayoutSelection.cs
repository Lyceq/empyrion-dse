using DarkCity.Tiles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientCompanion
{
    public partial class LayoutSelection : Form
    {
        public TileLayout Puppet { get; set; }

        public LayoutSelection()
        {
            InitializeComponent();
        }

        public void UseCustomLayout(int columns, int rows, int centerColumns = 0, int centerRows = 0)
        {
            if ((centerColumns == 0) && (centerRows == 0))
            {
                // Equal sized column and row layout.

                // Calculate counts and sizes.
                this.Puppet.ColumnCount = columns;
                this.Puppet.RowCount = rows;
                float width = 100.0f / columns;
                float height = 100.0f / rows;

                // Adjust columns.
                this.Puppet.ColumnStyles.Clear();
                for (int c = 0; c < columns; c++) this.Puppet.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));

                // Adjust rows.
                this.Puppet.RowStyles.Clear();
                for (int r = 0; r < rows; r++) this.Puppet.RowStyles.Add(new RowStyle(SizeType.Percent, height));
            }
            else
            {
                // Equal sized side columns or rows with larger center rows or columns.

                // Calculate counts and sizes.
                int sideColumns = columns;
                int sideRows = rows;

                int totalColumns = sideColumns + centerColumns;
                int totalRows = sideRows + centerRows;
                float centerFactor = 2.0f; // Multiple of the center tile size compared to side tiles.
                float sideColumnWidth = 100.0f / (sideColumns + centerColumns * centerFactor);
                float sideRowHeight = 100.0f / (sideRows + centerRows * centerFactor);

                // Set Column and Row counts.
                this.Puppet.ColumnCount = totalColumns;
                this.Puppet.RowCount = totalRows;

                // Clear styles.
                this.Puppet.ColumnStyles.Clear();
                this.Puppet.RowStyles.Clear();

                // Set style for columns.
                for (int c = 0; c < (int)Math.Ceiling(sideColumns / 2.0); c++) this.Puppet.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, sideColumnWidth));
                for (int c = 0; c < centerColumns; c++) this.Puppet.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, sideColumnWidth * centerFactor));
                for (int c = 0; c < (int)Math.Floor(sideColumns / 2.0); c++) this.Puppet.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, sideColumnWidth));

                // Set style for the rows.
                for (int r = 0; r < (int)Math.Ceiling(sideRows / 2.0); r++) this.Puppet.RowStyles.Add(new RowStyle(SizeType.Percent, sideRowHeight));
                for (int r = 0; r < centerRows; r++) this.Puppet.RowStyles.Add(new RowStyle(SizeType.Percent, sideRowHeight * centerFactor));
                for (int r = 0; r < (int)Math.Floor(sideRows / 2.0); r++) this.Puppet.RowStyles.Add(new RowStyle(SizeType.Percent, sideRowHeight));

                // Place spanning placeholders.
                PlaceholderTile placeholder;
                for (int c = 0; c < centerColumns; c++)
                {
                    placeholder = new PlaceholderTile();
                    this.Puppet.Controls.Add(placeholder, sideColumns + c - 1, 0);
                    this.Puppet.SetRowSpan(placeholder, sideRows);
                }
                for (int r = 0; r < centerRows; r++)
                {
                    placeholder = new PlaceholderTile();
                    this.Puppet.Controls.Add(placeholder, 0, sideRows + r - 1);
                    this.Puppet.SetColumnSpan(placeholder, sideColumns);
                }
            }

            this.Puppet.RefreshPlaceholders();

        }

        private void lvLayouts_ItemActivate(object sender, System.EventArgs e)
        {
            if (this.Puppet == null) return;
            if (this.lvLayouts.SelectedItems.Count <= 0) return;

            ListViewItem layout = this.lvLayouts.SelectedItems[0];
            string layoutName = layout.Text;

            List<Tile> controls = this.Puppet.CollectTiles();
            if ((controls?.Count ?? 0) > 0)
            {
                DialogResult result = MessageBox.Show("This will clear all tiles. Do you want to proceed?", "Clearing Tiles", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }
            this.Puppet.Controls.Clear();

            // No special cases yet.
            //switch (layoutName)
            //{
            //    // Setup special layout cases. Otherwise drop down to automatic layout calculation.

            //}

            string[] portions = layoutName.Split('x');
            if (portions.Length == 2)
            {
                // Equal sized column and row layout.

                // Calculate counts and sizes.
                int columns = int.Parse(portions[0].Trim());
                int rows = int.Parse(portions[1].Trim());

                this.UseCustomLayout(columns, rows);
            }
            else if (portions.Length == 3)
            {
                // Equal sized side columns or rows with larger center rows or columns.

                // Calculate counts and sizes.
                int sideColumns = int.Parse(portions[0].Trim());
                int sideRows = int.Parse(portions[1].Trim());

                string[] centerLayout = portions[2].Trim().Split(' ');
                int centerColumns, centerRows;
                if (centerLayout[1].Trim().ToLower() == "horizontal")
                {
                    centerColumns = 0;
                    centerRows = int.Parse(centerLayout[0].Trim());
                }
                else
                {
                    centerColumns = int.Parse(centerLayout[0].Trim());
                    centerRows = 0;
                }

                this.UseCustomLayout(sideColumns, sideRows, centerColumns, centerRows);
            }
        }
    }
}
