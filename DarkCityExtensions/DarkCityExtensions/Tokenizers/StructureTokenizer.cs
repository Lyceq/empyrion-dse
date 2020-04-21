using Eleon.Modding;
using DarkCity.Configuration;
using DarkCity.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Log.Warn("Attempted to tokenize a null structure.");
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

                // Get a manifest of all items in the structure.
                ItemManifest manifest = new ItemManifest();
                manifest.Add(this.Structure);

                if (EmpyrionExtension.Configuration != null)
                {
                    // Buckets of item totals, each will get their own tag.
                    Dictionary<string, int> allItems = new Dictionary<string, int>();

                    // Key is the name of the category. Value is the item->count lookup.
                    Dictionary<string, SortedDictionary<string, int>> categories = new Dictionary<string, SortedDictionary<string, int>>();

                    EmpyrionObject obj;
                    string category, name;
                    SortedDictionary<string, int> categoryList;
                    foreach (KeyValuePair<int, int> count in manifest.Items)
                    {
                        if (EmpyrionExtension.Configuration.ObjectsByID.ContainsKey(count.Key))
                        {
                            obj = EmpyrionExtension.Configuration.ObjectsByID[count.Key];
                            name = obj?.Name ?? count.Key.ToString();
                            allItems[name] = count.Value;
                            category = obj?.ResolveProperty("Category")?.Value;
                            if (category != null)
                            {
                                if (categories.ContainsKey(category))
                                {
                                    categoryList = categories[category];
                                }
                                else
                                {
                                    categoryList = new SortedDictionary<string, int>();
                                    categories[category] = categoryList;
                                }

                                if (categoryList.ContainsKey(name))
                                    categoryList[name] += count.Value;
                                else
                                    categoryList[name] = count.Value;
                            }
                        }
                        else
                        {
                            Log.Debug("Encountered block with unknown ID " + count.Key);
                            allItems[count.Key.ToString()] = count.Value;
                        }
                    }

                    this.tokens["InventoryAll"] = string.Join(Environment.NewLine, allItems.Select(kvp => $"{EmpyrionExtension.Localization?[kvp.Key] ?? kvp.Key}: {kvp.Value}"));
                    foreach (KeyValuePair<string, SortedDictionary<string, int>> kvp in categories)
                        this.tokens["Inventory-" + kvp.Key] = string.Join(Environment.NewLine, kvp.Value.Select(item => $"{EmpyrionExtension.Localization?[item.Key] ?? item.Key}: {item.Value}"));
                } else { Log.Debug("Configuration is null."); }
            }
        }

        private string CreateSortedList<T>(List<T> list, Func<T, string> selector)
        {
            if (list == null) return null;
            SortedList<string, object> result = new SortedList<string, object>(list.Count, StringComparer.InvariantCultureIgnoreCase);
            string line;
            foreach (T item in list)
            {
                line = selector(item);
                if (!string.IsNullOrEmpty(line)) result.Add(line, null);
            }

            return string.Join(Environment.NewLine, result);
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
            this.tokens[key] = this.CreateSortedList<IStructure>(structures, s => s?.Entity?.Name);
        }

        /// <summary>
        /// Tokenizes a list of IPlayer instances. The value created is a list of the players' names.
        /// </summary>
        /// <param name="players">The list of IPlayer instances to tokenize.</param>
        /// <param name="key">The key to use for the name of the token.</param>
        private void TokenizePlayerList(List<IPlayer> players, string key)
        {
            this.tokens[key] = this.CreateSortedList<IPlayer>(players, p => p?.Name);
        }

        /// <summary>
        /// Tokenizes a list of SenderSignal instances. Each signal will be given a token of "Signal-[SignalName]" with a value of "On" or "Off". All signals will also be added to
        /// either the ActiveSignalList token or the InactiveSignalList token, depending on their state.
        /// </summary>
        /// <param name="signals">A list of SenderSignal instances. These normally come from the IStructure method GetControlPanelSignals, GetBlockSignals, or both.</param>
        private void TokenizeSignalList(List<SenderSignal> signals)
        {
            SortedList<string, object> allSignals = new SortedList<string, object>(signals.Count, StringComparer.InvariantCultureIgnoreCase);
            SortedList<string, object> activeSignals = new SortedList<string, object>(StringComparer.InvariantCultureIgnoreCase);
            SortedList<string, object> inactiveSignals = new SortedList<string, object>(StringComparer.InvariantCultureIgnoreCase);
            int activeSignalCount = 0;
            int inactiveSignalCount = 0;

            this.tokens["SignalCount"] = signals.Count.ToString();
            foreach (SenderSignal signal in signals)
            {
                bool state = this.Structure.GetSignalState(signal.Name);
                this.tokens["Signal-" + signal.Name] = state ? "On" : "Off";
                allSignals.Add(signal.Name, null);
                if (state)
                {
                    activeSignals.Add(signal.Name, null);
                    activeSignalCount++;
                } else
                {
                    inactiveSignals.Add(signal.Name, null);
                    inactiveSignalCount++;
                }
            }

            this.tokens["SignalList"] = string.Join(Environment.NewLine, allSignals.Keys);
            this.tokens["ActiveSignalList"] = string.Join(Environment.NewLine, activeSignals.Keys);
            this.tokens["ActiveSignalCount"] = activeSignalCount.ToString();
            this.tokens["InactiveSignalList"] = string.Join(Environment.NewLine, inactiveSignals.Keys);
            this.tokens["InactiveSignalCount"] = inactiveSignalCount.ToString();
        }
    }
}
