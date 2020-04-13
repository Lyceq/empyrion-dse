using System;
using System.IO;

namespace DarkCity.Network
{
    public class ConnectionStatePacket : Packet
    {
        public enum ConnectionState
        {
            Establish,
            Accepted,
            Rejected
        }

        public override PacketType Type => PacketType.ConnectionState;

        /// <summary>
        /// Gets or sets the state of the connection. See <see cref="ConnectionState"/> for possible values.
        /// </summary>
        public ConnectionState State { get; set; }

        /// <summary>
        /// Gets or sets the version of the connection. This can have different meanings depending on the state.
        ///   Establish: This is the version number of the client.
        ///   Accepted: This is the version number of the server.
        ///   Rejected: This is the minimum version number the client must have for the connection to be accepted.
        /// </summary>
        public int Version { get; set; }

        public ConnectionStatePacket() { }

        public ConnectionStatePacket(ConnectionState state, int version)
        {
            this.State = state;
            this.Version = version;
        }

        public bool Verify(int desiredVersion)
        {
            return (this.State == ConnectionState.Establish) && (this.Version == desiredVersion);
        }

        protected override void ReadData(BinaryReader reader)
        {
            this.State = (ConnectionState)reader.ReadInt32();
            this.Version = reader.ReadInt32();
        }

        protected override void WriteData(BinaryWriter writer)
        {
            writer.Write((Int32)this.State);
            writer.Write(this.Version);
        }

        public override string ToString()
        {
            return $"ConnectionState {this.State} Version: {this.Version}";
        }
    }
}
