using DarkCity.Configuration;
using DarkCity.Network;
using Eleon.Modding;
using System;
using System.IO;
using System.Collections.Generic;
using System.Net;

namespace DarkCity
{
	/// <summary>
	/// The heart of Empyrion mods. This class is instanced by Empyrion and handles direct communication with the game.
	/// </summary>
	public class EmpyrionExtension : IMod, ModInterface
	{
		/// <summary>
		/// Instance of the mod used by Empyrion.
		/// </summary>
		public static EmpyrionExtension Instance = null;

		/// <summary>
		/// Provides access to the EmpyrionApi for use by any classes in the mod.
		/// </summary>
		public static IModApi EmpyrionApi = null;

		/// <summary>
		/// Provides access to the Empyrion legacy API. Used for both dedicated server and clients that are hosts. Best to use <see cref="Server"/> for easier access.
		/// </summary>
		public static ModGameAPI LegacyApi = null;

		/// <summary>
		/// Provides access to the Empyrion game instance. Used for both client and playfield server.
		/// </summary>
		public static IApplication Application = null;

		/// <summary>
		/// Provides access to Empyrion localization strings.
		/// </summary>
		public static Localization Localization = null;

		/// <summary>
		/// Provides access to the Empyrion configuration information.
		/// </summary>
		public static EmpyrionConfiguration Configuration = null;


		/// <summary>
		/// Provides clients with access to the Empyrion API.
		/// </summary>
		public ModServerHost NetworkServerHost = null;

		public GameStateProcessor GameStateProcessor = null;

		/// <summary>
		/// A collection of IPlayfield processors. Key is the name of the playfield.
		/// </summary>
		public Dictionary<string, PlayfieldProcessor> PlayfieldProcessors = new Dictionary<string, PlayfieldProcessor>();

		public static bool LiveLcd { get; private set; } = false;

		/// <summary>
		/// Normally instanced by Empyrion when it wants to load the mod. Which Empyrion processed load the mod is controlled in DarkCityExtensions_Info.yaml
		/// </summary>
		public EmpyrionExtension() { Instance = this; }

        #region "Initialization Methods"

		private void InitializeDedicatedServer()
		{
			Log.Info("Initializing for dedicated server mode.");
		}

		private void InitializePlayfieldServer()
		{
			Log.Info("Initializing for playfield server mode.");

			LiveLcd = true;
		}

		private void InitializeClient()
		{
			Log.Info("Initializing for client mode.");

			//LiveLcd = true;
		}

		private void InitializeSinglePlayer()
		{
			Log.Info("Initializing for single player mode.");

			LiveLcd = true;
		}

        #endregion

        #region "IMod Methods"

        /// <summary>
        /// Called by Empyrion when the mod is first loaded.
        /// </summary>
        /// <param name="modAPI">Provides access to the Empyrion game state.</param>
        public void Init(IModApi modAPI)
		{
			EmpyrionApi = modAPI;
			Application = modAPI.Application;

			Log.LogReceived += Log_LogReceived;

			if (this.NetworkServerHost == null)
			{
				try
				{
					this.NetworkServerHost = new ModServerHost();
					this.NetworkServerHost.Server.BindEndPoints.Add(new IPEndPoint(IPAddress.Loopback, 0x0dce));
					this.NetworkServerHost.Server.Start();
				} catch (Exception ex)
				{
					Log.Warn("Failed to create DCE server. Remote connections will not be possible from client systems. " + ex.Message);
					this.NetworkServerHost = null;
				}
			}

			if (this.GameStateProcessor == null)
			{
				this.GameStateProcessor = new GameStateProcessor();
			}

			Application.OnPlayfieldLoaded += Application_OnPlayfieldLoaded;
			Application.OnPlayfieldUnloading += Application_OnPlayfieldUnloading;

			string contentPath = Application.GetPathFor(AppFolder.Content);
			string localizationPath = Path.Combine(contentPath, @"Extras\Localization.csv");
			string exampleConfigPath = Path.Combine(contentPath, @"Configuration\Config_Example.ecf");
			string customConfigPath = Path.Combine(contentPath, @"Configuration\Config.ecf");

			try
			{
				if (Localization == null) Localization = new Localization(localizationPath);
			} catch (Exception ex)
			{
				Log.Warn($"Failed to load localization file {localizationPath}. {ex.Message}");
			}

			try
			{
				if (Configuration == null)
				{
					Configuration = new EmpyrionConfiguration(exampleConfigPath);
					Log.Info("Loaded default configuration file.");
					try
					{
						Configuration.Load(customConfigPath);
						Log.Info("Loaded custom configuration file.");
					}
					catch { Log.Info("Did not load custom configuration file."); }
				}
			} catch (Exception ex)
			{
				Log.Warn($"Failed to load configuration files from {contentPath}. {ex.Message}");
			}

			try
			{
				switch (Application.Mode)
				{
					case ApplicationMode.Client: this.InitializeClient(); break;
					case ApplicationMode.DedicatedServer: this.InitializeDedicatedServer(); break;
					case ApplicationMode.PlayfieldServer: this.InitializePlayfieldServer(); break;
					case ApplicationMode.SinglePlayer: this.InitializeSinglePlayer(); break;
				}
			} catch (Exception ex)
			{
				Log.Warn($"Failed to initialize for {Application.Mode} mode. Some features of DCE may be impacted. Reason: {ex.Message}");
			}

			Log.Info("Dark City server extension initialization done.");
		}

		private void Log_LogReceived(LogSeverity severity, DateTime timestamp, string message)
		{
			switch (severity)
			{
				case LogSeverity.Critical: EmpyrionApi?.LogError(message); break;
				case LogSeverity.Debug: EmpyrionApi?.Log(message); break;
				case LogSeverity.Info: EmpyrionApi?.Log(message); break;
				case LogSeverity.Warn: EmpyrionApi?.LogWarning(message); break;
			}
		}

		/// <summary>
		/// Called by Empyrion when the mod is being unloaded.
		/// </summary>
		public void Shutdown()
		{
			foreach (PlayfieldProcessor processor in this.PlayfieldProcessors.Values)
			{
				processor.Stop();
			}

			if (this.GameStateProcessor != null)
			{
				this.GameStateProcessor.Stop();
				this.GameStateProcessor = null;
			}

			if (this.NetworkServerHost != null)
			{
				this.NetworkServerHost.Server.Stop();
				this.NetworkServerHost = null;
			}

			Log.Info("Dark City server extension shut down.");
		}

		#endregion

		#region "ModInterface Methods"

		/// <summary>
		/// Called by Empyrion when the mod is loaded.
		/// </summary>
		/// <param name="dediAPI"></param>
		public void Game_Start(ModGameAPI dediAPI)
		{
			LegacyApi = dediAPI;

			if (this.NetworkServerHost == null)
			{
				this.NetworkServerHost = new ModServerHost();
				this.NetworkServerHost.Server.BindEndPoints.Add(new IPEndPoint(IPAddress.Loopback, 0x0dce));
				this.NetworkServerHost.Server.Start();
			}

			if (this.GameStateProcessor == null)
			{
				this.GameStateProcessor = new GameStateProcessor();
			}
		}

		/// <summary>
		/// Called by Empyrion every update tick. Deprecated, recommended to use the Update event in IApplication.
		/// </summary>
		public void Game_Update()
		{

		}

		/// <summary>
		/// Called by Empyrion when the mod is unloaded.
		/// </summary>
		public void Game_Exit()
		{
			try
			{
				if (this.GameStateProcessor != null)
				{
					this.GameStateProcessor.Stop();
					this.GameStateProcessor = null;
				}

				if (this.NetworkServerHost != null)
				{
					this.NetworkServerHost.Server.Stop();
					this.NetworkServerHost = null;
				}
			} catch (Exception ex)
			{
				Log.Warn("Unexpected error when stopping DCE server. " + ex.Message);
			}
		}

		/// <summary>
		/// Called by Empyrion when any game event occurs. This could be in response to a game request we sent.
		/// </summary>
		/// <param name="eventId">ID of the event that triggered this call. See https://empyrion.gamepedia.com/Game_API_CmdId for details. </param>
		/// <param name="seqNr">A sequence number copied from the request that the event is a response to, if applicable. Generally used to filter out events not specifically requested by the mod.</param>
		/// <param name="data">A data structure containing specifics about the event. Must be cast into the right object based on the eventId.</param>
		public void Game_Event(CmdId eventId, ushort seqNr, object data)
		{

		}

        #endregion

        #region "Event Handlers"

        /// <summary>
        /// Handles the OnPlayfieldLoaded event from the game IApplication instance. Passes off the new IPlayfield instance to a PlayfieldProcessor.
        /// </summary>
        /// <param name="playfield">The newly loaded IPlayfield instance.</param>
        private void Application_OnPlayfieldLoaded(IPlayfield playfield)
		{
			try
			{
				if (this.PlayfieldProcessors.ContainsKey(playfield.Name))
				{
					this.PlayfieldProcessors[playfield.Name].Stop();
				}

				this.PlayfieldProcessors[playfield.Name] = new PlayfieldProcessor(playfield);
			} catch (Exception ex)
			{
				Log.Warn($"Failed to create a processor for {playfield.Name}. {ex.Message}");
			}
		}

		/// <summary>
		/// Handles the OnPlayfieldUnloading event from the IApplication instance. Shuts down the PlayfieldProcessor that was handling the IPlayfield instance.
		/// </summary>
		/// <param name="playfield">The IPlayfield instance that is about to be unloaded.</param>
		private void Application_OnPlayfieldUnloading(IPlayfield playfield)
		{
			try
			{
				if (this.PlayfieldProcessors.ContainsKey(playfield.Name))
				{
					this.PlayfieldProcessors[playfield.Name].Stop();
					this.PlayfieldProcessors.Remove(playfield.Name);
				}
			} catch (Exception ex)
			{
				Log.Warn($"Unexpected error when unloading processor for playfield {playfield.Name}. {ex.Message}");
			}
		}

        #endregion
    }
}
