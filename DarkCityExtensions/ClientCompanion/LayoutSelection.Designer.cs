namespace ClientCompanion
{
    partial class LayoutSelection
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("1 x 1", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("1 x 2", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("1 x 2 x 1 Horizontal", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("2 x 1", 3);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("2 x 1 x 1 Vertical", 4);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("2 x 2", 5);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("2 x 2 x 1 Horizontal", 6);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("2 x 2 x 1 Vertical", 7);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("2 x 3 x 1 Vertical", 8);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("3 x 2 x 1 Horizontal", 9);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("3 x 3", 10);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutSelection));
            this.lvLayouts = new System.Windows.Forms.ListView();
            this.imagesLayouts = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvLayouts
            // 
            this.lvLayouts.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvLayouts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLayouts.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lvLayouts.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11});
            this.lvLayouts.LargeImageList = this.imagesLayouts;
            this.lvLayouts.Location = new System.Drawing.Point(0, 0);
            this.lvLayouts.MultiSelect = false;
            this.lvLayouts.Name = "lvLayouts";
            this.lvLayouts.Size = new System.Drawing.Size(191, 468);
            this.lvLayouts.TabIndex = 0;
            this.lvLayouts.UseCompatibleStateImageBehavior = false;
            this.lvLayouts.ItemActivate += new System.EventHandler(this.lvLayouts_ItemActivate);
            // 
            // imagesLayouts
            // 
            this.imagesLayouts.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesLayouts.ImageStream")));
            this.imagesLayouts.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesLayouts.Images.SetKeyName(0, "1x1");
            this.imagesLayouts.Images.SetKeyName(1, "1x2");
            this.imagesLayouts.Images.SetKeyName(2, "1x2x1h");
            this.imagesLayouts.Images.SetKeyName(3, "2x1");
            this.imagesLayouts.Images.SetKeyName(4, "2x1x1v");
            this.imagesLayouts.Images.SetKeyName(5, "2x2");
            this.imagesLayouts.Images.SetKeyName(6, "2x2x1h");
            this.imagesLayouts.Images.SetKeyName(7, "2x2x1v");
            this.imagesLayouts.Images.SetKeyName(8, "2x3x1v");
            this.imagesLayouts.Images.SetKeyName(9, "3x2x1h");
            this.imagesLayouts.Images.SetKeyName(10, "3x3");
            // 
            // LayoutSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 468);
            this.Controls.Add(this.lvLayouts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LayoutSelection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Layouts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLayouts;
        private System.Windows.Forms.ImageList imagesLayouts;
    }
}