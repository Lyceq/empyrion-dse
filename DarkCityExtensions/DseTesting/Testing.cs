using DarkCity;
using DarkCity.Simulation;
using DarkCity.Testing.Properties;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DarkCity.Testing
{
    public partial class formDseTesting : Form
    {
        public SimulationHost Simulation { get; private set; }

        public formDseTesting()
        {
            InitializeComponent();

            Log.LogReceived += Log_LogReceived;

            this.txtSimulationRootPath.Text = Settings.Default.EmpyrionRootPath;
            this.nudSimulationTickTime.Value = Settings.Default.TickTime;

            this.UpdateSimulationTabState();
        }

        private void Log_LogReceived(LogSeverity severity, DateTime timestamp, string message)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                this.txtSimulationLog.AppendText($"{timestamp} - {severity} - {message}{Environment.NewLine}");
            }));
        }

        public void UpdateLanguageMenu()
        {
            // Update language menu items.
            if (this.Simulation.Localization == null)
            {
                // Clear language menu.
                foreach (ToolStripMenuItem item in this.menuLanguage.DropDownItems)
                {
                    if (item == menuLanguageNotLoaded)
                        item.Visible = true;
                    else
                        this.menuLanguage.DropDownItems.Remove(item);
                }
            }
            else
            {
                // Create menu items for each language.
                this.menuLanguage.DropDownItems.Clear();
                this.menuLanguage.DropDownItems.Add(this.menuLanguageNotLoaded);
                this.menuLanguageNotLoaded.Visible = false;

                foreach (string language in this.Simulation.Localization.Languages)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(language, null, new EventHandler(menuLanguageLocalized_Click));
                    item.Name = "menuLangugae" + language;
                    item.Tag = language;
                    item.Checked = (language == this.Simulation.Localization.SelectedLanguageName);
                    this.menuLanguage.DropDownItems.Add(item);
                }
            }
        }

        public void UpdateSimulationTabState()
        {
            if (this.Simulation == null)
            {
                this.btnSimulationCreate.Enabled = true;
                this.btnSimulationStart.Enabled = false;
                this.btnSimulationPause.Enabled = false;
                this.btnSimulationStop.Enabled = false;
                this.txtSimulationRootPath.Enabled = true;
                this.btnSimulationChooseRootPath.Enabled = true;
                this.cboSimulationSaveGame.Enabled = false;
                this.clbSimulationMods.Enabled = false;
            } else
            {
                this.btnSimulationCreate.Enabled = false;
                this.txtSimulationRootPath.Enabled = false;
                this.btnSimulationChooseRootPath.Enabled = false;

                switch (this.Simulation.State)
                {
                    case SimulationState.Stopped:
                        this.btnSimulationStart.Enabled = true;
                        this.btnSimulationPause.Enabled = false;
                        this.btnSimulationStop.Enabled = false;
                        this.cboSimulationSaveGame.Enabled = true;
                        this.clbSimulationMods.Enabled = true;
                        break;

                    case SimulationState.Running:
                        this.btnSimulationStart.Enabled = false;
                        this.btnSimulationPause.Enabled = true;
                        this.btnSimulationStop.Enabled = true;
                        this.cboSimulationSaveGame.Enabled = false;
                        this.clbSimulationMods.Enabled = false;
                        break;

                    case SimulationState.Paused:
                        this.btnSimulationStart.Enabled = true;
                        this.btnSimulationPause.Enabled = false;
                        this.btnSimulationStop.Enabled = true;
                        this.cboSimulationSaveGame.Enabled = false;
                        this.clbSimulationMods.Enabled = false;
                        break;
                }
            }
        }

        private void menuLanguageLocalized_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                string language = (string)((ToolStripMenuItem)(sender)).Tag;
                this.Simulation.Localization.SelectLanguage(language);
                Settings.Default.LocalizationLanguage = language;
                Settings.Default.Save();
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IModApi_LogEntry(LogSeverity severity, DateTime timestamp, string message)
        {
            this.txtSimulationLog.AppendText($"{timestamp} - {severity} - {message}{Environment.NewLine}");
            Application.DoEvents();
        }

        private void btnSimulationChooseRootPath_Click(object sender, EventArgs e)
        {
            this.folderRootDirectory.SelectedPath = this.txtSimulationRootPath.Text;
            DialogResult result = this.folderRootDirectory.ShowDialog();
            if (result == DialogResult.Cancel) return;
            this.txtSimulationRootPath.Text = this.folderRootDirectory.SelectedPath;
        }

        private void txtSimulationRootPath_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.EmpyrionRootPath = this.txtSimulationRootPath.Text;
            Settings.Default.Save();
        }

        private void btnSimulationCreate_Click(object sender, EventArgs e)
        {
            Log.Info("Creating simulation host.");

            try
            {
                this.Simulation = new SimulationHost(this.txtSimulationRootPath.Text);
                this.Simulation.TickTime = new TimeSpan(0, 0, 0, 0, (int)this.nudSimulationTickTime.Value);
                this.Simulation.StateChanged += Simulation_StateChanged;

                Settings.Default.EmpyrionRootPath = this.txtSimulationRootPath.Text;
                Settings.Default.TickTime = (int)this.nudSimulationTickTime.Value;
                Settings.Default.Save();
            } catch (Exception ex)
            {
                Log.Critical("Failed to create a simulation host. " + ex.Message);
                return;
            }

            this.lblSimulationState.Text = "Stopped";

            DirectoryInfo saveDir = new DirectoryInfo(this.Simulation.IApplication.GetPathFor(Eleon.Modding.AppFolder.SaveGame));
            this.cboSimulationSaveGame.Items.Clear();
            if (saveDir.Exists) this.cboSimulationSaveGame.Items.AddRange(saveDir.GetDirectories());

            this.clbSimulationMods.Items.Clear();
            this.clbSimulationMods.Items.AddRange(this.Simulation.Mods.Values.ToArray());
            for (int i = 0; i < this.clbSimulationMods.Items.Count; i++)
                this.clbSimulationMods.SetItemChecked(i, string.IsNullOrEmpty((this.clbSimulationMods.Items[i] as ModDetails)?.LoadError));

            this.tilePlayfields.Simulation = this.Simulation;

            this.UpdateSimulationTabState();

            Log.Info("Simulation host is ready.");
        }

        private void Simulation_StateChanged(object sender, SimulationState e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                this.lblSimulationState.Text = e.ToString();
            }));
        }

        private void btnSimulationStart_Click(object sender, EventArgs e)
        {
            this.Simulation?.Start();
            this.UpdateSimulationTabState();
        }

        private void btnSimulationPause_Click(object sender, EventArgs e)
        {
            this.Simulation?.Pause();
            this.UpdateSimulationTabState();
        }

        private void btnSimulationStop_Click(object sender, EventArgs e)
        {
            this.Simulation?.Stop();
            this.UpdateSimulationTabState();
        }

        private void nudSimulationTickTime_ValueChanged(object sender, EventArgs e)
        {
            if (this.Simulation != null) this.Simulation.TickTime = new TimeSpan(0, 0, 0, 0, (int)this.nudSimulationTickTime.Value);
        }

        private void clbSimulationMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModDetails mod = this.clbSimulationMods.SelectedItem as ModDetails;
            if (mod == null)
            {
                this.lblSimulationModDetails.Text = "";
            } else
            {
                this.lblSimulationModDetails.Text = mod.ToString();
            }
        }
    }
}
