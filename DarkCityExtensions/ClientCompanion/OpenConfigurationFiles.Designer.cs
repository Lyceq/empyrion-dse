namespace ClientCompanion
{
    partial class OpenConfigurationFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenConfigurationFiles));
            this.label1 = new System.Windows.Forms.Label();
            this.txtExampleFile = new System.Windows.Forms.TextBox();
            this.lblCustomFiles = new System.Windows.Forms.Label();
            this.clbCustomFiles = new System.Windows.Forms.CheckedListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpenExampleFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.openExampleFile = new System.Windows.Forms.OpenFileDialog();
            this.openCustomFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Example File:";
            // 
            // txtExampleFile
            // 
            this.txtExampleFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExampleFile.Location = new System.Drawing.Point(87, 114);
            this.txtExampleFile.Name = "txtExampleFile";
            this.txtExampleFile.Size = new System.Drawing.Size(469, 20);
            this.txtExampleFile.TabIndex = 1;
            // 
            // lblCustomFiles
            // 
            this.lblCustomFiles.AutoSize = true;
            this.lblCustomFiles.Location = new System.Drawing.Point(12, 142);
            this.lblCustomFiles.Name = "lblCustomFiles";
            this.lblCustomFiles.Size = new System.Drawing.Size(66, 13);
            this.lblCustomFiles.TabIndex = 2;
            this.lblCustomFiles.Text = "&Custom Files";
            // 
            // clbCustomFiles
            // 
            this.clbCustomFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCustomFiles.FormattingEnabled = true;
            this.clbCustomFiles.IntegralHeight = false;
            this.clbCustomFiles.Location = new System.Drawing.Point(12, 158);
            this.clbCustomFiles.Name = "clbCustomFiles";
            this.clbCustomFiles.Size = new System.Drawing.Size(538, 122);
            this.clbCustomFiles.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::ClientCompanion.Properties.Resources.Add_16x;
            this.btnAdd.Location = new System.Drawing.Point(556, 158);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 26);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Image = global::ClientCompanion.Properties.Resources.GlyphUp_16x;
            this.btnUp.Location = new System.Drawing.Point(556, 190);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(26, 26);
            this.btnUp.TabIndex = 5;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Image = global::ClientCompanion.Properties.Resources.GlyphDown_16x;
            this.btnDown.Location = new System.Drawing.Point(556, 222);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(26, 26);
            this.btnDown.TabIndex = 6;
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Image = global::ClientCompanion.Properties.Resources.Remove_16x;
            this.btnRemove.Location = new System.Drawing.Point(556, 254);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(26, 26);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(426, 286);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 8;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(507, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOpenExampleFile
            // 
            this.btnOpenExampleFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenExampleFile.Location = new System.Drawing.Point(562, 114);
            this.btnOpenExampleFile.Name = "btnOpenExampleFile";
            this.btnOpenExampleFile.Size = new System.Drawing.Size(20, 20);
            this.btnOpenExampleFile.TabIndex = 10;
            this.btnOpenExampleFile.Text = "…";
            this.btnOpenExampleFile.UseVisualStyleBackColor = true;
            this.btnOpenExampleFile.Click += new System.EventHandler(this.btnOpenExampleFile_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(570, 102);
            this.label2.TabIndex = 11;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // openExampleFile
            // 
            this.openExampleFile.DefaultExt = "ecf";
            this.openExampleFile.FileName = "Example_Config.ecf";
            this.openExampleFile.Filter = "Example Config File|Example_Config.ecf|All Config Files|*.ecf|All Files|*.*";
            this.openExampleFile.InitialDirectory = "%PROGRAMFILES%\\Steam\\SteamApps\\common\\Empyrion - Galactic Survival\\Content\\Config" +
    "uration";
            this.openExampleFile.RestoreDirectory = true;
            this.openExampleFile.ShowReadOnly = true;
            this.openExampleFile.Title = "Open Example Configuration File";
            // 
            // openCustomFile
            // 
            this.openCustomFile.DefaultExt = "ecf";
            this.openCustomFile.FileName = "Config.ecf";
            this.openCustomFile.Filter = "All Config Files|*.ecf|All Files|*.*";
            this.openCustomFile.InitialDirectory = "%PROGRAMFILES%\\Steam\\SteamApps\\common\\Empyrion - Galactic Survival\\Content\\Config" +
    "uration";
            this.openCustomFile.Multiselect = true;
            this.openCustomFile.RestoreDirectory = true;
            this.openCustomFile.ShowReadOnly = true;
            this.openCustomFile.Title = "Open Custom Configuration File";
            // 
            // OpenConfigurationFiles
            // 
            this.AcceptButton = this.btnImport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 321);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenExampleFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.clbCustomFiles);
            this.Controls.Add(this.lblCustomFiles);
            this.Controls.Add(this.txtExampleFile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenConfigurationFiles";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Configuration Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExampleFile;
        private System.Windows.Forms.Label lblCustomFiles;
        private System.Windows.Forms.CheckedListBox clbCustomFiles;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOpenExampleFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openExampleFile;
        private System.Windows.Forms.OpenFileDialog openCustomFile;
    }
}