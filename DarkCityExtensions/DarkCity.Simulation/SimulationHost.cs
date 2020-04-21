using DarkCity.Configuration;
using Eleon.Modding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace DarkCity.Simulation
{
    public enum SimulationState
    {
        Stopped,
        Running,
        Paused
    }

    public class SimulationHost
    {
        public event EventHandler TickBegin, TickEnd;
        public event EventHandler<IMod> IModInstanceLoaded, IModInstanceUnloaded;
        public event EventHandler<ModInterface> ModInterfaceLoaded, ModInterfaceUnloaded;
        public event EventHandler<EmpyrionConfiguration> ConfigurationLoaded;
        public event EventHandler<Localization> LocalizationLoaded;
        public event EventHandler<SimulationState> StateChanged;

        private static int nextEntityId = 1000;
        public static int NextEntityId { get { return nextEntityId++; } }

        public DirectoryInfo EmpyrionBasePath { get; private set; }

        public EmpyrionConfiguration Configuration { get; private set; }

        public Localization Localization { get; private set; }

        private SimulationState state = SimulationState.Stopped;
        public SimulationState State
        {
            get { return this.state; }
            private set
            {
                this.state = value;
                if (this.StateChanged != null)
                    this.StateChanged(this, this.state);
            }
        }

        public ModApiSimulator IModApi { get; set; }

        public ModGameApiSimulator ModGameAPI { get; set; }

        public ApplicationSimulator IApplication { get; set; }

        public PlayfieldSimulator ClientPlayfield { get; set; }

        public List<object> ModInstances { get; private set; } = new List<object>();

        public Dictionary<string, ModDetails> Mods { get; set; } = new Dictionary<string, ModDetails>();

        protected Thread GameLoop { get; private set; }

        public TimeSpan TickTime { get; set; }

        public SimulationHost(string empyrionPath)
        {
            this.EmpyrionBasePath = new DirectoryInfo(empyrionPath);

            this.IApplication = new ApplicationSimulator();
            this.IApplication.EmpyrionRootDirectory = this.EmpyrionBasePath.FullName;

            PlayfieldSimulator playfield = this.IApplication.CreatePlayfield("Planet", "Temperate", 1);
            playfield.GeneratePoIs(30);

            this.IApplication.LocalPlayer = playfield.Players[playfield.SpawnTestPlayer(UnityEngine.Vector3.zero)];

            this.IModApi = new ModApiSimulator();
            this.IModApi.Application = this.IApplication;
            this.IModApi.ClientPlayfield = playfield;

            this.ModGameAPI = new ModGameApiSimulator();

            foreach (string dir in Directory.GetDirectories(Path.Combine(this.EmpyrionBasePath.FullName, @"Content\Mods")))
            {
                ModDetails mod = new ModDetails(dir);
                this.Mods[mod.ShortName] = mod;
            }
        }

        protected void SimulatedGameLoop()
        {
            DateTime tickStart;
            TimeSpan tickRemaining;

            try
            {
                while (this.State != SimulationState.Stopped)
                {
                    tickStart = DateTime.Now;

                    if (this.State == SimulationState.Running)
                    {
                        this.ModGameAPI.ticks++;
                        if (this.TickBegin != null)
                            this.TickBegin(this, null);

                        foreach (ModInterface mod in this.ModInstances)
                        {
                            try
                            {
                                mod?.Game_Update();
                            } catch (Exception ex)
                            {
                                Log.Warn($"Unhandled {ex.GetType().Name} in Game_Update of {mod}. {ex.Message}");
                            }
                        }

                        if (this.TickEnd != null)
                            this.TickEnd(this, null);
                    }

                    tickRemaining = DateTime.Now - tickStart;
                    if (tickRemaining < this.TickTime) Thread.Sleep(this.TickTime - tickRemaining);
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Log.Critical("Unexpected error in simulated game loop. " + ex.Message);
            }
            finally
            {
                this.state = SimulationState.Stopped;
            }
        }

        public void Start()
        {
            switch (this.State)
            {
                case SimulationState.Paused:
                    this.State = SimulationState.Running;
                    break;

                case SimulationState.Stopped:
                    this.State = SimulationState.Running;
                    
                    // Instantiate mods.
                    foreach (ModDetails mod in this.Mods.Values)
                    {
                        if (!string.IsNullOrEmpty(mod.LoadError)) continue;

                        try
                        {
                            foreach (Type type in mod.ModTypes)
                            {
                                object instance = mod.Assembly.CreateInstance(type.FullName);
                                this.ModInstances.Add(instance);
                                if (instance is IMod)
                                {
                                    IMod i = (IMod)instance;
                                    i.Init(this.IModApi);
                                    if (this.IModInstanceLoaded != null)
                                        this.IModInstanceLoaded(this, i);
                                }

                                if (instance is ModInterface)
                                {
                                    ModInterface i = (ModInterface)instance;
                                    i.Game_Start(this.ModGameAPI);
                                    if (this.ModInterfaceLoaded != null)
                                        this.ModInterfaceLoaded(this, i);
                                }
                            }
                        } catch (Exception ex)
                        {
                            Log.Warn($"Failed to load module {mod.ShortName}. {ex.Message}");
                        }
                    }

                    // Notify mods of any existing playfields.
                    this.IApplication.TriggerPlayfieldLoaded();

                    this.GameLoop = new Thread(this.SimulatedGameLoop);
                    this.GameLoop.Name = "Empyrion Simulation Game Loop";
                    this.GameLoop.IsBackground = true;
                    this.GameLoop.Start();
                    break;
            }
        }

        public void Stop()
        {
            switch (this.State)
            {
                case SimulationState.Paused:
                case SimulationState.Running:
                    this.state = SimulationState.Stopped; // Sneak in a stop to signal game loop to end.
                    this.GameLoop.Join(5000);
                    this.GameLoop.Abort();
                    foreach (object instance in this.ModInstances)
                    {
                        if (instance is IMod) ((IMod)instance).Shutdown();
                        if (instance is ModInterface) ((ModInterface)instance).Game_Exit();
                    }

                    this.ModInstances.Clear();
                    this.State = SimulationState.Stopped; // Now we are officially stopped. Trigger events.
                    break;
            }
        }

        public void Pause()
        {
            switch (this.State)
            {
                case SimulationState.Running:
                    this.State = SimulationState.Paused;
                    break;
            }
        }
    }
}
