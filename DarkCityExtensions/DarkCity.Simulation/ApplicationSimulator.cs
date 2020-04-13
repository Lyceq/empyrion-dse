using Eleon;
using Eleon.Modding;
using System;
using System.IO;
using System.Collections.Generic;

namespace DarkCity.Simulation
{
    public class ApplicationSimulator : IApplication
    {
        public string EmpyrionRootDirectory { get; set; }

        public List<IPlayfield> Playfields { get; set; } = new List<IPlayfield>();

        public GameState State { get; set; } = GameState.NotRunning;

        public ApplicationMode Mode { get; set; } = ApplicationMode.Client;

        public IPlayer LocalPlayer { get; set; } = null;

        public ulong GameTicks { get; set; } = 0;

        public event PlayfieldDelegate OnPlayfieldLoaded;
        public event PlayfieldDelegate OnPlayfieldUnloading;
        public event UpdateDelegate Update;
        public event UpdateDelegate FixedUpdate;
        public event GamEnteredEventHandler GameEntered;
        public event ChatMessageSentEventHandler ChatMessageSent;

        public ApplicationSimulator()
        {
            this.EmpyrionRootDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                @"Steam\steamapps\common\Empyrion - Galactic Survival");
        }

        public void TriggerUpdate()
        {
            if (this.Update != null)
            {
                try
                {
                    this.Update();
                }
                catch (Exception ex)
                {
                    Log.Warn($"Unhandled {ex.GetType().Name} in IApplication.Update event handler. {ex.Message}");
                }
            }

            if (this.FixedUpdate != null)
            {
                try
                {
                    this.FixedUpdate();
                } catch (Exception ex)
                {
                    Log.Warn($"Unhandled {ex.GetType().Name} in IApplication.FixedUpdate event handler. {ex.Message}");
                }
            }
        }

        public void TriggerPlayfieldLoaded()
        {
            if (this.OnPlayfieldLoaded == null) return;
            foreach (IPlayfield playfield in this.Playfields)
                this.OnPlayfieldLoaded(playfield);
        }

        public PlayfieldSimulator CreatePlayfield(string playfieldType, string planetClass, int sizeClass)
        {
            PlayfieldSimulator playfield = new PlayfieldSimulator();
            playfield.Name = "Simulated Playfield #" + SimulationHost.NextEntityId;
            playfield.GenerateMap(playfieldType, planetClass, sizeClass);
            this.Playfields.Add(playfield);
            if (this.OnPlayfieldLoaded != null)
                this.OnPlayfieldLoaded(playfield);
            return playfield;
        }

        public void UnloadPlayfield(IPlayfield playfield)
        {
            if (this.Playfields.Contains(playfield))
            {
                if (this.OnPlayfieldUnloading != null)
                    this.OnPlayfieldUnloading(playfield);
                this.Playfields.Remove(playfield);
            }
        }

        public IPlayfieldDescr[] GetAllPlayfields() { return (IPlayfieldDescr[])this.Playfields.ToArray(); }

        public string GetPathFor(AppFolder appFolder)
        {
            switch (appFolder)
            {
                case AppFolder.ActiveScenario: return Path.Combine(this.EmpyrionRootDirectory, @"Content\Scenarios");
                case AppFolder.Cache: return Path.Combine(this.EmpyrionRootDirectory, @"Saves\Cache");
                case AppFolder.Content: return Path.Combine(this.EmpyrionRootDirectory, @"Content");
                case AppFolder.Dedicated: return Path.Combine(this.EmpyrionRootDirectory, @"DedicatedServer");
                case AppFolder.Mod: return Path.Combine(this.EmpyrionRootDirectory, @"Content\Mods");
                case AppFolder.SaveGame: return Path.Combine(this.EmpyrionRootDirectory, @"Saves\Games");
                default: return this.EmpyrionRootDirectory;
            }
        }

        public Dictionary<int, List<string>> GetPfServerInfos() { return null; }

        public void SendChatMessage(MessageData chatMsgData) { }
    }
}
