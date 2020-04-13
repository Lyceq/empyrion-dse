namespace DarkCity.Testing
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
            this.imagesConfigurationObjects = new System.Windows.Forms.ImageList(this.components);
            this.openConfigurationFile = new System.Windows.Forms.OpenFileDialog();
            this.openLocalizationFile = new System.Windows.Forms.OpenFileDialog();
            this.folderRootDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageNotLoaded = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitLog = new System.Windows.Forms.SplitContainer();
            this.panelTabMain = new System.Windows.Forms.TabControl();
            this.tabSimulation = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelSimulationState = new System.Windows.Forms.GroupBox();
            this.btnSimulationStop = new System.Windows.Forms.Button();
            this.btnSimulationPause = new System.Windows.Forms.Button();
            this.btnSimulationStart = new System.Windows.Forms.Button();
            this.lblSimulationState = new System.Windows.Forms.Label();
            this.btnSimulationCreate = new System.Windows.Forms.Button();
            this.panelSimulationSetup = new System.Windows.Forms.GroupBox();
            this.cboSimulationSaveGame = new System.Windows.Forms.ComboBox();
            this.lblSimulationSaveGame = new System.Windows.Forms.Label();
            this.nudSimulationTickTime = new System.Windows.Forms.NumericUpDown();
            this.lblSimulationTickTime = new System.Windows.Forms.Label();
            this.lblSimulationRootPath = new System.Windows.Forms.Label();
            this.btnSimulationChooseRootPath = new System.Windows.Forms.Button();
            this.txtSimulationRootPath = new System.Windows.Forms.TextBox();
            this.panelSimulationMods = new System.Windows.Forms.GroupBox();
            this.lblSimulationModDetails = new System.Windows.Forms.Label();
            this.clbSimulationMods = new System.Windows.Forms.CheckedListBox();
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.configurationTile1 = new DarkCity.Tiles.ConfigurationTile();
            this.tabLocalization = new System.Windows.Forms.TabPage();
            this.txtSimulationLog = new System.Windows.Forms.TextBox();
            this.tabPlayfields = new System.Windows.Forms.TabPage();
            this.tilePlayfields = new DarkCity.Testing.Tiles.PlayfieldSimulationTile();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLog)).BeginInit();
            this.splitLog.Panel1.SuspendLayout();
            this.splitLog.Panel2.SuspendLayout();
            this.splitLog.SuspendLayout();
            this.panelTabMain.SuspendLayout();
            this.tabSimulation.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelSimulationState.SuspendLayout();
            this.panelSimulationSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimulationTickTime)).BeginInit();
            this.panelSimulationMods.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.tabPlayfields.SuspendLayout();
            this.SuspendLayout();
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
            // folderRootDirectory
            // 
            this.folderRootDirectory.Description = "Select the root directory of your Empyrion installation.";
            this.folderRootDirectory.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderRootDirectory.ShowNewFolderButton = false;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuLanguage,
            this.menuHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(617, 24);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "Main Menu";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 20);
            this.menuFile.Text = "&File";
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(92, 22);
            this.menuFileExit.Text = "E&xit";
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
            // splitLog
            // 
            this.splitLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLog.Location = new System.Drawing.Point(0, 24);
            this.splitLog.Name = "splitLog";
            this.splitLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLog.Panel1
            // 
            this.splitLog.Panel1.Controls.Add(this.panelTabMain);
            // 
            // splitLog.Panel2
            // 
            this.splitLog.Panel2.Controls.Add(this.txtSimulationLog);
            this.splitLog.Size = new System.Drawing.Size(617, 532);
            this.splitLog.SplitterDistance = 331;
            this.splitLog.TabIndex = 5;
            // 
            // panelTabMain
            // 
            this.panelTabMain.Controls.Add(this.tabSimulation);
            this.panelTabMain.Controls.Add(this.tabConfiguration);
            this.panelTabMain.Controls.Add(this.tabLocalization);
            this.panelTabMain.Controls.Add(this.tabPlayfields);
            this.panelTabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabMain.Location = new System.Drawing.Point(0, 0);
            this.panelTabMain.Name = "panelTabMain";
            this.panelTabMain.SelectedIndex = 0;
            this.panelTabMain.Size = new System.Drawing.Size(617, 331);
            this.panelTabMain.TabIndex = 4;
            // 
            // tabSimulation
            // 
            this.tabSimulation.Controls.Add(this.tableLayoutPanel1);
            this.tabSimulation.Location = new System.Drawing.Point(4, 22);
            this.tabSimulation.Name = "tabSimulation";
            this.tabSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimulation.Size = new System.Drawing.Size(609, 305);
            this.tabSimulation.TabIndex = 2;
            this.tabSimulation.Text = "Simulation";
            this.tabSimulation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelSimulationState, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelSimulationSetup, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelSimulationMods, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(603, 299);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panelSimulationState
            // 
            this.panelSimulationState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSimulationState.Controls.Add(this.btnSimulationStop);
            this.panelSimulationState.Controls.Add(this.btnSimulationPause);
            this.panelSimulationState.Controls.Add(this.btnSimulationStart);
            this.panelSimulationState.Controls.Add(this.lblSimulationState);
            this.panelSimulationState.Controls.Add(this.btnSimulationCreate);
            this.panelSimulationState.Location = new System.Drawing.Point(201, 3);
            this.panelSimulationState.Name = "panelSimulationState";
            this.panelSimulationState.Size = new System.Drawing.Size(200, 293);
            this.panelSimulationState.TabIndex = 7;
            this.panelSimulationState.TabStop = false;
            this.panelSimulationState.Text = "State";
            // 
            // btnSimulationStop
            // 
            this.btnSimulationStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulationStop.Location = new System.Drawing.Point(6, 142);
            this.btnSimulationStop.Name = "btnSimulationStop";
            this.btnSimulationStop.Size = new System.Drawing.Size(188, 23);
            this.btnSimulationStop.TabIndex = 5;
            this.btnSimulationStop.Text = "Stop";
            this.btnSimulationStop.UseVisualStyleBackColor = true;
            this.btnSimulationStop.Click += new System.EventHandler(this.btnSimulationStop_Click);
            // 
            // btnSimulationPause
            // 
            this.btnSimulationPause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulationPause.Location = new System.Drawing.Point(6, 113);
            this.btnSimulationPause.Name = "btnSimulationPause";
            this.btnSimulationPause.Size = new System.Drawing.Size(188, 23);
            this.btnSimulationPause.TabIndex = 4;
            this.btnSimulationPause.Text = "Pause";
            this.btnSimulationPause.UseVisualStyleBackColor = true;
            this.btnSimulationPause.Click += new System.EventHandler(this.btnSimulationPause_Click);
            // 
            // btnSimulationStart
            // 
            this.btnSimulationStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulationStart.Location = new System.Drawing.Point(6, 84);
            this.btnSimulationStart.Name = "btnSimulationStart";
            this.btnSimulationStart.Size = new System.Drawing.Size(188, 23);
            this.btnSimulationStart.TabIndex = 3;
            this.btnSimulationStart.Text = "Start";
            this.btnSimulationStart.UseVisualStyleBackColor = true;
            this.btnSimulationStart.Click += new System.EventHandler(this.btnSimulationStart_Click);
            // 
            // lblSimulationState
            // 
            this.lblSimulationState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSimulationState.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimulationState.Location = new System.Drawing.Point(6, 16);
            this.lblSimulationState.Name = "lblSimulationState";
            this.lblSimulationState.Size = new System.Drawing.Size(188, 36);
            this.lblSimulationState.TabIndex = 2;
            this.lblSimulationState.Text = "Not Created";
            this.lblSimulationState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSimulationCreate
            // 
            this.btnSimulationCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulationCreate.Location = new System.Drawing.Point(6, 55);
            this.btnSimulationCreate.Name = "btnSimulationCreate";
            this.btnSimulationCreate.Size = new System.Drawing.Size(188, 23);
            this.btnSimulationCreate.TabIndex = 1;
            this.btnSimulationCreate.Text = "Create";
            this.btnSimulationCreate.UseVisualStyleBackColor = true;
            this.btnSimulationCreate.Click += new System.EventHandler(this.btnSimulationCreate_Click);
            // 
            // panelSimulationSetup
            // 
            this.panelSimulationSetup.Controls.Add(this.cboSimulationSaveGame);
            this.panelSimulationSetup.Controls.Add(this.lblSimulationSaveGame);
            this.panelSimulationSetup.Controls.Add(this.nudSimulationTickTime);
            this.panelSimulationSetup.Controls.Add(this.lblSimulationTickTime);
            this.panelSimulationSetup.Controls.Add(this.lblSimulationRootPath);
            this.panelSimulationSetup.Controls.Add(this.btnSimulationChooseRootPath);
            this.panelSimulationSetup.Controls.Add(this.txtSimulationRootPath);
            this.panelSimulationSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSimulationSetup.Location = new System.Drawing.Point(3, 3);
            this.panelSimulationSetup.Name = "panelSimulationSetup";
            this.panelSimulationSetup.Size = new System.Drawing.Size(192, 293);
            this.panelSimulationSetup.TabIndex = 6;
            this.panelSimulationSetup.TabStop = false;
            this.panelSimulationSetup.Text = "Setup";
            // 
            // cboSimulationSaveGame
            // 
            this.cboSimulationSaveGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSimulationSaveGame.FormattingEnabled = true;
            this.cboSimulationSaveGame.Location = new System.Drawing.Point(6, 80);
            this.cboSimulationSaveGame.Name = "cboSimulationSaveGame";
            this.cboSimulationSaveGame.Size = new System.Drawing.Size(180, 21);
            this.cboSimulationSaveGame.TabIndex = 9;
            // 
            // lblSimulationSaveGame
            // 
            this.lblSimulationSaveGame.AutoSize = true;
            this.lblSimulationSaveGame.Location = new System.Drawing.Point(6, 64);
            this.lblSimulationSaveGame.Name = "lblSimulationSaveGame";
            this.lblSimulationSaveGame.Size = new System.Drawing.Size(63, 13);
            this.lblSimulationSaveGame.TabIndex = 8;
            this.lblSimulationSaveGame.Text = "Save Game";
            // 
            // nudSimulationTickTime
            // 
            this.nudSimulationTickTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSimulationTickTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSimulationTickTime.Location = new System.Drawing.Point(6, 267);
            this.nudSimulationTickTime.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nudSimulationTickTime.Name = "nudSimulationTickTime";
            this.nudSimulationTickTime.Size = new System.Drawing.Size(180, 20);
            this.nudSimulationTickTime.TabIndex = 7;
            this.nudSimulationTickTime.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudSimulationTickTime.ValueChanged += new System.EventHandler(this.nudSimulationTickTime_ValueChanged);
            // 
            // lblSimulationTickTime
            // 
            this.lblSimulationTickTime.AutoSize = true;
            this.lblSimulationTickTime.Location = new System.Drawing.Point(6, 251);
            this.lblSimulationTickTime.Name = "lblSimulationTickTime";
            this.lblSimulationTickTime.Size = new System.Drawing.Size(94, 13);
            this.lblSimulationTickTime.TabIndex = 6;
            this.lblSimulationTickTime.Text = "Time per Tick (ms)";
            // 
            // lblSimulationRootPath
            // 
            this.lblSimulationRootPath.AutoSize = true;
            this.lblSimulationRootPath.Location = new System.Drawing.Point(6, 16);
            this.lblSimulationRootPath.Name = "lblSimulationRootPath";
            this.lblSimulationRootPath.Size = new System.Drawing.Size(101, 13);
            this.lblSimulationRootPath.TabIndex = 3;
            this.lblSimulationRootPath.Text = "Empyrion Root Path";
            // 
            // btnSimulationChooseRootPath
            // 
            this.btnSimulationChooseRootPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulationChooseRootPath.Location = new System.Drawing.Point(156, 32);
            this.btnSimulationChooseRootPath.Name = "btnSimulationChooseRootPath";
            this.btnSimulationChooseRootPath.Size = new System.Drawing.Size(30, 20);
            this.btnSimulationChooseRootPath.TabIndex = 5;
            this.btnSimulationChooseRootPath.Text = "…";
            this.btnSimulationChooseRootPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSimulationChooseRootPath.UseVisualStyleBackColor = true;
            // 
            // txtSimulationRootPath
            // 
            this.txtSimulationRootPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSimulationRootPath.Location = new System.Drawing.Point(6, 32);
            this.txtSimulationRootPath.Name = "txtSimulationRootPath";
            this.txtSimulationRootPath.Size = new System.Drawing.Size(144, 20);
            this.txtSimulationRootPath.TabIndex = 4;
            // 
            // panelSimulationMods
            // 
            this.panelSimulationMods.Controls.Add(this.lblSimulationModDetails);
            this.panelSimulationMods.Controls.Add(this.clbSimulationMods);
            this.panelSimulationMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSimulationMods.Location = new System.Drawing.Point(407, 3);
            this.panelSimulationMods.Name = "panelSimulationMods";
            this.panelSimulationMods.Size = new System.Drawing.Size(193, 293);
            this.panelSimulationMods.TabIndex = 8;
            this.panelSimulationMods.TabStop = false;
            this.panelSimulationMods.Text = "Mods";
            // 
            // lblSimulationModDetails
            // 
            this.lblSimulationModDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSimulationModDetails.Location = new System.Drawing.Point(6, 146);
            this.lblSimulationModDetails.Name = "lblSimulationModDetails";
            this.lblSimulationModDetails.Size = new System.Drawing.Size(181, 144);
            this.lblSimulationModDetails.TabIndex = 1;
            // 
            // clbSimulationMods
            // 
            this.clbSimulationMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbSimulationMods.FormattingEnabled = true;
            this.clbSimulationMods.IntegralHeight = false;
            this.clbSimulationMods.Location = new System.Drawing.Point(6, 19);
            this.clbSimulationMods.Name = "clbSimulationMods";
            this.clbSimulationMods.Size = new System.Drawing.Size(181, 124);
            this.clbSimulationMods.Sorted = true;
            this.clbSimulationMods.TabIndex = 0;
            this.clbSimulationMods.SelectedIndexChanged += new System.EventHandler(this.clbSimulationMods_SelectedIndexChanged);
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.configurationTile1);
            this.tabConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguration.Size = new System.Drawing.Size(609, 305);
            this.tabConfiguration.TabIndex = 0;
            this.tabConfiguration.Text = "Configuration";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            // 
            // configurationTile1
            // 
            this.configurationTile1.Configuration = null;
            this.configurationTile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configurationTile1.Localization = null;
            this.configurationTile1.Location = new System.Drawing.Point(3, 3);
            this.configurationTile1.Name = "configurationTile1";
            this.configurationTile1.Size = new System.Drawing.Size(603, 299);
            this.configurationTile1.TabIndex = 0;
            // 
            // tabLocalization
            // 
            this.tabLocalization.Location = new System.Drawing.Point(4, 22);
            this.tabLocalization.Name = "tabLocalization";
            this.tabLocalization.Size = new System.Drawing.Size(609, 305);
            this.tabLocalization.TabIndex = 3;
            this.tabLocalization.Text = "Localization";
            this.tabLocalization.UseVisualStyleBackColor = true;
            // 
            // txtSimulationLog
            // 
            this.txtSimulationLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSimulationLog.Location = new System.Drawing.Point(0, 0);
            this.txtSimulationLog.Multiline = true;
            this.txtSimulationLog.Name = "txtSimulationLog";
            this.txtSimulationLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSimulationLog.Size = new System.Drawing.Size(617, 197);
            this.txtSimulationLog.TabIndex = 0;
            this.txtSimulationLog.WordWrap = false;
            // 
            // tabPlayfields
            // 
            this.tabPlayfields.Controls.Add(this.tilePlayfields);
            this.tabPlayfields.Location = new System.Drawing.Point(4, 22);
            this.tabPlayfields.Name = "tabPlayfields";
            this.tabPlayfields.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayfields.Size = new System.Drawing.Size(609, 305);
            this.tabPlayfields.TabIndex = 4;
            this.tabPlayfields.Text = "Playfields";
            this.tabPlayfields.UseVisualStyleBackColor = true;
            // 
            // tilePlayfields
            // 
            this.tilePlayfields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilePlayfields.Location = new System.Drawing.Point(3, 3);
            this.tilePlayfields.Name = "tilePlayfields";
            this.tilePlayfields.Simulation = null;
            this.tilePlayfields.Size = new System.Drawing.Size(603, 299);
            this.tilePlayfields.TabIndex = 0;
            // 
            // formDseTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 556);
            this.Controls.Add(this.splitLog);
            this.Controls.Add(this.menuMain);
            this.Name = "formDseTesting";
            this.Text = "Empyrion DarkCity Extension Testing";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.splitLog.Panel1.ResumeLayout(false);
            this.splitLog.Panel2.ResumeLayout(false);
            this.splitLog.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLog)).EndInit();
            this.splitLog.ResumeLayout(false);
            this.panelTabMain.ResumeLayout(false);
            this.tabSimulation.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelSimulationState.ResumeLayout(false);
            this.panelSimulationSetup.ResumeLayout(false);
            this.panelSimulationSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimulationTickTime)).EndInit();
            this.panelSimulationMods.ResumeLayout(false);
            this.tabConfiguration.ResumeLayout(false);
            this.tabPlayfields.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openConfigurationFile;
        private System.Windows.Forms.OpenFileDialog openLocalizationFile;
        private System.Windows.Forms.ImageList imagesConfigurationObjects;
        private System.Windows.Forms.FolderBrowserDialog folderRootDirectory;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageNotLoaded;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.SplitContainer splitLog;
        private System.Windows.Forms.TabControl panelTabMain;
        private System.Windows.Forms.TabPage tabSimulation;
        private System.Windows.Forms.GroupBox panelSimulationSetup;
        private System.Windows.Forms.Button btnSimulationChooseRootPath;
        private System.Windows.Forms.TextBox txtSimulationRootPath;
        private System.Windows.Forms.Label lblSimulationRootPath;
        private System.Windows.Forms.Label lblSimulationState;
        private System.Windows.Forms.Button btnSimulationCreate;
        private System.Windows.Forms.TabPage tabConfiguration;
        private System.Windows.Forms.TabPage tabLocalization;
        private System.Windows.Forms.TextBox txtSimulationLog;
        private System.Windows.Forms.GroupBox panelSimulationState;
        private DarkCity.Tiles.ConfigurationTile configurationTile1;
        private System.Windows.Forms.Button btnSimulationStop;
        private System.Windows.Forms.Button btnSimulationPause;
        private System.Windows.Forms.Button btnSimulationStart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cboSimulationSaveGame;
        private System.Windows.Forms.Label lblSimulationSaveGame;
        private System.Windows.Forms.NumericUpDown nudSimulationTickTime;
        private System.Windows.Forms.Label lblSimulationTickTime;
        private System.Windows.Forms.GroupBox panelSimulationMods;
        private System.Windows.Forms.Label lblSimulationModDetails;
        private System.Windows.Forms.CheckedListBox clbSimulationMods;
        private System.Windows.Forms.TabPage tabPlayfields;
        private Tiles.PlayfieldSimulationTile tilePlayfields;
    }
}

