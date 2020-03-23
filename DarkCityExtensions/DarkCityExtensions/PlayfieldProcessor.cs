using DarkCity.Tokenizers;
using Eleon.Modding;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DarkCity
{
	/// <summary>
	/// Processes an IPlayfield instance at regular intervals. Responsible for dispatching interesting bits of the playfield to feature handlers. Processing is performed in a separate thread.
	/// </summary>
	public class PlayfieldProcessor
	{
		/// <summary>
		/// The IPlayfield that this processor handles.
		/// </summary>
		public IPlayfield Playfield { get; }

		private Thread processor;
		private bool process = true;
		private TimeSpan loopTime = new TimeSpan(0, 0, 1);

		public PlayfieldProcessor(IPlayfield playfield)
		{
			this.Playfield = playfield;

			DarkCity.LogInfo($"Launching thread to process entities in playfield {playfield.Name}.");

			processor = new Thread(new ThreadStart(this.ProcessEntities));
			processor.Name = $"DCE entity processor for playfield {playfield.Name}";
			processor.IsBackground = true;
			processor.Start();
		}

		/// <summary>
		/// Signals to the child thread to stop processing. Blocks for up to one second to allow the thread to finish.
		/// </summary>
		public void Stop()
		{
			this.process = false;
			this.processor.Join(1000);
		}

		/// <summary>
		/// Processes IEntity instances from the playfield. Interesting entities are dispatched to other feature processeors for handling. Unhandled exceptions are caught here
		/// to prevent the mod from causing issues with the game server. If you want to add a new feature, hook it into the ProcessEntity method.
		/// </summary>
		private void ProcessEntities()
		{
			DateTime loopStart;
			while (this.process)
			{
				if (this.Playfield == null) return;

				try
				{
					// Process all entities in the playfield for this client/pfserver.
					loopStart = DateTime.Now;
					DarkCity.LogDebug($"Processing entities in {this.Playfield.Name}.");
					Dictionary<int, IEntity> entities = this.Playfield.Entities;
					if (entities != null)
					{
						foreach (IEntity entity in entities.Values)
						{
							this.ProcessEntity(entity);
						}
					}

					Thread.Sleep(loopTime - (DateTime.Now - loopStart));
				} catch (Exception ex)
				{
					DarkCity.LogError($"Unhandled exception in entity processor: {ex.Message}. Sleeping it off.");
					Thread.Sleep(loopTime);
				}
			}
		}

		/// <summary>
		/// Examines an IEntity instance to see if any feature will be interested in it.
		/// </summary>
		/// <param name="entity">The IEntity instance to be examined.</param>
		private void ProcessEntity(IEntity entity)
		{
			// Process structure data of the entity.
			IStructure structure = entity.Structure;
			if (structure != null)
			{
				DarkCity.LogDebug($"Processing structure {structure.Entity.Name}");
				StructureTokenizer structTokens = null;
				
				// Process LCD devices.
				IDevicePosList list = structure.GetDevices(DeviceTypeName.LCD);
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						VectorInt3 position = list.GetAt(i);
						ILcd lcd = structure.GetDevice<ILcd>(position);
						if (lcd != null)
						{
							// Prep structure tokens if not available yet.
							if (structTokens == null)
								structTokens = new StructureTokenizer(structure);

							// Hand off ILcd device to any potentially interested processors.
							LiveLcd.Process(structure, lcd, position, structTokens);
						}
					}
				}
			}
		}

	}
}
