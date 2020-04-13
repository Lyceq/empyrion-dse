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
            this.lblPlayfieldName = new System.Windows.Forms.Label();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.lblWaiting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayfieldName
            // 
            this.lblPlayfieldName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayfieldName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlayfieldName.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayfieldName.Location = new System.Drawing.Point(0, 0);
            this.lblPlayfieldName.Name = "lblPlayfieldName";
            this.lblPlayfieldName.Size = new System.Drawing.Size(707, 45);
            this.lblPlayfieldName.TabIndex = 0;
            this.lblPlayfieldName.Text = "Playfield not selected";
            this.lblPlayfieldName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbMap
            // 
            this.pbMap.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMap.Location = new System.Drawing.Point(0, 0);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(707, 453);
            this.pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMap.TabIndex = 1;
            this.pbMap.TabStop = false;
            // 
            // lblWaiting
            // 
            this.lblWaiting.BackColor = System.Drawing.Color.Transparent;
            this.lblWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiting.Location = new System.Drawing.Point(0, 0);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(707, 453);
            this.lblWaiting.TabIndex = 2;
            this.lblWaiting.Text = "Waiting for map data...";
            this.lblWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayfieldMapTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPlayfieldName);
            this.Controls.Add(this.lblWaiting);
            this.Controls.Add(this.pbMap);
            this.Name = "PlayfieldMapTile";
            this.Size = new System.Drawing.Size(707, 453);
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPlayfieldName;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.Label lblWaiting;
    }
}
