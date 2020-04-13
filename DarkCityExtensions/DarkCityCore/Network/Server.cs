using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace DarkCity.Network
{
    public class Server
    {
        public const int Version = 1;

        private List<Thread> listeners;

        public event ConnectionDelegate ClientConnected;
        public event ConnectionDelegate ClientDisconnected;
        public event PacketDelegate PacketReceived;

        public ConcurrentDictionary<int, Connection> Clients { get; private set; } = new ConcurrentDictionary<int, Connection>();

        public bool Processing { get; private set; }

        public List<EndPoint> BindEndPoints { get; private set; }

        public Server()
        {
            this.BindEndPoints = new List<EndPoint>(1);
        }

        public void Start()
        {
            if (this.Processing) return;
            this.Processing = true;

            // Start socket listener for each binding end point.
            this.listeners = new List<Thread>(this.BindEndPoints.Count);
            foreach (EndPoint binding in this.BindEndPoints)
            {
                Thread listener = new Thread(Listen);
                listener.Name = "DCE server listening on " + binding.ToString();
                listener.IsBackground = true;
                listener.Start(binding);
                this.listeners.Add(listener);
            }

        }

        public void Stop()
        {
            if (!this.Processing) return;
            this.Processing = false;

            foreach (Thread listener in this.listeners)
                listener.Abort();
            this.listeners.Clear();
        }

        protected void Listen(object binding)
        {
            TcpListener listener = null;
            TcpClient client;
            Connection connection;

            while (this.Processing)
            {
                try
                {
                    listener = new TcpListener((IPEndPoint)binding);
                    listener.Start();

                    while (this.Processing)
                    {
                        // Accept a new client.
                        if (listener.Pending())
                        {
                            client = listener.AcceptTcpClient();
                            connection = new Connection(client);
                            this.Clients[connection.GetHashCode()] = connection; // Yeah, don't use a hash as the key. But I don't need the key and there isn't a ConcurrentList.
                            connection.ConnectionClosed += Connection_ConnectionClosed;
                            connection.PacketReceived += HandleConnectionRequest;

                            try
                            {
                                if (this.ClientConnected != null)
                                    this.ClientConnected(connection);
                            } catch (Exception ex)
                            {
                                Log.Warn($"Unhangled {ex.GetType().Name} in Server.ClientConnected event handler. {ex.Message}");
                            }
                        } else
                        {
                            Thread.Sleep(200);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is ThreadAbortException) return;
                    Log.Critical($"Unexpected {ex.GetType().Name} in server listener.{Environment.NewLine}Message: {ex.Message}{Environment.NewLine}Stack Trace: {ex.StackTrace}");
                    if (listener != null)
                    {
                        try
                        {
                            listener.Stop();
                            listener = null;
                        }
                        catch { }
                    }
                    Thread.Sleep(500);
                }
            }
        }

        public void Broadcast(Packet packet)
        {
            foreach (Connection client in this.Clients.Values)
                client.Send(packet);
        }

        protected virtual void HandleConnectionRequest(Connection connection, Packet packet)
        {
            if (packet is ConnectionStatePacket)
            {
                ConnectionStatePacket state = (ConnectionStatePacket)packet;
                if (state.Verify(Version))
                {
                    // Client is attempting to establish a connection with the correct version.
                    connection.PacketReceived -= HandleConnectionRequest;
                    connection.PacketReceived += Connection_PacketReceived;
                    connection.Send(new ConnectionStatePacket(ConnectionStatePacket.ConnectionState.Accepted, Version));
                }
                else
                {
                    // Client is using an unsupported version.
                    connection.Send(new ConnectionStatePacket(ConnectionStatePacket.ConnectionState.Rejected, Version));
                    connection.Close();
                }
            }
            else
            {
                // Unexpected communication, client must be invalid.
                connection.Close();
            }
        }

        protected virtual void Connection_PacketReceived(Connection connection, Packet packet)
        {
            try
            {
                if (this.PacketReceived != null)
                    this.PacketReceived(connection, packet);
            } catch (Exception ex)
            {
                Log.Warn($"Unhandled {ex.GetType().Name} in Server.PacketReceived event handler. {ex.Message}");
            }
        }

        private void Connection_ConnectionClosed(Connection connection)
        {
            int? key = null;
            foreach (KeyValuePair<int, Connection> client in this.Clients)
            {
                if (client.Value == connection)
                {
                    key = client.Key;
                    break;
                }
            }

            if (key != null)
                this.Clients.TryRemove(key ?? 0, out connection);

            try
            {
                if (this.ClientDisconnected != null)
                    this.ClientDisconnected(connection);
            } catch (Exception ex)
            {
                Log.Warn($"Unhandled {ex.GetType().Name} in Server.ClientDisconnected event handler. {ex.Message}");
            }
        }

    }
}
