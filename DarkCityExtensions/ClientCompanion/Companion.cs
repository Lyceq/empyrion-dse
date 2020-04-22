using DarkCity.Data;
using DarkCity.Tiles;
using DarkCity.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ClientCompanion
{
    public partial class frmClientCompanion : Form
    {
        private LayoutSelection frmLayoutSelection = new LayoutSelection();
        private TileSelection frmTileSelection = new TileSelection();

        protected List<Tile> tiles = new List<Tile>();

        public frmClientCompanion()
        {
            InitializeComponent();

            Program.Network.Connecting += Program_NetworkConnecting;
            Program.Network.ConnectSuccess += Program_NetworkConnected;
            Program.Network.ConnectFailure += Program_NetworkConnectFailure;
            Program.Network.Disconnected += Program_NetworkDisconnected;
            Program.Network.NoMoreReconnects += Program_NetworkNoMoreReconnects;
            Program.GameState.Updated += Program_GameStateUpdated;

            this.frmLayoutSelection.Puppet = this.tileLayout;
            this.frmLayoutSelection.VisibleChanged += (s, x) => this.mainWindowLayouts.Checked = this.frmLayoutSelection.Visible;
            this.frmLayoutSelection.FormClosing += (s, x) =>
            {
                if (x.CloseReason == CloseReason.UserClosing)
                {
                    x.Cancel = true;
                    this.frmLayoutSelection.Visible = false;
                }
            };

            this.frmTileSelection.VisibleChanged += (s, x) => this.mainWindowTiles.Checked = this.frmTileSelection.Visible;
            this.frmTileSelection.FormClosing += (s, x) =>
            {
                if (x.CloseReason == CloseReason.UserClosing)
                {
                    x.Cancel = true;
                    this.frmTileSelection.Visible = false;
                }
            };

            this.UpdateStatus();
        }

        public void DisplayUnexpectedError(string location, Exception ex)
        {
            MessageBox.Show(this,
                $"Unexpected error {ex.GetType()} while {location}. {ex.Message}",
                "Unexpected Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        protected override void OnLoad(EventArgs e)
        {
            this.frmLayoutSelection.UseCustomLayout(1, 1);
        }

        #region Game Status Event Handlers

        public void InvokeUpdateStatus()
        {
            this.Invoke((MethodInvoker)(() => this.UpdateStatus()));
        }

        public void UpdateStatus()
        {
            if (Program.Network.Connected)
            {
                this.statusConnection.Text = $"Connected to {Program.Network.Host}";
                this.mainFileConnectLocal.Enabled = false;
                this.mainFileConnectRemote.Enabled = false;
                this.mainFileDisconnect.Enabled = true;
            }
            else
            {
                if (Program.Network.Reconnecting)
                {
                    this.statusConnection.Text = $"Reconnecting to {Program.Network.Host}...";
                    this.mainFileDisconnect.Enabled = true;
                }
                else
                {
                    this.statusConnection.Text = "Disconnected";
                    this.mainFileDisconnect.Enabled = false;
                }

                this.mainFileConnectLocal.Enabled = true;
                this.mainFileConnectRemote.Enabled = true;
            }

            this.statusGameState.Text = Program.GameState.State.ToString();
            this.statusApplicationMode.Text = Program.GameState.Mode.ToString();
            this.statusLocalPlayer.Text = Program.GameState.LocalPlayerName ?? "<none>";
            this.statusClientPlayfield.Text = Program.GameState.ClientPlayfieldName ?? "<none>";
        }

        private void Program_GameStateUpdated()
        {
            this.InvokeUpdateStatus();
        }

        #endregion

        #region Network Event Handlers

        private void Program_NetworkConnected(Client client)
        {
            this.InvokeUpdateStatus();
        }

        private void Program_NetworkConnecting(Client client)
        {
            this.Invoke((MethodInvoker)(() => {
                this.statusConnection.Text = $"Connecting to {client.Host}...";
                this.mainFileDisconnect.Enabled = true;
            }));
        }

        private void Program_NetworkConnectFailure(Client client)
        {
            this.InvokeUpdateStatus();
        }

        private void Program_NetworkDisconnected(Client client)
        {
            this.InvokeUpdateStatus();
        }

        private void Program_NetworkNoMoreReconnects(Client client)
        {
            this.InvokeUpdateStatus();
        }

        #endregion

        #region File Menu Event Handlers

        private void mainFileConnectLocal_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Network.Host = new IPEndPoint(IPAddress.Loopback, Connection.DefaultPort);
                Program.Network.Connect();
            } catch (Exception ex)
            {
                this.DisplayUnexpectedError("connected to local game", ex);
            }
        }

        private void mainFileConnectRemote_Click(object sender, EventArgs e)
        {
            try
            {
                OpenRemoteHost dialog = new OpenRemoteHost();
                DialogResult result = dialog.ShowDialog(this);
                if (result == DialogResult.Cancel) return;
                Program.Network.Host = new IPEndPoint(dialog.Address, dialog.Port);
                try
                {
                    Program.Network.Connect();
                } catch (Exception ex)
                {
                    this.DisplayUnexpectedError("opening connection to remote host", ex);
                }
            }
            catch (Exception ex)
            {
                this.DisplayUnexpectedError("connecting to remote host", ex);
            }
        }

        private void mainFileDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Network.Disconnect();
                this.UpdateStatus();
            }
            catch (Exception ex)
            {
                this.DisplayUnexpectedError("disconnecting", ex);
            }
        }

        private void mainFileOpenConfiguration_Click(object sender, EventArgs e)
        {
            OpenConfigurationFiles openConfigurationFiles = new OpenConfigurationFiles();
            DialogResult result = openConfigurationFiles.ShowDialog(this);
            if (result == DialogResult.Cancel) return;

            try
            {
                Program.LoadConfiguration(openConfigurationFiles.ExampleFile, openConfigurationFiles.CustomFiles);
            }
            catch (Exception ex)
            {
                this.DisplayUnexpectedError("loading configuration file(s)", ex);
            }
        }

        private void mainFileOpenLocalization_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openLocalizationFile.ShowDialog(this);
            if (result == DialogResult.Cancel) return;

            try
            {
                Program.LoadLocalization(this.openLocalizationFile.FileName);
            }
            catch (Exception ex)
            {
                this.DisplayUnexpectedError("loading localization file", ex);
            }
        }

        private void mainFileExit_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Network.Disconnect();
            }
            catch { }

            this.Close();
        }

        #endregion

        #region Language Menu Event Handlers

        private void mainLanguageSelect_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Window Menu Event Handlers

        private void mainWindowFullscreen_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.mainWindowFullscreen.Checked = true;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.mainWindowFullscreen.Checked = false;
            }
        }

        private void mainWindowLayouts_Click(object sender, EventArgs e)
        {
            if (this.mainWindowLayouts.Checked)
            {
                this.frmLayoutSelection.Hide();
                this.mainWindowLayouts.Checked = false;
            } else
            {
                this.frmLayoutSelection.Show(this);
                this.mainWindowLayouts.Checked = true;
            }
        }

        private void mainWindowTiles_Click(object sender, EventArgs e)
        {
            if (this.mainWindowTiles.Checked)
            {
                this.frmTileSelection.Hide();
                this.mainWindowTiles.Checked = false;
            } else
            {
                this.frmTileSelection.Show(this);
                this.mainWindowTiles.Checked = true;
            }
        }

        private void mainWindowSaveLayout_Click(object sender, EventArgs e)
        {
            // TODO: Save a layout to disk.
        }

        private void mainWindowLoadLayout_Click(object sender, EventArgs e)
        {
            // TODO: Load a layout from disk.
        }

        private void mainWindowLayoutsSaved_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem layout = sender as ToolStripMenuItem;
            if (layout == null) return;

            // TODO: Restore selected layout.
        }

        #endregion

    }
}
