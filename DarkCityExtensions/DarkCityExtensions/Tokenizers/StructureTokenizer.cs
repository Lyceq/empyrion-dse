using Eleon.Modding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkCity.Tokenizers
{
    /// <summary>
    /// Tokenizes an IStructure instance.
    /// </summary>
    public class StructureTokenizer : Tokenizer
    {
        /// <summary>
        /// The IStructure instance that provides token values. Set by the constructor.
        /// </summary>
        public IStructure Structure { get; private set; }

        /// <summary>
        /// Creates a StructureTokenizer that provides access to data about the structure via token names.
        /// </summary>
        /// <param name="structure">The IStructure instance used to provide data values for the tokens.</param>
        public StructureTokenizer(IStructure structure)
        {
            this.Structure = structure;
            this.Update();
        }

        /// <summary>
        /// Updates tokens with the latest structure data.
        /// </summary>
        public override void Update()
        {
            if (this.Structure == null)
            {
                this.tokens.Clear();
                DarkCity.LogWarn("Attempted to tokenize a null structure.");
            }
            else
            {
                this.tokens["StructureID"] = this.Structure.Id.ToString();
                this.tokens["Damage"] = (this.Structure.DamageLevel * 100.0).ToString("F2");
                this.tokens["Powered"] = this.Structure.IsPowered ? "Yes" : "No";
                this.tokens["Pilot"] = this.Structure.Pilot?.Name ?? "None";

                this.TokenizeTank(this.Structure.FuelTank, "Fuel");
                this.TokenizeTank(this.Structure.OxygenTank, "Oxygen");
                this.TokenizeTank(this.Structure.PentaxidTank, "Pentaxid");

                List<IStructure> dockedVessels = this.Structure.GetDockedVessels();
                this.tokens["DockedVesselCount"] = dockedVessels.Count.ToString();
                this.TokenizeStructureList(dockedVessels, "DockedVesselList");

                List<IPlayer> passengers = this.Structure.GetPassengers();
                this.tokens["PassengerCount"] = passengers.Count.ToString();
                this.TokenizePlayerList(passengers, "PassengerList");

                List<SenderSignal> signals = this.Structure.GetBlockSignals();
                signals = signals.Concat<SenderSignal>(this.Structure.GetControlPanelSignals()).ToList();
                this.TokenizeSignalList(signals);
            }
        }

        /// <summary>
        /// Tokenizes an IStructureTank instance. Tokens are created for content, capacity, and their ratio.
        /// </summary>
        /// <param name="tank">The IStructureTank instance to be tokenized.</param>
        /// <param name="prefix">The prefix for token names. For example, use "Fuel" to create tokens "FuelContent", "FuelCapacity", and "FuelRatio".</param>
        private void TokenizeTank(IStructureTank tank, string prefix)
        {
            this.tokens[prefix + "Content"] = tank?.Content.ToString("F0") ?? "0";
            this.tokens[prefix + "Capacity"] = tank?.Capacity.ToString("F0") ?? "0";
            this.tokens[prefix + "Ratio"] = ((tank?.Content ?? 0.0) / (tank?.Capacity ?? 1.0) * 100).ToString("F1");
        }

        /// <summary>
        /// Tokenizes a list of IStructure objects. The value created is a list of the structures' entity names.
        /// </summary>
        /// <param name="structures">The list of IStructure instances to tokenize.</param>
        /// <param name="key">The key to use for the name of the token.</param>
        private void TokenizeStructureList(List<IStructure> structures, string key)
        {
            StringBuilder result = new StringBuilder();
            foreach (IStructure structure in structures)
            {
                result.Append(structure?.Entity?.Name ?? "Unknown");
                result.Append(Environment.NewLine);
            }

            this.tokens[key] = result.ToString().Trim();
        }

        /// <summary>
        /// Tokenizes a list of IPlayer instances. The value created is a list of the players' names.
        /// </summary>
        /// <param name="players">The list of IPlayer instances to tokenize.</param>
        /// <param name="key">The key to use for the name of the token.</param>
        private void TokenizePlayerList(List<IPlayer> players, string key)
        {
            StringBuilder result = new StringBuilder();
            foreach (IPlayer player in players)
            {
                result.Append(player?.Name ?? "Unknown");
                result.Append(Environment.NewLine);
            }

            this.tokens[key] = result.ToString().Trim();
        }

        /// <summary>
        /// Tokenizes a list of SenderSignal instances. Each signal will be given a token of "Signal-[SignalName]" with a value of "On" or "Off". All signals will also be added to
        /// either the ActiveSignalList token or the InactiveSignalList token, depending on their state.
        /// </summary>
        /// <param name="signals">A list of SenderSignal instances. These normally come from the IStructure method GetControlPanelSignals, GetBlockSignals, or both.</param>
        private void TokenizeSignalList(List<SenderSignal> signals)
        {
            StringBuilder signalList = new StringBuilder();
            StringBuilder activeSignalList = new StringBuilder();
            int activeSignalCount = 0;
            StringBuilder inactiveSignalList = new StringBuilder();
            int inactiveSignalCount = 0;

            this.tokens["SignalCount"] = signals.Count.ToString();
            foreach (SenderSignal signal in signals)
            {
                bool state = this.Structure.GetSignalState(signal.Name);
                this.tokens["Signal-" + signal.Name] = state ? "On" : "Off";
                if (state)
                {
                    activeSignalList.Append(signal.Name);
                    activeSignalList.Append(Environment.NewLine);
                    activeSignalCount++;
                } else
                {
                    inactiveSignalList.Append(signal.Name);
                    inactiveSignalList.Append(Environment.NewLine);
                    inactiveSignalCount++;
                }
            }
           

            this.tokens["ActiveSignalList"] = activeSignalList.ToString();
            this.tokens["ActiveSignalCount"] = activeSignalCount.ToString();
            this.tokens["InactiveSignalList"] = inactiveSignalList.ToString();
            this.tokens["InactiveSignalCount"] = inactiveSignalCount.ToString();
        }
    }
}
