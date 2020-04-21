using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace DarkCity.Network
{
    public delegate void ConnectionDelegate(Connection connection);
    public delegate void PacketDelegate(Connection connection, Packet packet);

    public class Connection
    {
        public const int DefaultPort = 0x0dce;

        public event ConnectionDelegate ConnectionClosed;
        public event PacketDelegate PacketReceived;
        public event PacketDelegate PacketSent;

        public TcpClient Client { get; private set; }

        private NetworkStream clientStream;

        protected Thread Processor { get; private set; }

        private bool process = true;

        public DateTime ConnectionTimestamp { get; private set; }

        public Connection(TcpClient client)
        {
            if (client == null)
                throw new ArgumentNullException("socket", "Attempted to create a connection with a null client.");

            this.Client = client;
            this.ConnectionTimestamp = DateTime.Now;
            this.clientStream = this.Client.GetStream();

            this.Processor = new Thread(new ThreadStart(this.Process));
            this.Processor.Name = $"Connection processor for ${this.Client.Client.RemoteEndPoint}";
            this.Processor.IsBackground = true;
            this.Processor.Start();
        }

        public void Close()
        {
            this.process = false;
            this.Client.Close();
            this.Processor.Abort();
        }

        public void Send(Packet packet)
        {
            if (this.Client.Connected)
            {
                packet.Write(this.clientStream);
                if (this.PacketSent != null)
                    this.PacketSent(this, packet);
            }
        }

        protected void Process()
        {
            try
            {
                while (this.process && this.Client.Connected)
                {
                    Packet packet = Packet.Read(this.clientStream);
                    try
                    {
                        if ((this.PacketReceived != null) && (packet != null))
                            this.PacketReceived(this, packet);
                    } catch (Exception ex)
                    {
                        Log.Debug($"Unhandled {ex.GetType().Name} in Connection.PacketReceived event handler. {ex.Message}");
                    }
                }
            }
            catch (ThreadAbortException) { }
            //catch (SocketException) { }
            catch (Exception ex)
            {
                Log.Info($"Unhandled {ex.GetType().Name} in Connection.Process. {ex.Message}");
            }
            finally
            {
                if (this.ConnectionClosed != null)
                    this.ConnectionClosed(this);
            }
        }
    }
}
