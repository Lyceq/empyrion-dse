using DarkCity.Data;
using System;
using System.IO;

namespace DarkCity.Network
{
    public class PlayfieldMapPacket : Packet
    {
        public override PacketType Type => PacketType.PlayfieldMap;

        public PlayfieldMap Map { get; set; }

        public PlayfieldMapPacket() : base() { }

        public PlayfieldMapPacket(PlayfieldMap map) : this()
        {
            this.Map = map;
        }

        protected override void ReadData(BinaryReader reader)
        {
            string name = reader.ReadString();
            int size = reader.ReadInt32();
            float resolution = reader.ReadSingle();
            int width = reader.ReadInt32();
            int height = reader.ReadInt32();
            float[,] map = new float[width, height];
            for (int z = 0; z < height; z++)
                for (int x = 0; x < width; x++)
                    map[x, z] = reader.ReadSingle();
            
            this.Map = new PlayfieldMap();
            this.Map.Name = name;
            this.Map.SizeClass = size;
            this.Map.Resolution = resolution;
            this.Map.HeightMap = map;
        }

        protected override void WriteData(BinaryWriter writer)
        {
            int width = this.Map.MapWidth;
            int height = this.Map.MapHeight;

            writer.Write(this.Map.Name);
            writer.Write(this.Map.SizeClass);
            writer.Write(this.Map.Resolution);
            writer.Write(width);
            writer.Write(height);
            for (int z = 0; z < height; z++)
                for (int x = 0; x < width; x++)
                    writer.Write(this.Map.HeightMap[x, z]);
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Map}";
        }
    }
}
