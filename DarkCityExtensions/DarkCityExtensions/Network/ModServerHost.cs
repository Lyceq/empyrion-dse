using Eleon.Modding;
using DarkCity.Data;

namespace DarkCity.Network
{
    public class ModServerHost
    {
        public Server Server { get; private set; }

        public ModServerHost()
        {
            this.Server = new Server();
            this.Server.PacketReceived += Server_PacketReceived;
        }

        private void Server_PacketReceived(Connection connection, Packet packet)
        {
            if (packet is RequestPacket) this.HandleRequestPacket(connection, (RequestPacket)packet);
        }

        protected virtual void HandleRequestPacket(Connection connection, RequestPacket packet)
        {
            switch (packet.Specification)
            {
                case RequestSpecification.GameState:
                    connection.Send(EmpyrionExtension.Instance.GameStateProcessor.GetCurrentState());
                    break;

                case RequestSpecification.ClientPlayfieldName:
                    string name = EmpyrionExtension.EmpyrionApi?.ClientPlayfield?.Name;
                    if (!string.IsNullOrWhiteSpace(name))
                        connection.Send(new RequestPacket(RequestSpecification.ClientPlayfieldName, name));
                    break;

                case RequestSpecification.PlayfieldData:
                    if (EmpyrionExtension.Instance?.PlayfieldProcessors?.ContainsKey(packet.Specifier) ?? false)
                    {
                        IPlayfield playfield = EmpyrionExtension.Instance?.PlayfieldProcessors?[packet.Specifier]?.Playfield;
                        if (playfield != null)
                            connection.Send(new PlayfieldDataPacket(DataFactory.PlayfieldData(playfield)));
                    }
                    break;

                case RequestSpecification.PlayfieldMap:
                    if (EmpyrionExtension.Instance?.PlayfieldProcessors?.ContainsKey(packet.Specifier) ?? false)
                    {
                        PlayfieldProcessor processor = EmpyrionExtension.Instance?.PlayfieldProcessors?[packet.Specifier];
                        if (processor != null)
                        {
                            if (processor.PlayfieldMap == null)
                                processor.WhenMapReady(map => connection.Send(new PlayfieldMapPacket(map)));
                            else
                                connection.Send(new PlayfieldMapPacket(processor.PlayfieldMap));
                        }
                    }
                    break;
                        
            }
        }
    }
}
