using System;
using System.IO;

namespace DarkCity.Network
{
    public enum EmpyrionGameState
    {
        NotRunning = 0,
        Loading = 1,
        Running = 2
    }

    public enum EmpyrionApplicationMode
    {
        SinglePlayer = 0,
        Client = 1,
        DedicatedServer = 2,
        PlayfieldServer = 3
    }

    public class EmpyrionStatePacket : Packet, IEquatable<EmpyrionStatePacket>
    {
        public EmpyrionGameState State { get; set; }
        public EmpyrionApplicationMode Mode { get; set; }
        public string LocalPlayerName { get; set; }
        public string ClientPlayfieldName { get; set; }

        public override PacketType Type => PacketType.EmpyrionState;

        protected override void ReadData(BinaryReader reader)
        {
            this.State = (EmpyrionGameState)reader.ReadByte();
            this.Mode = (EmpyrionApplicationMode)reader.ReadByte();
            this.LocalPlayerName = reader.ReadString();
            this.ClientPlayfieldName = reader.ReadString();
        }

        protected override void WriteData(BinaryWriter writer)
        {
            writer.Write((byte)this.State);
            writer.Write((byte)this.Mode);
            writer.Write(this.LocalPlayerName ?? "");
            writer.Write(this.ClientPlayfieldName ?? "");
        }

        public bool Equals(EmpyrionStatePacket other)
        {
            if (other == null) return false;
            return
                (this.State == other.State) &&
                (this.Mode == other.Mode) &&
                (this.LocalPlayerName == other.LocalPlayerName) &&
                (this.ClientPlayfieldName == other.ClientPlayfieldName);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as EmpyrionStatePacket);
        }

        public override int GetHashCode()
        {
            return
                this.State.GetHashCode() |
                this.Mode.GetHashCode() |
                this.LocalPlayerName.GetHashCode() |
                this.ClientPlayfieldName.GetHashCode();
        }
    }
}
