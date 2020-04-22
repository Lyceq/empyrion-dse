namespace DarkCity.Tiles
{
    partial class Tile
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tileRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileContextMenu
            // 
            this.tileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileRemove});
            this.tileContextMenu.Name = "tileContextMenu";
            this.tileContextMenu.Size = new System.Drawing.Size(114, 26);
            // 
            // tileRemove
            // 
            this.tileRemove.Name = "tileRemove";
            this.tileRemove.Size = new System.Drawing.Size(180, 22);
            this.tileRemove.Text = "&Remove";
            this.tileRemove.Click += new System.EventHandler(this.tileRemove_Click);
            // 
            // Tile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.tileContextMenu;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Tile";
            this.tileContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem tileRemove;
        protected System.Windows.Forms.ContextMenuStrip tileContextMenu;
    }
}
