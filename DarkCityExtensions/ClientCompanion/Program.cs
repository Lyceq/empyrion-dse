using ClientCompanion.Properties;
using DarkCity;
using DarkCity.Configuration;
using DarkCity.Network;
using DarkCity.Trackers;
using System;
using System.Windows.Forms;

namespace ClientCompanion
{
    public delegate void PacketHandler<T>(T packet) where T : Packet;

    static class Program
    {
        private static EmpyrionConfiguration configuration = null;
        private static Localization localization = null;

        public static event MethodInvoker EmpyrionConfigurationChanged;
        public static event MethodInvoker LocalizationChanged;

        public static event PacketHandler<RequestPacket> RequestResponseReceived;
        public static event PacketHandler<PlayfieldDataPacket> PlayfieldDataReceived;
        public static event PacketHandler<PlayfieldMapPacket> PlayfieldMapReceived;

        public static Client Network { get; private set; } = new Client();

        public static GameStateTracker GameState { get; private set; } = new GameStateTracker();

        public static EmpyrionConfiguration Configuration => configuration;
        public static Localization Localization => localization;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Network.PacketReceived += Network_PacketReceived;
            GameState.Network = Network;

            LoadSettings();
            ProcessCommandLineArguments();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmClientCompanion());
        }

        static void LoadSettings()
        {
            Network.ReconnectWait = Settings.Default.ReconnectDelay;
        }

        static void ProcessCommandLineArguments()
        {
            try
            {
                string[] args = Environment.GetCommandLineArgs();
                string hostName = null, hostPort = null;
                for (int i = 1; i < args.Length; i++)
                {
                    string cmd = args[i].Trim().ToLower();
                    switch (cmd)
                    {
                        case "h":
                        case "host":
                            hostName = args[++i];
                            break;

                        case "p":
                        case "port":
                            hostPort = args[++i];
                            break;

                        default:
                            throw new ArgumentException("Unknown command line argument: " + args[i]);
                    }
                }

                if (!string.IsNullOrWhiteSpace(hostName))
                    Network.Connect(hostName, string.IsNullOrWhiteSpace(hostPort) ? Connection.DefaultPort : int.Parse(hostPort));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to proccess command line arguments. Reason: " + ex.Message, "Command Line Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadConfiguration(string rootFile)
        {
            LoadConfiguration(rootFile, null);
        }

        public static void LoadConfiguration(string rootFile, string[] customFiles)
        {
            if (rootFile == null) return;

            configuration = new EmpyrionConfiguration(rootFile);
            if (customFiles != null)
            {
                foreach (string file in customFiles)
                    configuration.Load(file);
            }

            if (EmpyrionConfigurationChanged != null) EmpyrionConfigurationChanged();
        }

        public static void LoadLocalization(string path)
        {
            localization = new Localization(path);
            if (LocalizationChanged != null) LocalizationChanged();
        }


        private static void Network_PacketReceived(object client, Packet packet)
        {
            switch (packet.Type)
            {
                case PacketType.Event: break;
                case PacketType.PlayfieldData: if (PlayfieldDataReceived != null) PlayfieldDataReceived(packet as PlayfieldDataPacket); break;
                case PacketType.PlayfieldMap: if (PlayfieldMapReceived != null) PlayfieldMapReceived(packet as PlayfieldMapPacket); break;
                case PacketType.Request: if (RequestResponseReceived != null) RequestResponseReceived(packet as RequestPacket); break;
            }
        }
    }
}
