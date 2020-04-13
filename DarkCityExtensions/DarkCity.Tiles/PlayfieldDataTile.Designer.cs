namespace DarkCity.Tiles
{
    partial class PlayfieldDataTile
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
            this.lblName = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlayfieldType = new System.Windows.Forms.Label();
            this.lblPlanetType = new System.Windows.Forms.Label();
            this.lblPlanetClass = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblEntities = new System.Windows.Forms.Label();
            this.listPlayers = new System.Windows.Forms.ListBox();
            this.listEntities = new System.Windows.Forms.ListBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(396, 47);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "<None>";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel
            // 
            this.panel.ColumnCount = 2;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel.Controls.Add(this.lblPlayfieldType, 0, 0);
            this.panel.Controls.Add(this.lblPlanetType, 0, 1);
            this.panel.Controls.Add(this.lblPlanetClass, 0, 2);
            this.panel.Controls.Add(this.lblEntities, 1, 3);
            this.panel.Controls.Add(this.lblPlayers, 0, 3);
            this.panel.Controls.Add(this.listPlayers, 0, 4);
            this.panel.Controls.Add(this.listEntities, 1, 4);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 47);
            this.panel.Name = "panel";
            this.panel.RowCount = 5;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel.Size = new System.Drawing.Size(396, 257);
            this.panel.TabIndex = 1;
            // 
            // lblPlayfieldType
            // 
            this.lblPlayfieldType.AutoSize = true;
            this.panel.SetColumnSpan(this.lblPlayfieldType, 2);
            this.lblPlayfieldType.Location = new System.Drawing.Point(3, 3);
            this.lblPlayfieldType.Margin = new System.Windows.Forms.Padding(3);
            this.lblPlayfieldType.Name = "lblPlayfieldType";
            this.lblPlayfieldType.Size = new System.Drawing.Size(76, 13);
            this.lblPlayfieldType.TabIndex = 0;
            this.lblPlayfieldType.Text = "Playfield Type:";
            // 
            // lblPlanetType
            // 
            this.lblPlanetType.AutoSize = true;
            this.panel.SetColumnSpan(this.lblPlanetType, 2);
            this.lblPlanetType.Location = new System.Drawing.Point(3, 22);
            this.lblPlanetType.Margin = new System.Windows.Forms.Padding(3);
            this.lblPlanetType.Name = "lblPlanetType";
            this.lblPlanetType.Size = new System.Drawing.Size(67, 13);
            this.lblPlanetType.TabIndex = 1;
            this.lblPlanetType.Text = "Planet Type:";
            // 
            // lblPlanetClass
            // 
            this.lblPlanetClass.AutoSize = true;
            this.panel.SetColumnSpan(this.lblPlanetClass, 2);
            this.lblPlanetClass.Location = new System.Drawing.Point(3, 41);
            this.lblPlanetClass.Margin = new System.Windows.Forms.Padding(3);
            this.lblPlanetClass.Name = "lblPlanetClass";
            this.lblPlanetClass.Size = new System.Drawing.Size(68, 13);
            this.lblPlanetClass.TabIndex = 2;
            this.lblPlanetClass.Text = "Planet Class:";
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlayers.Location = new System.Drawing.Point(3, 60);
            this.lblPlayers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(192, 13);
            this.lblPlayers.TabIndex = 3;
            this.lblPlayers.Text = "Players";
            this.lblPlayers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblEntities
            // 
            this.lblEntities.AutoSize = true;
            this.lblEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEntities.Location = new System.Drawing.Point(201, 60);
            this.lblEntities.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblEntities.Name = "lblEntities";
            this.lblEntities.Size = new System.Drawing.Size(192, 13);
            this.lblEntities.TabIndex = 4;
            this.lblEntities.Text = "Entities";
            this.lblEntities.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // listPlayers
            // 
            this.listPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPlayers.FormattingEnabled = true;
            this.listPlayers.Location = new System.Drawing.Point(3, 76);
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(192, 178);
            this.listPlayers.Sorted = true;
            this.listPlayers.TabIndex = 5;
            // 
            // listEntities
            // 
            this.listEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listEntities.FormattingEnabled = true;
            this.listEntities.Location = new System.Drawing.Point(201, 76);
            this.listEntities.Name = "listEntities";
            this.listEntities.Size = new System.Drawing.Size(192, 178);
            this.listEntities.Sorted = true;
            this.listEntities.TabIndex = 6;
            // 
            // PlayfieldTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.lblName);
            this.Name = "PlayfieldTile";
            this.Size = new System.Drawing.Size(396, 304);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.Label lblPlayfieldType;
        private System.Windows.Forms.Label lblPlanetType;
        private System.Windows.Forms.Label lblPlanetClass;
        private System.Windows.Forms.Label lblEntities;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.ListBox listPlayers;
        private System.Windows.Forms.ListBox listEntities;
    }
}
