using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace DarkCity.Network
{
    public delegate void ClientEventHandler(Client sender);
    public delegate void ClientPacketEventHandler(Client sender, Packet packet);
    public delegate void ClientExceptionEventHandler(Client sender, Exception ex, Packet packet);

    public class Client
    {
        private Connection connection;
        private int reconnectFailures = 0;
        private Queue<Packet> failedPackets = new Queue<Packet>();

        public event ClientEventHandler Connecting;
        public event ClientEventHandler ConnectSuccess;
        public event ClientEventHandler ConnectFailure;
        public event ClientEventHandler Disconnected;
        public event ClientEventHandler NoMoreReconnects;
        public event ClientPacketEventHandler PacketReceived;
        public event ClientExceptionEventHandler PacketHandlerException;

        public bool Connected => this.connection?.Client?.Connected ?? false;

        public IPEndPoint Host { get; set; }

        public bool Reconnecting { get; private set; }

        public int ReconnectAttempts { get; set; } = 3;

        public int ReconnectAttemptsRemaining => Math.Max(0, this.ReconnectAttempts - this.reconnectFailures);

        public TimeSpan ReconnectWait { get; set; } = TimeSpan.FromSeconds(30);

        public Client() { }

        protected void PackageConnection(TcpClient client)
        {
            this.Reconnecting = false;
            this.connection = new Connection(client);
            this.connection.ConnectionClosed += Connection_ConnectionClosed;
            this.connection.PacketReceived += Connection_Verify;
            this.connection.Send(new ConnectionStatePacket(ConnectionStatePacket.ConnectionState.Establish, Server.Version));
        }

        public void Connect()
        {
            if (this.Host == null)
            {
                if (this.ConnectFailure != null) this.ConnectFailure(this);
                return;
            }

            if (this.connection != null)
                this.Disconnect();

            try
            {
                if (this.Connecting != null) this.Connecting(this);

                TcpClient client = new TcpClient();
                client.Connect(this.Host);
                this.PackageConnection(client);
            }
            catch
            {
                if (this.ConnectFailure != null) this.ConnectFailure(this);
                this.Reconnect();
            }
        }

        public void Connect(IPEndPoint host)
        {
            this.Host = host;
            this.Connect();
        }

        public void Connect(IPAddress host, int port)
        {
            this.Host = new IPEndPoint(host, port);
            this.Connect();
        }

        public void Connect(string host, int port)
        {
            try
            {
                IPAddress[] addresses = Dns.GetHostAddresses(host);
                this.Connect(addresses[0], port);
            } catch
            {
                if (this.ConnectFailure != null) this.ConnectFailure(this);
            }
        }

        public void Disconnect()
        {
            if (this.connection?.Client?.Connected ?? false)
            {
                try
                {
                    this.connection.Client.Close();
                } catch { }
                finally {
                    if (this.Disconnected != null) this.Disconnected(this);
                }
            }

            this.connection = null;
            this.Reconnecting = false;
            this.reconnectFailures = this.ReconnectAttempts;
        }

        protected void Reconnect()
        {
            if (this.Connected) return;

            this.connection = null;
            this.reconnectFailures = 0;
            this.Reconnecting = true;

            Action reconnecting = null;
            reconnecting = () =>
            {
                try
                {
                    if (this.Connecting != null) this.Connecting(this);

                    TcpClient client = new TcpClient();
                    client.Connect(this.Host);
                    this.PackageConnection(client);
                }
                catch
                {
                    if (++this.reconnectFailures < this.ReconnectAttempts)
                    {
                        if (this.ConnectFailure != null) this.ConnectFailure(this);

                        Thread.Sleep(this.ReconnectWait);
                        Task.Run(reconnecting);
                    }
                    else
                    {
                        this.Reconnecting = false;

                        if (this.ConnectFailure != null) this.ConnectFailure(this);
                        if (this.NoMoreReconnects != null) this.NoMoreReconnects(this);
                    }
                }
            };

            Task.Run(reconnecting);
        }

        public void Send(Packet packet)
        {
            if (!this.Connected)
            {
                if (this.ReconnectAttemptsRemaining > 0)
                    this.failedPackets.Enqueue(packet);

                if (this.connection != null)
                    this.Reconnect();
            } else
            {
                try
                {
                    this.connection.Send(packet);
                } catch
                {
                    this.failedPackets.Enqueue(packet);
                    this.Reconnect();
                }
            }
        }

        private void Connection_Verify(Connection connection, Packet packet)
        {
            ConnectionStatePacket state = packet as ConnectionStatePacket;
            if (state?.State == ConnectionStatePacket.ConnectionState.Accepted)
            {
                connection.PacketReceived -= this.Connection_Verify;
                connection.PacketReceived += this.Connection_PacketReceived;
                if (this.ConnectSuccess != null) this.ConnectSuccess(this);

                // Retry failed packets.
                foreach (Packet retry in this.failedPackets)
                    this.Send(retry);
            }
            else
            {
                try
                {
                    connection.Close();
                    if (this.ConnectFailure != null)
                        this.ConnectFailure(this);
                }
                catch { }
            }
        }

        private void Connection_PacketReceived(Connection connection, Packet packet)
        {
            try
            {
                if (this.PacketReceived != null)
                    this.PacketReceived(this, packet);
            } catch (Exception ex)
            {
                if (this.PacketHandlerException != null)
                    this.PacketHandlerException(this, ex, packet);
            }
        }

        private void Connection_ConnectionClosed(Connection connection)
        {
            this.connection = null;
            this.Reconnect();
        }
    }
}
