using System;
using System.IO;

namespace DarkCity.Network
{
    public class RequestPacket : Packet
    {
        /// <summary>
        /// Specification of what a network request is for.
        /// </summary>
        public enum RequestSpecification
        {
            /// <summary>
            /// Requests playfield data. Set Specifier to the playfield name. Response will be a <see cref="PlayfieldDataPacket"/>.
            /// </summary>
            PlayfieldData = 1,

            /// <summary>
            /// Requests the name of the client's playfield. Response will be a <see cref="RequestPacket"/> with same specification and specifier set to the playfield name.
            /// </summary>
            ClientPlayfieldName = 2,

            /// <summary>
            /// Requests a height map of a playfield. Response will be a <see cref="PlayfieldMapPacket"/> if the requested playfield is planet or moon type.
            /// </summary>
            PlayfieldMap = 3
        }

        public override PacketType Type => PacketType.Request;

        /// <summary>
        /// Specification of what the request is for. Controls the meaning of <see cref="Specifier"/>.
        /// </summary>
        public RequestSpecification Specification { get; set; }

        /// <summary>
        /// Specifies what the request is about.
        ///   PlayfieldData: The name of the playfield. Response will be a <see cref="PlayfieldDataPacket"/>.
        /// </summary>
        public string Specifier { get; set; }

        public RequestPacket() { }

        public RequestPacket(RequestSpecification specification, string specifier)
        {
            this.Specification = specification;
            this.Specifier = specifier;
        }

        protected override void ReadData(BinaryReader reader)
        {
            this.Specification = (RequestSpecification)reader.ReadInt32();
            this.Specifier = reader.ReadString();
        }

        protected override void WriteData(BinaryWriter writer)
        {
            writer.Write((Int32)this.Specification);
            writer.Write(this.Specifier ?? "");
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Specification} {this.Specifier}";
        }

    }
}
