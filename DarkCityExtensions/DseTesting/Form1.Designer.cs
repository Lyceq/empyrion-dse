namespace DseTesting
{
    partial class formDseTesting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDseTesting));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.splitConfiguration = new System.Windows.Forms.SplitContainer();
            this.treeEmpyrionObjects = new System.Windows.Forms.TreeView();
            this.imagesConfigurationObjects = new System.Windows.Forms.ImageList(this.components);
            this.splitObjectViews = new System.Windows.Forms.SplitContainer();
            this.txtRawObject = new System.Windows.Forms.TextBox();
            this.lblObjectRaw = new System.Windows.Forms.Label();
            this.txtResolvedObject = new System.Windows.Forms.TextBox();
            this.lblResolvedObject = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpenConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpenLocalization = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageNotLoaded = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigurationFile = new System.Windows.Forms.OpenFileDialog();
            this.openLocalizationFile = new System.Windows.Forms.OpenFileDialog();
            this.mainTabControl.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitConfiguration)).BeginInit();
            this.splitConfiguration.Panel1.SuspendLayout();
            this.splitConfiguration.Panel2.SuspendLayout();
            this.splitConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitObjectViews)).BeginInit();
            this.splitObjectViews.Panel1.SuspendLayout();
            this.splitObjectViews.Panel2.SuspendLayout();
            this.splitObjectViews.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabConfiguration);
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 24);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(800, 426);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.splitConfiguration);
            this.tabConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguration.Size = new System.Drawing.Size(792, 400);
            this.tabConfiguration.TabIndex = 0;
            this.tabConfiguration.Text = "Configuration";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            // 
            // splitConfiguration
            // 
            this.splitConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitConfiguration.Location = new System.Drawing.Point(3, 3);
            this.splitConfiguration.Name = "splitConfiguration";
            // 
            // splitConfiguration.Panel1
            // 
            this.splitConfiguration.Panel1.Controls.Add(this.treeEmpyrionObjects);
            // 
            // splitConfiguration.Panel2
            // 
            this.splitConfiguration.Panel2.Controls.Add(this.splitObjectViews);
            this.splitConfiguration.Size = new System.Drawing.Size(786, 394);
            this.splitConfiguration.SplitterDistance = 262;
            this.splitConfiguration.TabIndex = 0;
            // 
            // treeEmpyrionObjects
            // 
            this.treeEmpyrionObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeEmpyrionObjects.ImageIndex = 0;
            this.treeEmpyrionObjects.ImageList = this.imagesConfigurationObjects;
            this.treeEmpyrionObjects.Location = new System.Drawing.Point(0, 0);
            this.treeEmpyrionObjects.Name = "treeEmpyrionObjects";
            this.treeEmpyrionObjects.SelectedImageIndex = 0;
            this.treeEmpyrionObjects.Size = new System.Drawing.Size(262, 394);
            this.treeEmpyrionObjects.TabIndex = 0;
            this.treeEmpyrionObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeEmpyrionObjects_AfterSelect);
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
            this.splitObjectViews.Size = new System.Drawing.Size(520, 394);
            this.splitObjectViews.SplitterDistance = 173;
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
            this.txtRawObject.Size = new System.Drawing.Size(520, 160);
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
            this.txtResolvedObject.Size = new System.Drawing.Size(520, 204);
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuLanguage,
            this.menuHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(800, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "Main Menu";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileOpenConfiguration,
            this.menuFileOpenLocalization,
            this.menuFileSeperator1,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 20);
            this.menuFile.Text = "&File";
            // 
            // menuFileOpenConfiguration
            // 
            this.menuFileOpenConfiguration.Name = "menuFileOpenConfiguration";
            this.menuFileOpenConfiguration.Size = new System.Drawing.Size(180, 22);
            this.menuFileOpenConfiguration.Text = "&Open Configuration...";
            this.menuFileOpenConfiguration.Click += new System.EventHandler(this.menuFileOpenConfiguration_Click);
            // 
            // menuFileOpenLocalization
            // 
            this.menuFileOpenLocalization.Name = "menuFileOpenLocalization";
            this.menuFileOpenLocalization.Size = new System.Drawing.Size(180, 22);
            this.menuFileOpenLocalization.Text = "Open &Localization...";
            this.menuFileOpenLocalization.Click += new System.EventHandler(this.menuFileOpenLocalization_Click);
            // 
            // menuFileSeperator1
            // 
            this.menuFileSeperator1.Name = "menuFileSeperator1";
            this.menuFileSeperator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(180, 22);
            this.menuFileExit.Text = "E&xit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuLanguage
            // 
            this.menuLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLanguageNotLoaded});
            this.menuLanguage.Name = "menuLanguage";
            this.menuLanguage.Size = new System.Drawing.Size(66, 20);
            this.menuLanguage.Text = "&Language";
            // 
            // menuLanguageNotLoaded
            // 
            this.menuLanguageNotLoaded.Enabled = false;
            this.menuLanguageNotLoaded.Name = "menuLanguageNotLoaded";
            this.menuLanguageNotLoaded.Size = new System.Drawing.Size(183, 22);
            this.menuLanguageNotLoaded.Text = "Localization not loaded";
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(40, 20);
            this.menuHelp.Text = "&Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(115, 22);
            this.menuHelpAbout.Text = "&About...";
            // 
            // openConfigurationFile
            // 
            this.openConfigurationFile.DefaultExt = "ecf";
            this.openConfigurationFile.FileName = "Config_Example.ecf";
            this.openConfigurationFile.Filter = "Empyrion configuration files|*.ecf|Text files|*.txt|All files|*.*";
            this.openConfigurationFile.RestoreDirectory = true;
            this.openConfigurationFile.ShowReadOnly = true;
            this.openConfigurationFile.Title = "Open Empyrion Configuration File";
            // 
            // openLocalizationFile
            // 
            this.openLocalizationFile.DefaultExt = "csv";
            this.openLocalizationFile.FileName = "Localization.csv";
            this.openLocalizationFile.Filter = "CSV files|*.csv|All files|*.*";
            this.openLocalizationFile.InitialDirectory = "%PROGRAMFILES%\\Steam\\steamapps\\common\\Empyrion - Galactic Survival\\Content\\Extras" +
    "\\";
            this.openLocalizationFile.RestoreDirectory = true;
            this.openLocalizationFile.ShowReadOnly = true;
            // 
            // formDseTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "formDseTesting";
            this.Text = "Empyrion DarkCity Extension Testing";
            this.mainTabControl.ResumeLayout(false);
            this.tabConfiguration.ResumeLayout(false);
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
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabConfiguration;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitConfiguration;
        private System.Windows.Forms.TreeView treeEmpyrionObjects;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpenConfiguration;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpenLocalization;
        private System.Windows.Forms.ToolStripSeparator menuFileSeperator1;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.OpenFileDialog openConfigurationFile;
        private System.Windows.Forms.OpenFileDialog openLocalizationFile;
        private System.Windows.Forms.ImageList imagesConfigurationObjects;
        private System.Windows.Forms.ToolStripMenuItem menuLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageNotLoaded;
        private System.Windows.Forms.SplitContainer splitObjectViews;
        private System.Windows.Forms.TextBox txtRawObject;
        private System.Windows.Forms.Label lblObjectRaw;
        private System.Windows.Forms.TextBox txtResolvedObject;
        private System.Windows.Forms.Label lblResolvedObject;
    }
}

