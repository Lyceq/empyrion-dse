namespace DarkCity.Testing.Tiles
{
    partial class PlayfieldSimulationTile
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
            this.panelPlayfieldInfo = new System.Windows.Forms.GroupBox();
            this.pbTerrain = new System.Windows.Forms.PictureBox();
            this.lblPlayfield = new System.Windows.Forms.Label();
            this.cboPlayfield = new System.Windows.Forms.ComboBox();
            this.lblPlayfieldType = new System.Windows.Forms.Label();
            this.lblPlanetType = new System.Windows.Forms.Label();
            this.txtPlayfieldType = new System.Windows.Forms.TextBox();
            this.lblPlanetClass = new System.Windows.Forms.Label();
            this.txtPlanetType = new System.Windows.Forms.TextBox();
            this.txtPlanetClass = new System.Windows.Forms.TextBox();
            this.nudTerrainSeed = new System.Windows.Forms.NumericUpDown();
            this.lblTerrainSeed = new System.Windows.Forms.Label();
            this.btnGenerateTerrain = new System.Windows.Forms.Button();
            this.lblSizeClass = new System.Windows.Forms.Label();
            this.nudSizeClass = new System.Windows.Forms.NumericUpDown();
            this.panelPlayfieldInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTerrain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTerrainSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeClass)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlayfieldInfo
            // 
            this.panelPlayfieldInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelPlayfieldInfo.Controls.Add(this.nudSizeClass);
            this.panelPlayfieldInfo.Controls.Add(this.lblSizeClass);
            this.panelPlayfieldInfo.Controls.Add(this.btnGenerateTerrain);
            this.panelPlayfieldInfo.Controls.Add(this.lblTerrainSeed);
            this.panelPlayfieldInfo.Controls.Add(this.nudTerrainSeed);
            this.panelPlayfieldInfo.Controls.Add(this.txtPlanetClass);
            this.panelPlayfieldInfo.Controls.Add(this.txtPlanetType);
            this.panelPlayfieldInfo.Controls.Add(this.lblPlanetClass);
            this.panelPlayfieldInfo.Controls.Add(this.txtPlayfieldType);
            this.panelPlayfieldInfo.Controls.Add(this.lblPlanetType);
            this.panelPlayfieldInfo.Controls.Add(this.lblPlayfieldType);
            this.panelPlayfieldInfo.Controls.Add(this.cboPlayfield);
            this.panelPlayfieldInfo.Controls.Add(this.lblPlayfield);
            this.panelPlayfieldInfo.Location = new System.Drawing.Point(3, 3);
            this.panelPlayfieldInfo.Name = "panelPlayfieldInfo";
            this.panelPlayfieldInfo.Size = new System.Drawing.Size(200, 433);
            this.panelPlayfieldInfo.TabIndex = 0;
            this.panelPlayfieldInfo.TabStop = false;
            // 
            // pbTerrain
            // 
            this.pbTerrain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTerrain.Enabled = false;
            this.pbTerrain.Location = new System.Drawing.Point(209, 3);
            this.pbTerrain.Name = "pbTerrain";
            this.pbTerrain.Size = new System.Drawing.Size(472, 433);
            this.pbTerrain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTerrain.TabIndex = 1;
            this.pbTerrain.TabStop = false;
            // 
            // lblPlayfield
            // 
            this.lblPlayfield.AutoSize = true;
            this.lblPlayfield.Location = new System.Drawing.Point(7, 20);
            this.lblPlayfield.Name = "lblPlayfield";
            this.lblPlayfield.Size = new System.Drawing.Size(46, 13);
            this.lblPlayfield.TabIndex = 0;
            this.lblPlayfield.Text = "&Playfield";
            // 
            // cboPlayfield
            // 
            this.cboPlayfield.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayfield.FormattingEnabled = true;
            this.cboPlayfield.Location = new System.Drawing.Point(7, 37);
            this.cboPlayfield.Name = "cboPlayfield";
            this.cboPlayfield.Size = new System.Drawing.Size(187, 21);
            this.cboPlayfield.Sorted = true;
            this.cboPlayfield.TabIndex = 1;
            this.cboPlayfield.SelectedIndexChanged += new System.EventHandler(this.cboPlayfield_SelectedIndexChanged);
            // 
            // lblPlayfieldType
            // 
            this.lblPlayfieldType.AutoSize = true;
            this.lblPlayfieldType.Location = new System.Drawing.Point(6, 61);
            this.lblPlayfieldType.Name = "lblPlayfieldType";
            this.lblPlayfieldType.Size = new System.Drawing.Size(73, 13);
            this.lblPlayfieldType.TabIndex = 2;
            this.lblPlayfieldType.Text = "Playfield Type";
            // 
            // lblPlanetType
            // 
            this.lblPlanetType.AutoSize = true;
            this.lblPlanetType.Location = new System.Drawing.Point(6, 101);
            this.lblPlanetType.Name = "lblPlanetType";
            this.lblPlanetType.Size = new System.Drawing.Size(64, 13);
            this.lblPlanetType.TabIndex = 4;
            this.lblPlanetType.Text = "Planet Type";
            // 
            // txtPlayfieldType
            // 
            this.txtPlayfieldType.Location = new System.Drawing.Point(7, 78);
            this.txtPlayfieldType.Name = "txtPlayfieldType";
            this.txtPlayfieldType.ReadOnly = true;
            this.txtPlayfieldType.Size = new System.Drawing.Size(187, 20);
            this.txtPlayfieldType.TabIndex = 3;
            // 
            // lblPlanetClass
            // 
            this.lblPlanetClass.AutoSize = true;
            this.lblPlanetClass.Location = new System.Drawing.Point(6, 141);
            this.lblPlanetClass.Name = "lblPlanetClass";
            this.lblPlanetClass.Size = new System.Drawing.Size(65, 13);
            this.lblPlanetClass.TabIndex = 6;
            this.lblPlanetClass.Text = "Planet Class";
            // 
            // txtPlanetType
            // 
            this.txtPlanetType.Location = new System.Drawing.Point(7, 118);
            this.txtPlanetType.Name = "txtPlanetType";
            this.txtPlanetType.ReadOnly = true;
            this.txtPlanetType.Size = new System.Drawing.Size(187, 20);
            this.txtPlanetType.TabIndex = 5;
            // 
            // txtPlanetClass
            // 
            this.txtPlanetClass.Location = new System.Drawing.Point(7, 157);
            this.txtPlanetClass.Name = "txtPlanetClass";
            this.txtPlanetClass.ReadOnly = true;
            this.txtPlanetClass.Size = new System.Drawing.Size(187, 20);
            this.txtPlanetClass.TabIndex = 7;
            // 
            // nudTerrainSeed
            // 
            this.nudTerrainSeed.Location = new System.Drawing.Point(6, 378);
            this.nudTerrainSeed.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudTerrainSeed.Name = "nudTerrainSeed";
            this.nudTerrainSeed.ReadOnly = true;
            this.nudTerrainSeed.Size = new System.Drawing.Size(188, 20);
            this.nudTerrainSeed.TabIndex = 11;
            // 
            // lblTerrainSeed
            // 
            this.lblTerrainSeed.AutoSize = true;
            this.lblTerrainSeed.Location = new System.Drawing.Point(6, 362);
            this.lblTerrainSeed.Name = "lblTerrainSeed";
            this.lblTerrainSeed.Size = new System.Drawing.Size(68, 13);
            this.lblTerrainSeed.TabIndex = 10;
            this.lblTerrainSeed.Text = "Terrain Seed";
            // 
            // btnGenerateTerrain
            // 
            this.btnGenerateTerrain.Enabled = false;
            this.btnGenerateTerrain.Location = new System.Drawing.Point(6, 404);
            this.btnGenerateTerrain.Name = "btnGenerateTerrain";
            this.btnGenerateTerrain.Size = new System.Drawing.Size(188, 23);
            this.btnGenerateTerrain.TabIndex = 12;
            this.btnGenerateTerrain.Text = "Generate Terrain";
            this.btnGenerateTerrain.UseVisualStyleBackColor = true;
            // 
            // lblSizeClass
            // 
            this.lblSizeClass.AutoSize = true;
            this.lblSizeClass.Location = new System.Drawing.Point(6, 180);
            this.lblSizeClass.Name = "lblSizeClass";
            this.lblSizeClass.Size = new System.Drawing.Size(55, 13);
            this.lblSizeClass.TabIndex = 8;
            this.lblSizeClass.Text = "Size Class";
            // 
            // nudSizeClass
            // 
            this.nudSizeClass.Location = new System.Drawing.Point(6, 196);
            this.nudSizeClass.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSizeClass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSizeClass.Name = "nudSizeClass";
            this.nudSizeClass.ReadOnly = true;
            this.nudSizeClass.Size = new System.Drawing.Size(188, 20);
            this.nudSizeClass.TabIndex = 9;
            this.nudSizeClass.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PlayfieldSimulationTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbTerrain);
            this.Controls.Add(this.panelPlayfieldInfo);
            this.Name = "PlayfieldSimulationTile";
            this.Size = new System.Drawing.Size(684, 439);
            this.panelPlayfieldInfo.ResumeLayout(false);
            this.panelPlayfieldInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTerrain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTerrainSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeClass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox panelPlayfieldInfo;
        private System.Windows.Forms.PictureBox pbTerrain;
        private System.Windows.Forms.Button btnGenerateTerrain;
        private System.Windows.Forms.Label lblTerrainSeed;
        private System.Windows.Forms.NumericUpDown nudTerrainSeed;
        private System.Windows.Forms.TextBox txtPlanetClass;
        private System.Windows.Forms.TextBox txtPlanetType;
        private System.Windows.Forms.Label lblPlanetClass;
        private System.Windows.Forms.TextBox txtPlayfieldType;
        private System.Windows.Forms.Label lblPlanetType;
        private System.Windows.Forms.Label lblPlayfieldType;
        private System.Windows.Forms.ComboBox cboPlayfield;
        private System.Windows.Forms.Label lblPlayfield;
        private System.Windows.Forms.NumericUpDown nudSizeClass;
        private System.Windows.Forms.Label lblSizeClass;
    }
}
