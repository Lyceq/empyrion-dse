namespace DarkCity.Tiles
{
    partial class ConfigurationTile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationTile));
            this.splitConfiguration = new System.Windows.Forms.SplitContainer();
            this.treeEmpyrionObjects = new System.Windows.Forms.TreeView();
            this.splitObjectViews = new System.Windows.Forms.SplitContainer();
            this.txtRawObject = new System.Windows.Forms.TextBox();
            this.lblObjectRaw = new System.Windows.Forms.Label();
            this.txtResolvedObject = new System.Windows.Forms.TextBox();
            this.lblResolvedObject = new System.Windows.Forms.Label();
            this.imagesConfigurationObjects = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitConfiguration)).BeginInit();
            this.splitConfiguration.Panel1.SuspendLayout();
            this.splitConfiguration.Panel2.SuspendLayout();
            this.splitConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitObjectViews)).BeginInit();
            this.splitObjectViews.Panel1.SuspendLayout();
            this.splitObjectViews.Panel2.SuspendLayout();
            this.splitObjectViews.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitConfiguration
            // 
            this.splitConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitConfiguration.Location = new System.Drawing.Point(0, 0);
            this.splitConfiguration.Name = "splitConfiguration";
            // 
            // splitConfiguration.Panel1
            // 
            this.splitConfiguration.Panel1.Controls.Add(this.treeEmpyrionObjects);
            // 
            // splitConfiguration.Panel2
            // 
            this.splitConfiguration.Panel2.Controls.Add(this.splitObjectViews);
            this.splitConfiguration.Size = new System.Drawing.Size(662, 436);
            this.splitConfiguration.SplitterDistance = 220;
            this.splitConfiguration.TabIndex = 1;
            // 
            // treeEmpyrionObjects
            // 
            this.treeEmpyrionObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeEmpyrionObjects.Location = new System.Drawing.Point(0, 0);
            this.treeEmpyrionObjects.Name = "treeEmpyrionObjects";
            this.treeEmpyrionObjects.Size = new System.Drawing.Size(220, 436);
            this.treeEmpyrionObjects.TabIndex = 0;
            this.treeEmpyrionObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeEmpyrionObjects_AfterSelect);
            // 
            // splitObjectViews
            // 
            this.splitObjectViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitObjectViews.Location = new System.Drawing.Point(0, 0);
            this.splitObjectViews.Name = "splitObjectViews";
            this.splitObjectViews.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitObjectViews.Panel1
            // 
            this.splitObjectViews.Panel1.Controls.Add(this.txtRawObject);
            this.splitObjectViews.Panel1.Controls.Add(this.lblObjectRaw);
            // 
            // splitObjectViews.Panel2
            // 
            this.splitObjectViews.Panel2.Controls.Add(this.txtResolvedObject);
            this.splitObjectViews.Panel2.Controls.Add(this.lblResolvedObject);
            this.splitObjectViews.Size = new System.Drawing.Size(438, 436);
            this.splitObjectViews.SplitterDistance = 191;
            this.splitObjectViews.TabIndex = 0;
            // 
            // txtRawObject
            // 
            this.txtRawObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRawObject.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRawObject.Location = new System.Drawing.Point(0, 13);
            this.txtRawObject.Multiline = true;
            this.txtRawObject.Name = "txtRawObject";
            this.txtRawObject.ReadOnly = true;
            this.txtRawObject.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRawObject.Size = new System.Drawing.Size(438, 178);
            this.txtRawObject.TabIndex = 1;
            this.txtRawObject.WordWrap = false;
            // 
            // lblObjectRaw
            // 
            this.lblObjectRaw.AutoSize = true;
            this.lblObjectRaw.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblObjectRaw.Location = new System.Drawing.Point(0, 0);
            this.lblObjectRaw.Name = "lblObjectRaw";
            this.lblObjectRaw.Size = new System.Drawing.Size(63, 13);
            this.lblObjectRaw.TabIndex = 0;
            this.lblObjectRaw.Text = "Raw Object";
            // 
            // txtResolvedObject
            // 
            this.txtResolvedObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResolvedObject.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResolvedObject.Location = new System.Drawing.Point(0, 13);
            this.txtResolvedObject.Multiline = true;
            this.txtResolvedObject.Name = "txtResolvedObject";
            this.txtResolvedObject.ReadOnly = true;
            this.txtResolvedObject.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResolvedObject.Size = new System.Drawing.Size(438, 228);
            this.txtResolvedObject.TabIndex = 1;
            this.txtResolvedObject.WordWrap = false;
            // 
            // lblResolvedObject
            // 
            this.lblResolvedObject.AutoSize = true;
            this.lblResolvedObject.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResolvedObject.Location = new System.Drawing.Point(0, 0);
            this.lblResolvedObject.Name = "lblResolvedObject";
            this.lblResolvedObject.Size = new System.Drawing.Size(86, 13);
            this.lblResolvedObject.TabIndex = 0;
            this.lblResolvedObject.Text = "Resolved Object";
            // 
            // imagesConfigurationObjects
            // 
            this.imagesConfigurationObjects.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesConfigurationObjects.ImageStream")));
            this.imagesConfigurationObjects.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesConfigurationObjects.Images.SetKeyName(0, "Block");
            this.imagesConfigurationObjects.Images.SetKeyName(1, "Template");
            this.imagesConfigurationObjects.Images.SetKeyName(2, "Entity");
            this.imagesConfigurationObjects.Images.SetKeyName(3, "Child");
            this.imagesConfigurationObjects.Images.SetKeyName(4, "Container");
            this.imagesConfigurationObjects.Images.SetKeyName(5, "Item");
            this.imagesConfigurationObjects.Images.SetKeyName(6, "LootGroup");
            this.imagesConfigurationObjects.Images.SetKeyName(7, "None");
            // 
            // ConfigurationTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitConfiguration);
            this.Name = "ConfigurationTile";
            this.Size = new System.Drawing.Size(662, 436);
            this.splitConfiguration.Panel1.ResumeLayout(false);
            this.splitConfiguration.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitConfiguration)).EndInit();
            this.splitConfiguration.ResumeLayout(false);
            this.splitObjectViews.Panel1.ResumeLayout(false);
            this.splitObjectViews.Panel1.PerformLayout();
            this.splitObjectViews.Panel2.ResumeLayout(false);
            this.splitObjectViews.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitObjectViews)).EndInit();
            this.splitObjectViews.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitConfiguration;
        private System.Windows.Forms.TreeView treeEmpyrionObjects;
        private System.Windows.Forms.SplitContainer splitObjectViews;
        private System.Windows.Forms.TextBox txtRawObject;
        private System.Windows.Forms.Label lblObjectRaw;
        private System.Windows.Forms.TextBox txtResolvedObject;
        private System.Windows.Forms.Label lblResolvedObject;
        private System.Windows.Forms.ImageList imagesConfigurationObjects;
    }
}
