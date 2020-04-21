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
            this.mainLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLanguageLocalizationNotLoaded = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWindowFullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWindowSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainWindowLayouts = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWindowTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWindowSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainWindowSaveLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWindowLoadLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.switchLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWindowLayoutsNoSaved = new System.Windows.Forms.ToolStripMenuItem();
            this.mainHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mainHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.statusConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusGameState = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusApplicationMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLocalPlayer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusClientPlayfield = new System.Windows.Forms.ToolStripStatusLabel();
            this.openLocalizationFile = new System.Windows.Forms.OpenFileDialog();
            this.tileLayout = new ClientCompanion.TileLayout();
            this.menuMain.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainFile,
            this.mainLanguage,
            this.mainWindow,
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
            // mainWindow
            // 
            this.mainWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainWindowFullscreen,
            this.mainWindowSeparator1,
            this.mainWindowLayouts,
            this.mainWindowTiles,
            this.mainWindowSeparator2,
            this.mainWindowSaveLayout,
            this.mainWindowLoadLayout,
            this.switchLayoutToolStripMenuItem});
            this.mainWindow.Name = "mainWindow";
            this.mainWindow.Size = new System.Drawing.Size(57, 20);
            this.mainWindow.Text = "&Window";
            // 
            // mainWindowFullscreen
            // 
            this.mainWindowFullscreen.Name = "mainWindowFullscreen";
            this.mainWindowFullscreen.ShortcutKeyDisplayString = "F11";
            this.mainWindowFullscreen.Size = new System.Drawing.Size(147, 22);
            this.mainWindowFullscreen.Text = "&Fullscreen";
            this.mainWindowFullscreen.Click += new System.EventHandler(this.mainWindowFullscreen_Click);
            // 
            // mainWindowSeparator1
            // 
            this.mainWindowSeparator1.Name = "mainWindowSeparator1";
            this.mainWindowSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // mainWindowLayouts
            // 
            this.mainWindowLayouts.Name = "mainWindowLayouts";
            this.mainWindowLayouts.Size = new System.Drawing.Size(147, 22);
            this.mainWindowLayouts.Text = "&Layouts";
            this.mainWindowLayouts.Click += new System.EventHandler(this.mainWindowLayouts_Click);
            // 
            // mainWindowTiles
            // 
            this.mainWindowTiles.Name = "mainWindowTiles";
            this.mainWindowTiles.Size = new System.Drawing.Size(147, 22);
            this.mainWindowTiles.Text = "&Tiles";
            this.mainWindowTiles.Click += new System.EventHandler(this.mainWindowTiles_Click);
            // 
            // mainWindowSeparator2
            // 
            this.mainWindowSeparator2.Name = "mainWindowSeparator2";
            this.mainWindowSeparator2.Size = new System.Drawing.Size(144, 6);
            // 
            // mainWindowSaveLayout
            // 
            this.mainWindowSaveLayout.Name = "mainWindowSaveLayout";
            this.mainWindowSaveLayout.Size = new System.Drawing.Size(147, 22);
            this.mainWindowSaveLayout.Text = "Save Layout...";
            this.mainWindowSaveLayout.Click += new System.EventHandler(this.mainWindowSaveLayout_Click);
            // 
            // mainWindowLoadLayout
            // 
            this.mainWindowLoadLayout.Name = "mainWindowLoadLayout";
            this.mainWindowLoadLayout.Size = new System.Drawing.Size(147, 22);
            this.mainWindowLoadLayout.Text = "Load Layout...";
            this.mainWindowLoadLayout.Click += new System.EventHandler(this.mainWindowLoadLayout_Click);
            // 
            // switchLayoutToolStripMenuItem
            // 
            this.switchLayoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainWindowLayoutsNoSaved});
            this.switchLayoutToolStripMenuItem.Name = "switchLayoutToolStripMenuItem";
            this.switchLayoutToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.switchLayoutToolStripMenuItem.Text = "S&witch Layout";
            // 
            // mainWindowLayoutsNoSaved
            // 
            this.mainWindowLayoutsNoSaved.Enabled = false;
            this.mainWindowLayoutsNoSaved.Name = "mainWindowLayoutsNoSaved";
            this.mainWindowLayoutsNoSaved.Size = new System.Drawing.Size(161, 22);
            this.mainWindowLayoutsNoSaved.Text = "No Layouts Saved";
            this.mainWindowLayoutsNoSaved.Click += new System.EventHandler(this.mainWindowLayoutsSaved_Click);
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
            // 
            // statusMain
            // 
            this.statusMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusConnection,
            this.statusGameState,
            this.statusApplicationMode,
            this.statusLocalPlayer,
            this.statusClientPlayfield});
            this.statusMain.Location = new System.Drawing.Point(0, 424);
            this.statusMain.Name = "statusMain";
            this.statusMain.ShowItemToolTips = true;
            this.statusMain.Size = new System.Drawing.Size(800, 26);
            this.statusMain.SizingGrip = false;
            this.statusMain.TabIndex = 2;
            this.statusMain.Text = "Companion Status";
            // 
            // statusConnection
            // 
            this.statusConnection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusConnection.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusConnection.Name = "statusConnection";
            this.statusConnection.Padding = new System.Windows.Forms.Padding(2);
            this.statusConnection.Size = new System.Drawing.Size(461, 21);
            this.statusConnection.Spring = true;
            this.statusConnection.Text = "Disconnected";
            this.statusConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusConnection.ToolTipText = "State of the connection to an Empyrion game running the Dark City Extensions.";
            // 
            // statusGameState
            // 
            this.statusGameState.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusGameState.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusGameState.Name = "statusGameState";
            this.statusGameState.Padding = new System.Windows.Forms.Padding(2);
            this.statusGameState.Size = new System.Drawing.Size(71, 21);
            this.statusGameState.Text = "Game State";
            this.statusGameState.ToolTipText = "State of the Empyrion game. Usually NotRunning or Running.";
            // 
            // statusApplicationMode
            // 
            this.statusApplicationMode.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusApplicationMode.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusApplicationMode.Name = "statusApplicationMode";
            this.statusApplicationMode.Padding = new System.Windows.Forms.Padding(2);
            this.statusApplicationMode.Size = new System.Drawing.Size(96, 21);
            this.statusApplicationMode.Text = "Application Mode";
            this.statusApplicationMode.ToolTipText = "Application mode that Empyrion is running in. Usually SinglePlayer or Client.";
            // 
            // statusLocalPlayer
            // 
            this.statusLocalPlayer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLocalPlayer.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusLocalPlayer.Name = "statusLocalPlayer";
            this.statusLocalPlayer.Padding = new System.Windows.Forms.Padding(2);
            this.statusLocalPlayer.Size = new System.Drawing.Size(72, 21);
            this.statusLocalPlayer.Text = "Local Player";
            this.statusLocalPlayer.ToolTipText = "Name of the local player that is logged into the Empyrion game.";
            // 
            // statusClientPlayfield
            // 
            this.statusClientPlayfield.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusClientPlayfield.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusClientPlayfield.Name = "statusClientPlayfield";
            this.statusClientPlayfield.Padding = new System.Windows.Forms.Padding(2);
            this.statusClientPlayfield.Size = new System.Drawing.Size(85, 21);
            this.statusClientPlayfield.Text = "Client Playfield";
            this.statusClientPlayfield.ToolTipText = "Name of the playfield that Empyrion is currently running as a client.";
            // 
            // openLocalizationFile
            // 
            this.openLocalizationFile.DefaultExt = "csv";
            this.openLocalizationFile.FileName = "Localization.csv";
            this.openLocalizationFile.Filter = "CSV Files|*.csv|All Files|*.*";
            this.openLocalizationFile.InitialDirectory = "%PROGRAMFILES%\\Steam\\SteamApps\\common\\Empyrion - Galactic Survival\\Content\\Extras" +
    "";
            this.openLocalizationFile.RestoreDirectory = true;
            this.openLocalizationFile.ShowReadOnly = true;
            this.openLocalizationFile.Title = "Open Empyrion Localization File";
            // 
            // tileLayout
            // 
            this.tileLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tileLayout.ColumnCount = 1;
            this.tileLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tileLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tileLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileLayout.Location = new System.Drawing.Point(0, 24);
            this.tileLayout.Name = "tileLayout";
            this.tileLayout.RowCount = 1;
            this.tileLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tileLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tileLayout.Size = new System.Drawing.Size(800, 400);
            this.tileLayout.TabIndex = 3;
            // 
            // frmClientCompanion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tileLayout);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "frmClientCompanion";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Empyrion Client Companion";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem mainFile;
        private System.Windows.Forms.ToolStripMenuItem mainHelp;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel statusConnection;
        private System.Windows.Forms.ToolStripStatusLabel statusLocalPlayer;
        private System.Windows.Forms.ToolStripStatusLabel statusApplicationMode;
        private System.Windows.Forms.ToolStripMenuItem mainFileConnectLocal;
        private System.Windows.Forms.ToolStripMenuItem mainFileConnectRemote;
        private System.Windows.Forms.ToolStripSeparator mainFileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mainFileOpenConfiguration;
        private System.Windows.Forms.ToolStripMenuItem mainFileOpenLocalization;
        private System.Windows.Forms.ToolStripSeparator mainFileSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mainFileExit;
        private System.Windows.Forms.ToolStripMenuItem mainLanguage;
        private System.Windows.Forms.ToolStripMenuItem mainLanguageLocalizationNotLoaded;
        private System.Windows.Forms.ToolStripMenuItem mainHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mainFileDisconnect;
        private System.Windows.Forms.ToolStripStatusLabel statusClientPlayfield;
        private System.Windows.Forms.ToolStripStatusLabel statusGameState;
        private System.Windows.Forms.OpenFileDialog openLocalizationFile;
        private System.Windows.Forms.ToolStripMenuItem mainWindow;
        private System.Windows.Forms.ToolStripMenuItem mainWindowFullscreen;
        private System.Windows.Forms.ToolStripSeparator mainWindowSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mainWindowLayouts;
        private System.Windows.Forms.ToolStripMenuItem mainWindowTiles;
        private System.Windows.Forms.ToolStripSeparator mainWindowSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mainWindowSaveLayout;
        private System.Windows.Forms.ToolStripMenuItem mainWindowLoadLayout;
        private TileLayout tileLayout;
        private System.Windows.Forms.ToolStripMenuItem switchLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainWindowLayoutsNoSaved;
    }
}

