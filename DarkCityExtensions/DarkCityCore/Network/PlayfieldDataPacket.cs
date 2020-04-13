using DarkCity.Data;
using System;
using System.IO;

namespace DarkCity.Network
{
    public class PlayfieldDataPacket : Packet
    {
        public PlayfieldData Playfield { get; set; }

        public override PacketType Type => PacketType.PlayfieldData;

        public PlayfieldDataPacket() { }

        public PlayfieldDataPacket(PlayfieldData playfield)
        {
            this.Playfield = playfield;
        }

        protected override void ReadData(BinaryReader reader)
        {
            this.Playfield = reader.ReadPlayfieldData();
        }

        protected override void WriteData(BinaryWriter writer)
        {
            writer.Write(this.Playfield);
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Playfield}";
        }
    }
}
