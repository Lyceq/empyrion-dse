namespace DarkCity.Tiles
{
    partial class PlayfieldMapTile
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
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.tileContextSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tileContextHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextHeaderNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextHeaderPlayfieldName = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextFooter = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextFooterNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextFooterPlayfieldName = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextFeatures = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextFeaturesMeridians = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextFeaturesLatLongLines = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextFeaturesPois = new System.Windows.Forms.ToolStripMenuItem();
            this.tileContextFeaturesPlayers = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMap
            // 
            this.pbMap.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMap.Location = new System.Drawing.Point(0, 0);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(1297, 528);
            this.pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMap.TabIndex = 1;
            this.pbMap.TabStop = false;
            this.pbMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMap_Paint);
            // 
            // tileContextSeperator1
            // 
            this.tileContextSeperator1.Name = "tileContextSeperator1";
            this.tileContextSeperator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tileContextHeader
            // 
            this.tileContextHeader.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileContextHeaderNone,
            this.tileContextHeaderPlayfieldName});
            this.tileContextHeader.Name = "tileContextHeader";
            this.tileContextHeader.Size = new System.Drawing.Size(180, 22);
            this.tileContextHeader.Text = "&Header";
            // 
            // tileContextHeaderNone
            // 
            this.tileContextHeaderNone.Name = "tileContextHeaderNone";
            this.tileContextHeaderNone.Size = new System.Drawing.Size(144, 22);
            this.tileContextHeaderNone.Text = "&None";
            this.tileContextHeaderNone.Click += new System.EventHandler(this.tileContextHeaderNone_Click);
            // 
            // tileContextHeaderPlayfieldName
            // 
            this.tileContextHeaderPlayfieldName.Name = "tileContextHeaderPlayfieldName";
            this.tileContextHeaderPlayfieldName.Size = new System.Drawing.Size(144, 22);
            this.tileContextHeaderPlayfieldName.Text = "&Playfield Name";
            this.tileContextHeaderPlayfieldName.Click += new System.EventHandler(this.tileContextHeaderPlayfieldName_Click);
            // 
            // tileContextFooter
            // 
            this.tileContextFooter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileContextFooterNone,
            this.tileContextFooterPlayfieldName});
            this.tileContextFooter.Name = "tileContextFooter";
            this.tileContextFooter.Size = new System.Drawing.Size(180, 22);
            this.tileContextFooter.Text = "&Footer";
            // 
            // tileContextFooterNone
            // 
            this.tileContextFooterNone.Name = "tileContextFooterNone";
            this.tileContextFooterNone.Size = new System.Drawing.Size(144, 22);
            this.tileContextFooterNone.Text = "&None";
            this.tileContextFooterNone.Click += new System.EventHandler(this.tileContextFooterNone_Click);
            // 
            // tileContextFooterPlayfieldName
            // 
            this.tileContextFooterPlayfieldName.Name = "tileContextFooterPlayfieldName";
            this.tileContextFooterPlayfieldName.Size = new System.Drawing.Size(144, 22);
            this.tileContextFooterPlayfieldName.Text = "&Playfield Name";
            this.tileContextFooterPlayfieldName.Click += new System.EventHandler(this.tileContextFooterPlayfieldName_Click);
            // 
            // tileContextFeatures
            // 
            this.tileContextFeatures.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileContextFeaturesMeridians,
            this.tileContextFeaturesLatLongLines,
            this.tileContextFeaturesPois,
            this.tileContextFeaturesPlayers});
            this.tileContextFeatures.Name = "tileContextFeatures";
            this.tileContextFeatures.Size = new System.Drawing.Size(180, 22);
            this.tileContextFeatures.Text = "F&eatures";
            // 
            // tileContextFeaturesMeridians
            // 
            this.tileContextFeaturesMeridians.Name = "tileContextFeaturesMeridians";
            this.tileContextFeaturesMeridians.Size = new System.Drawing.Size(143, 22);
            this.tileContextFeaturesMeridians.Text = "&Meridians";
            this.tileContextFeaturesMeridians.Click += new System.EventHandler(this.tileContextFeaturesMerdians_Click);
            // 
            // tileContextFeaturesLatLongLines
            // 
            this.tileContextFeaturesLatLongLines.Name = "tileContextFeaturesLatLongLines";
            this.tileContextFeaturesLatLongLines.Size = new System.Drawing.Size(143, 22);
            this.tileContextFeaturesLatLongLines.Text = "&Lat/Long Lines";
            this.tileContextFeaturesLatLongLines.Click += new System.EventHandler(this.tileContextFeaturesLatLongLines_Click);
            // 
            // tileContextFeaturesPois
            // 
            this.tileContextFeaturesPois.Name = "tileContextFeaturesPois";
            this.tileContextFeaturesPois.Size = new System.Drawing.Size(143, 22);
            this.tileContextFeaturesPois.Text = "PO&Is";
            this.tileContextFeaturesPois.Click += new System.EventHandler(this.tileContextFeaturesPois_Click);
            // 
            // tileContextFeaturesPlayers
            // 
            this.tileContextFeaturesPlayers.Name = "tileContextFeaturesPlayers";
            this.tileContextFeaturesPlayers.Size = new System.Drawing.Size(143, 22);
            this.tileContextFeaturesPlayers.Text = "&Players";
            this.tileContextFeaturesPlayers.Click += new System.EventHandler(this.tileContextFeaturesPlayers_Click);
            // 
            // PlayfieldMapTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbMap);
            this.Name = "PlayfieldMapTile";
            this.Size = new System.Drawing.Size(1297, 528);
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.ToolStripSeparator tileContextSeperator1;
        private System.Windows.Forms.ToolStripMenuItem tileContextHeader;
        private System.Windows.Forms.ToolStripMenuItem tileContextHeaderNone;
        private System.Windows.Forms.ToolStripMenuItem tileContextHeaderPlayfieldName;
        private System.Windows.Forms.ToolStripMenuItem tileContextFooter;
        private System.Windows.Forms.ToolStripMenuItem tileContextFooterNone;
        private System.Windows.Forms.ToolStripMenuItem tileContextFooterPlayfieldName;
        private System.Windows.Forms.ToolStripMenuItem tileContextFeatures;
        private System.Windows.Forms.ToolStripMenuItem tileContextFeaturesMeridians;
        private System.Windows.Forms.ToolStripMenuItem tileContextFeaturesLatLongLines;
        private System.Windows.Forms.ToolStripMenuItem tileContextFeaturesPois;
        private System.Windows.Forms.ToolStripMenuItem tileContextFeaturesPlayers;
    }
}
