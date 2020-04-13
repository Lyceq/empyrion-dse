namespace ClientCompanion
{
    partial class frmClientCompanion
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Playfield Data", "playfield");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientCompanion));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.mainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFileConnectLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFileConnectRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFileDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainFileOpenConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFileOpenLocalization = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayout1Tile = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayout2x1Tiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayout2x2Tiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLanguageLocalizationNotLoaded = new System.Windows.Forms.ToolStripMenuItem();
            this.mainHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mainHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTiles = new System.Windows.Forms.TableLayoutPanel();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPlayerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPlayfield = new System.Windows.Forms.ToolStripStatusLabel();
            this.listTiles = new System.Windows.Forms.ListView();
            this.imagesTiles = new System.Windows.Forms.ImageList(this.components);
            this.timerRequestData = new System.Windows.Forms.Timer(this.components);
            this.menuMain.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainFile,
            this.mainLayout,
            this.mainLanguage,
            this.mainHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(800, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "Main Menu";
            // 
            // mainFile
            // 
            this.mainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainFileConnectLocal,
            this.mainFileConnectRemote,
            this.mainFileDisconnect,
            this.mainFileSeparator1,
            this.mainFileOpenConfiguration,
            this.mainFileOpenLocalization,
            this.mainFileSeparator2,
            this.mainFileExit});
            this.mainFile.Name = "mainFile";
            this.mainFile.Size = new System.Drawing.Size(35, 20);
            this.mainFile.Text = "&File";
            // 
            // mainFileConnectLocal
            // 
            this.mainFileConnectLocal.Name = "mainFileConnectLocal";
            this.mainFileConnectLocal.Size = new System.Drawing.Size(180, 22);
            this.mainFileConnectLocal.Text = "&Connect Local";
            this.mainFileConnectLocal.Click += new System.EventHandler(this.mainFileConnectLocal_Click);
            // 
            // mainFileConnectRemote
            // 
            this.mainFileConnectRemote.Name = "mainFileConnectRemote";
            this.mainFileConnectRemote.Size = new System.Drawing.Size(180, 22);
            this.mainFileConnectRemote.Text = "Connect &Remote...";
            this.mainFileConnectRemote.Click += new System.EventHandler(this.mainFileConnectRemote_Click);
            // 
            // mainFileDisconnect
            // 
            this.mainFileDisconnect.Enabled = false;
            this.mainFileDisconnect.Name = "mainFileDisconnect";
            this.mainFileDisconnect.Size = new System.Drawing.Size(180, 22);
            this.mainFileDisconnect.Text = "&Disconnect";
            this.mainFileDisconnect.Click += new System.EventHandler(this.mainFileDisconnect_Click);
            // 
            // mainFileSeparator1
            // 
            this.mainFileSeparator1.Name = "mainFileSeparator1";
            this.mainFileSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mainFileOpenConfiguration
            // 
            this.mainFileOpenConfiguration.Name = "mainFileOpenConfiguration";
            this.mainFileOpenConfiguration.Size = new System.Drawing.Size(180, 22);
            this.mainFileOpenConfiguration.Text = "&Open Configuration...";
            this.mainFileOpenConfiguration.Click += new System.EventHandler(this.mainFileOpenConfiguration_Click);
            // 
            // mainFileOpenLocalization
            // 
            this.mainFileOpenLocalization.Name = "mainFileOpenLocalization";
            this.mainFileOpenLocalization.Size = new System.Drawing.Size(180, 22);
            this.mainFileOpenLocalization.Text = "Open &Localization...";
            this.mainFileOpenLocalization.Click += new System.EventHandler(this.mainFileOpenLocalization_Click);
            // 
            // mainFileSeparator2
            // 
            this.mainFileSeparator2.Name = "mainFileSeparator2";
            this.mainFileSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // mainFileExit
            // 
            this.mainFileExit.Name = "mainFileExit";
            this.mainFileExit.Size = new System.Drawing.Size(180, 22);
            this.mainFileExit.Text = "E&xit";
            this.mainFileExit.Click += new System.EventHandler(this.mainFileExit_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainLayout1Tile,
            this.mainLayout2x1Tiles,
            this.mainLayout2x2Tiles});
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Size = new System.Drawing.Size(52, 20);
            this.mainLayout.Text = "&Layout";
            // 
            // mainLayout1Tile
            // 
            this.mainLayout1Tile.Name = "mainLayout1Tile";
            this.mainLayout1Tile.Size = new System.Drawing.Size(122, 22);
            this.mainLayout1Tile.Text = "1 Tile";
            this.mainLayout1Tile.Click += new System.EventHandler(this.mainLayout1Tile_Click);
            // 
            // mainLayout2x1Tiles
            // 
            this.mainLayout2x1Tiles.Name = "mainLayout2x1Tiles";
            this.mainLayout2x1Tiles.Size = new System.Drawing.Size(122, 22);
            this.mainLayout2x1Tiles.Text = "2 x 1 Tiles";
            this.mainLayout2x1Tiles.Click += new System.EventHandler(this.mainLayout2x1Tiles_Click);
            // 
            // mainLayout2x2Tiles
            // 
            this.mainLayout2x2Tiles.Name = "mainLayout2x2Tiles";
            this.mainLayout2x2Tiles.Size = new System.Drawing.Size(122, 22);
            this.mainLayout2x2Tiles.Text = "2 x 2 Tiles";
            this.mainLayout2x2Tiles.Click += new System.EventHandler(this.mainLayout2x2Tiles_Click);
            // 
            // mainLanguage
            // 
            this.mainLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainLanguageLocalizationNotLoaded});
            this.mainLanguage.Name = "mainLanguage";
            this.mainLanguage.Size = new System.Drawing.Size(66, 20);
            this.mainLanguage.Text = "&Language";
            // 
            // mainLanguageLocalizationNotLoaded
            // 
            this.mainLanguageLocalizationNotLoaded.Enabled = false;
            this.mainLanguageLocalizationNotLoaded.Name = "mainLanguageLocalizationNotLoaded";
            this.mainLanguageLocalizationNotLoaded.Size = new System.Drawing.Size(183, 22);
            this.mainLanguageLocalizationNotLoaded.Text = "Localization not loaded";
            // 
            // mainHelp
            // 
            this.mainHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainHelpAbout});
            this.mainHelp.Name = "mainHelp";
            this.mainHelp.Size = new System.Drawing.Size(40, 20);
            this.mainHelp.Text = "&Help";
            // 
            // mainHelpAbout
            // 
            this.mainHelpAbout.Name = "mainHelpAbout";
            this.mainHelpAbout.Size = new System.Drawing.Size(115, 22);
            this.mainHelpAbout.Text = "&About...";
            this.mainHelpAbout.Click += new System.EventHandler(this.mainHelpAbout_Click);
            // 
            // panelTiles
            // 
            this.panelTiles.ColumnCount = 1;
            this.panelTiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTiles.Location = new System.Drawing.Point(174, 24);
            this.panelTiles.Name = "panelTiles";
            this.panelTiles.RowCount = 1;
            this.panelTiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 404F));
            this.panelTiles.Size = new System.Drawing.Size(626, 404);
            this.panelTiles.TabIndex = 1;
            // 
            // StatusStrip
            // 
            this.StatusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusConnection,
            this.statusPlayerName,
            this.statusPlayfield});
            this.StatusStrip.Location = new System.Drawing.Point(0, 428);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.ShowItemToolTips = true;
            this.StatusStrip.Size = new System.Drawing.Size(800, 22);
            this.StatusStrip.TabIndex = 2;
            this.StatusStrip.Text = "Companion Status";
            // 
            // statusConnection
            // 
            this.statusConnection.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusConnection.Name = "statusConnection";
            this.statusConnection.Size = new System.Drawing.Size(71, 17);
            this.statusConnection.Text = "Disconnected";
            // 
            // statusPlayerName
            // 
            this.statusPlayerName.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusPlayerName.Name = "statusPlayerName";
            this.statusPlayerName.Size = new System.Drawing.Size(91, 17);
            this.statusPlayerName.Text = "No Player Loaded";
            // 
            // statusPlayfield
            // 
            this.statusPlayfield.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusPlayfield.Name = "statusPlayfield";
            this.statusPlayfield.Size = new System.Drawing.Size(101, 17);
            this.statusPlayfield.Text = "No Playfield Loaded";
            // 
            // listTiles
            // 
            this.listTiles.Dock = System.Windows.Forms.DockStyle.Left;
            listViewItem2.ToolTipText = "Displays information about the player\'s current playfield.";
            this.listTiles.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listTiles.LargeImageList = this.imagesTiles;
            this.listTiles.Location = new System.Drawing.Point(0, 24);
            this.listTiles.MultiSelect = false;
            this.listTiles.Name = "listTiles";
            this.listTiles.ShowItemToolTips = true;
            this.listTiles.Size = new System.Drawing.Size(174, 404);
            this.listTiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listTiles.TabIndex = 0;
            this.listTiles.UseCompatibleStateImageBehavior = false;
            // 
            // imagesTiles
            // 
            this.imagesTiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesTiles.ImageStream")));
            this.imagesTiles.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesTiles.Images.SetKeyName(0, "playfield");
            // 
            // timerRequestData
            // 
            this.timerRequestData.Enabled = true;
            this.timerRequestData.Interval = 2000;
            this.timerRequestData.Tick += new System.EventHandler(this.timerRequestData_Tick);
            // 
            // frmClientCompanion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelTiles);
            this.Controls.Add(this.listTiles);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "frmClientCompanion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Empyrion Client Companion";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem mainFile;
        private System.Windows.Forms.ToolStripMenuItem mainLayout;
        private System.Windows.Forms.ToolStripMenuItem mainHelp;
        private System.Windows.Forms.TableLayoutPanel panelTiles;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusConnection;
        private System.Windows.Forms.ToolStripStatusLabel statusPlayerName;
        private System.Windows.Forms.ToolStripStatusLabel statusPlayfield;
        private System.Windows.Forms.ToolStripMenuItem mainFileConnectLocal;
        private System.Windows.Forms.ToolStripMenuItem mainFileConnectRemote;
        private System.Windows.Forms.ToolStripSeparator mainFileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mainFileOpenConfiguration;
        private System.Windows.Forms.ToolStripMenuItem mainFileOpenLocalization;
        private System.Windows.Forms.ToolStripSeparator mainFileSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mainFileExit;
        private System.Windows.Forms.ToolStripMenuItem mainLayout1Tile;
        private System.Windows.Forms.ToolStripMenuItem mainLayout2x1Tiles;
        private System.Windows.Forms.ToolStripMenuItem mainLayout2x2Tiles;
        private System.Windows.Forms.ToolStripMenuItem mainLanguage;
        private System.Windows.Forms.ToolStripMenuItem mainLanguageLocalizationNotLoaded;
        private System.Windows.Forms.ToolStripMenuItem mainHelpAbout;
        private System.Windows.Forms.ListView listTiles;
        private System.Windows.Forms.ImageList imagesTiles;
        private System.Windows.Forms.ToolStripMenuItem mainFileDisconnect;
        private System.Windows.Forms.Timer timerRequestData;
    }
}

