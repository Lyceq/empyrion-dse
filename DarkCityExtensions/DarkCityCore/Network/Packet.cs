using System;
using System.IO;
using System.Text;

namespace DarkCity.Network
{
    public abstract class Packet
    {
        public abstract PacketType Type { get; }

        protected abstract void WriteData(BinaryWriter writer);

        protected abstract void ReadData(BinaryReader reader);

        public void Write(Stream stream)
        {
            BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8);
            writer.Write((Int32)this.Type);
            this.WriteData(writer);
        }

        public static Packet Read(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            PacketType type = (PacketType)reader.ReadInt32();
            Packet packet = null;
            switch (type)
            {
                case PacketType.ConnectionState: packet = new ConnectionStatePacket(); break;
                case PacketType.Request: packet = new RequestPacket(); break;
                case PacketType.Event: break;
                case PacketType.PlayfieldData: packet = new PlayfieldDataPacket(); break;
                case PacketType.PlayfieldMap: packet = new PlayfieldMapPacket(); break;
                default: throw new Exception("Invalid packet type received.");
            }

            if (packet == null) return null;
            packet.ReadData(reader);
            return packet;
        }

        public override string ToString()
        {
            return this.Type.ToString();
        }
    }
}
