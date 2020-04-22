namespace ClientCompanion
{
    partial class TileSelection
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileSelection));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Playfield Map", "playfield");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Playfield Data", "placeholder");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Configuration", "placeholder");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Localization", "placeholder");
            this.imagesTiles = new System.Windows.Forms.ImageList(this.components);
            this.lvTiles = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // imagesTiles
            // 
            this.imagesTiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesTiles.ImageStream")));
            this.imagesTiles.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesTiles.Images.SetKeyName(0, "playfield");
            this.imagesTiles.Images.SetKeyName(1, "placeholder");
            // 
            // lvTiles
            // 
            this.lvTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewItem1.ToolTipText = "Displays a map of the selected playfield. Defaults to the client playfield.";
            listViewItem2.ToolTipText = "Displays data regarding the selected playfield. Defaults to the client playfield." +
    "";
            listViewItem3.ToolTipText = "Displays Empyrion configuration data.";
            listViewItem4.ToolTipText = "Displays Empyrion localization data.";
            this.lvTiles.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.lvTiles.LargeImageList = this.imagesTiles;
            this.lvTiles.Location = new System.Drawing.Point(0, 0);
            this.lvTiles.MultiSelect = false;
            this.lvTiles.Name = "lvTiles";
            this.lvTiles.ShowItemToolTips = true;
            this.lvTiles.Size = new System.Drawing.Size(190, 450);
            this.lvTiles.TabIndex = 0;
            this.lvTiles.UseCompatibleStateImageBehavior = false;
            this.lvTiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvTiles_MouseDown);
            this.lvTiles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvTiles_MouseMove);
            this.lvTiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvTiles_MouseUp);
            // 
            // TileSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 450);
            this.Controls.Add(this.lvTiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "TileSelection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tiles";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imagesTiles;
        private System.Windows.Forms.ListView lvTiles;
    }
}