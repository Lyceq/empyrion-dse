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
        public IPEndPoint host = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0x0dce);
        public Connection client;

        protected List<Tile> tiles = new List<Tile>();

        public frmClientCompanion()
        {
            InitializeComponent();

            try
            {
                string[] args = Environment.GetCommandLineArgs();
                string hostName = null, hostPort = null;
                for (int i = 1; i < args.Length; i++)
                {
                    string cmd = args[i].Trim().ToLower();
                    switch (cmd)
                    {
                        case "h":
                        case "host":
                            hostName = args[++i];
                            break;

                        case "p":
                        case "port":
                            hostPort = args[++i];
                            break;

                        default:
                            throw new ArgumentException("Unknown command line argument: " + args[i]);
                    }
                }

                if (!string.IsNullOrWhiteSpace(hostName))
                {
                    IPAddress[] addresses = Dns.GetHostAddresses(hostName);
                    this.host = new IPEndPoint(addresses[0], string.IsNullOrWhiteSpace(hostPort) ? 0x0dce : int.Parse(hostPort));
                    this.Connect(this.host);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to proccess command line arguments. Reason: " + ex.Message, "Command Line Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void Connect(IPEndPoint host)
        {
            if (this.client != null)
                this.client.Close();

            this.statusConnection.Text = "Connecting to " + host.ToString();
            this.Update();

            try
            {
                TcpClient tcp = new TcpClient();
                tcp.Connect(host);
                this.client = new Connection(tcp);
                this.client.ConnectionClosed += Client_ConnectionClosed;
                this.client.PacketReceived += Client_VerifyConnection;
                this.client.Send(new ConnectionStatePacket(ConnectionStatePacket.ConnectionState.Establish, Server.Version));
            } catch
            {
                this.statusConnection.Text = "Failed to connect to " + host.ToString();
            }
        }

        private void Client_ConnectionClosed(Connection connection)
        {
            this.client = null;
            this.Invoke((MethodInvoker)(() =>
            {
                this.statusConnection.Text = "Disconnected";
                //MessageBox.Show("Connection to host has closed.", "Connection Closed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }));
        }

        private void Client_VerifyConnection(Connection connection, Packet packet)
        {
            if (packet is ConnectionStatePacket)
            {
                ConnectionStatePacket state = (ConnectionStatePacket)packet;
                if (state.State == ConnectionStatePacket.ConnectionState.Accepted)
                {
                    connection.PacketReceived -= Client_VerifyConnection;
                    connection.PacketReceived += Connection_PacketReceived;
                    foreach (Tile tile in this.tiles)
                        tile.Network = connection;
                    connection.Send(new RequestPacket(RequestPacket.RequestSpecification.ClientPlayfieldName, null));

                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.statusConnection.Text = "Connected to " + connection.Client.Client.RemoteEndPoint.ToString();
                        PlayfieldMapTile mapTile = new PlayfieldMapTile(connection);
                        this.tiles.Add(mapTile);
                        this.panelTiles.Controls.Add(mapTile);
                        mapTile.Dock = DockStyle.Fill;
                    }));
                } else
                {
                    this.Invoke((MethodInvoker)(() => 
                    {
                        this.statusConnection.Text = "Disconnected";
                        MessageBox.Show($"The host rejected the connection because of a version mismatch. Minimum protocol version required: {state.Version}.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.client = null;
                    }));
                }
            } else
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    this.statusConnection.Text = "Disconnected";
                    MessageBox.Show("A connection was established with the host, but it does not appear to be coherent.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.client = null;
                }));
            }
        }

        private void Connection_PacketReceived(Connection connection, Packet packet)
        {
            
        }

        private void mainFileConnectLocal_Click(object sender, EventArgs e)
        {
            this.Connect(new IPEndPoint(IPAddress.Loopback, 0x0dce));
        }

        private void mainFileConnectRemote_Click(object sender, EventArgs e)
        {

        }

        private void mainFileDisconnect_Click(object sender, EventArgs e)
        {
            this.host = null;
            if (this.client != null)
                this.client.Close();
        }

        private void mainFileOpenConfiguration_Click(object sender, EventArgs e)
        {

        }

        private void mainFileOpenLocalization_Click(object sender, EventArgs e)
        {

        }

        private void mainFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainLayout1Tile_Click(object sender, EventArgs e)
        {

        }

        private void mainLayout2x1Tiles_Click(object sender, EventArgs e)
        {

        }

        private void mainLayout2x2Tiles_Click(object sender, EventArgs e)
        {

        }

        private void mainLanguageSelect_Click(object sender, EventArgs e)
        {

        }

        private void mainHelpAbout_Click(object sender, EventArgs e)
        {

        }

        private void timerRequestData_Tick(object sender, EventArgs e)
        {
            if (this.client == null)
            {
                if (this.host != null)
                {
                    // Attempt reconnection.
                    this.Connect(this.host);
                }
            }
            else
            {
                // Request up-to-date information.
                //this.client.Send(new RequestPacket(RequestPacket.RequestSpecification.ClientPlayfieldName, null));
            }
        }
    }
}
