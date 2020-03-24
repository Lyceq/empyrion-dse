﻿using Eleon.Modding;
using System.Collections.Generic;

namespace DarkCity
{
	/// <summary>
	/// The heart of Empyrion mods. This class is instanced by Empyrion and handles direct communication with the game.
	/// </summary>
	public class DarkCity : IMod, ModInterface
	{
		/// <summary>
		/// Provides access to the EmpyrionApi for use by any classes in the mod.
		/// </summary>
		public static IModApi EmpyrionApi;

		/// <summary>
		/// Provides access to the Empyrion legacy API. Normally used only for interacting with dedicated servers (not clients or playfield servers).
		/// </summary>
		public static ModGameAPI LegacyApi;

		/// <summary>
		/// Provides access to the Empyrion game instance.
		/// </summary>
		public static IApplication Application;

		/// <summary>
		/// A collection of IPlayfield processors. Key is the name of the playfield.
		/// </summary>
		public Dictionary<string, PlayfieldProcessor> PlayfieldProcessors = new Dictionary<string, PlayfieldProcessor>();

		/// <summary>
		/// Normally instanced by Empyrion when it wants to load the mod. Which Empyrion processed load the mod is controlled in DarkCityExtensions_Info.yaml
		/// </summary>
		public DarkCity() { }

        #region "Log Methods"

        /// <summary>
        /// Logs an error with Empyrion. Appears in the log for whichever Empyrion process owns this instance of the mod.
        /// </summary>
        /// <param name="message">Message appended to the log.</param>
        public static void LogError(string message)
		{
			EmpyrionApi.LogError(message);
		}

		/// <summary>
		/// Logs a warning with Empyrion. Appears in the log for whichever Empyrion process owns this instance of the mod.
		/// </summary>
		/// <param name="message">Message appended to the log.</param>
		public static void LogWarn(string message)
		{
			EmpyrionApi.LogWarning(message);
		}

		/// <summary>
		/// Logs an informational message with Empyrion. Appears in the log for whichever Empyrion process owns this instance of the mod.
		/// </summary>
		/// <param name="message">Message appended to the log.</param>
		public static void LogInfo(string message)
		{
			EmpyrionApi.Log(message);
		}

		/// <summary>
		/// Logs a debug message with Empyrion if a DEBUG build is used. Release builds do nothing.  Appears in the log for whichever Empyrion process owns this instance of the mod.
		/// </summary>
		/// <param name="message">Message appended to the log.</param>
		public static void LogDebug(string message)
		{
#if DEBUG
			EmpyrionApi.Log(message);
#endif
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

			Application.OnPlayfieldLoaded += Application_OnPlayfieldLoaded;
			Application.OnPlayfieldUnloading += Application_OnPlayfieldUnloading;

			EmpyrionApi.Log("Dark City server extension loaded.");
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

			EmpyrionApi.Log("Dark City server extension shut down.");
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
		}

		static int update_counter = 0;
		/// <summary>
		/// Called by Empyrion every update tick. Deprecated, recommended to use the Update event in IApplication.
		/// </summary>
		public void Game_Update()
		{
			if (++update_counter % 20 == 0)
			{
				LegacyCmd.RequestPlayerList(list =>
				{
					if (list == null)
					{
						DarkCity.LogInfo("RequestPlayerList returned null data.");
					}
					else if (list.list == null)
					{
						DarkCity.LogInfo("RequestPlayerList returned data with null list.");
					}
					else
					{
						DarkCity.LogInfo($"RequestPlayerList return list {string.Join<int>(", ", list.list)}.");
					}
				});
			}
				
		}

		/// <summary>
		/// Called by Empyrion when the mod is unloaded.
		/// </summary>
		public void Game_Exit()
		{
		}

		/// <summary>
		/// Called by Empyrion when any game event occurs. This could be in response to a game request we sent.
		/// </summary>
		/// <param name="eventId">ID of the event that triggered this call. See https://empyrion.gamepedia.com/Game_API_CmdId for details. </param>
		/// <param name="seqNr">A sequence number copied from the request that the event is a response to, if applicable. Generally used to filter out events not specifically requested by the mod.</param>
		/// <param name="data">A data structure containing specifics about the event. Must be cast into the right object based on the eventId.</param>
		public void Game_Event(CmdId eventId, ushort seqNr, object data)
		{
			if (seqNr == LegacyCmd.SequenceNumber)
			{
				// Event was generated as a result of a request from this mod. Dispatch the data to the requestor.
				LegacyCmd.DispatchEvent(eventId, data);
				return;
			} else if (seqNr == 0)
			{
				// Event originated from the game. Dispatch it to event handlers.
				// TODO
			}
		}

        #endregion

        #region "Event Handlers"

        /// <summary>
        /// Handles the OnPlayfieldLoaded event from the game IApplication instance. Passes off the new IPlayfield instance to a PlayfieldProcessor.
        /// </summary>
        /// <param name="playfield">The newly loaded IPlayfield instance.</param>
        private void Application_OnPlayfieldLoaded(IPlayfield playfield)
		{
			if (this.PlayfieldProcessors.ContainsKey(playfield.Name))
			{
				this.PlayfieldProcessors[playfield.Name].Stop();
			}

			this.PlayfieldProcessors[playfield.Name] = new PlayfieldProcessor(playfield);
		}

		/// <summary>
		/// Handles the OnPlayfieldUnloading event from the IApplication instance. Shuts down the PlayfieldProcessor that was handling the IPlayfield instance.
		/// </summary>
		/// <param name="playfield">The IPlayfield instance that is about to be unloaded.</param>
		private void Application_OnPlayfieldUnloading(IPlayfield playfield)
		{
			this.PlayfieldProcessors[playfield.Name].Stop();
			this.PlayfieldProcessors.Remove(playfield.Name);
		}

        #endregion
    }
}
