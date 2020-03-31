using DarkCity.Configuration;
using System.Collections.Generic;

namespace DarkCity.Simulators
{
    public class ConstructionSimulationResults
    {
        /// <summary>
        /// A tally of the final parts that were produced.
        /// </summary>
        public Dictionary<string, int> PartsProduced { get; private set; } = new Dictionary<string, int>();

        /// <summary>
        /// A tally of the parts that were produced but not used in the final parts produced.
        /// </summary>
        public Dictionary<string, int> PartsExtra { get; private set; } = new Dictionary<string, int>();

        /// <summary>
        /// A tally of the basic parts that were used during construction.
        /// </summary>
        public Dictionary<string, int> UsedPartsBasic { get; private set; } = new Dictionary<string, int>();

        /// <summary>
        /// A tally of the ingot parts that were used during construction.
        /// </summary>
        public Dictionary<string, int> UsedPartsIngot { get; private set; } = new Dictionary<string, int>();

        /// <summary>
        /// A tally of the ore parts that were used during construction.
        /// </summary>
        public Dictionary<string, int> UsedPartsOre { get; private set; } = new Dictionary<string, int>();

        /// <summary>
        /// A tally of construction time needed for each constructor type that is able to construct the produced parts from ores.
        /// </summary>
        public Dictionary<Constructor, int> TimeToConstruct { get; private set; } = new Dictionary<Constructor, int>();

        public ConstructionSimulationResults()
        {
            this.ResetTimeToConstruct();
        }

        /// <summary>
        /// Resets the <see cref="TimeToConstruct"/> property to default values.
        /// </summary>
        protected void ResetTimeToConstruct()
        {
            // Simulators will remove constructors as they encounter parts that cannot be made in certain constructors.
            this.TimeToConstruct[Constructor.Advanced] = 0;
            this.TimeToConstruct[Constructor.Base] = 0;
            this.TimeToConstruct[Constructor.Deconstructor] = 0;
            this.TimeToConstruct[Constructor.FoodProcessor] = 0;
            this.TimeToConstruct[Constructor.Furnace] = 0;
            this.TimeToConstruct[Constructor.HV] = 0;
            this.TimeToConstruct[Constructor.Large] = 0;
            this.TimeToConstruct[Constructor.Portable] = 0;
            this.TimeToConstruct[Constructor.Survival] = 0;
            this.TimeToConstruct[Constructor.SV] = 0;
        }

        /// <summary>
        /// Clears all tallies in the results.
        /// </summary>
        public void Clear()
        {
            this.PartsProduced.Clear();
            this.PartsExtra.Clear();
            this.UsedPartsBasic.Clear();
            this.UsedPartsIngot.Clear();
            this.UsedPartsOre.Clear();
            this.ResetTimeToConstruct();
        }

        /// <summary>
        /// Adds a quantity to a tally. If the key is not present then it is added to the tally.
        /// </summary>
        /// <typeparam name="T">Type of the key that the tally is counting.</typeparam>
        /// <param name="count">Dictionary keeping the tallies.</param>
        /// <param name="key">Key of the tally to be updated.</param>
        /// <param name="quantity">Amount to add to the tally.</param>
        public void AddCount<T>(Dictionary<T, int> count, T key, int quantity)
        {
            if (count.ContainsKey(key))
                count[key] += quantity;
            else
                count[key] = quantity;
        }

        /// <summary>
        /// Adds a used part to the counts.
        /// </summary>
        /// <param name="part"><see cref="CraftingTemplate"/> of the part used.</param>
        /// <param name="quantity">Quantity of the part used.</param>
        /// <param name="countBasic">Indicates if the part should be listed in the basic item count.
        /// If true, the part is included only if its template indicates it is a basic item. If false, the item is not counted.</param>
        public void AddUsedPart(CraftingTemplate part, int quantity, bool countBasic)
        {
            if (countBasic && part.BaseItem)
                this.AddCount(this.UsedPartsBasic, part.Name, quantity);

            if (part.IsIngot)
                this.AddCount(this.UsedPartsIngot, part.Name, quantity);

            if (part.IsOre)
                this.AddCount(this.UsedPartsOre, part.Name, quantity);
        }

        /// <summary>
        /// Adds a used part that does not have a crafting template. It is assumed that the part must be supplied from an external source.
        /// All external items are included in the ores count, regardless of if they are an ore.
        /// </summary>
        /// <param name="name">Reference name of the part.</param>
        /// <param name="quantity">Quantity of the part used.</param>
        /// <param name="countBasic">Indicates if the part should be listed in the basic item count.</param>
        public void AddUsedPart(string name, int quantity, bool countBasic)
        {
            if (countBasic) this.AddCount(this.UsedPartsBasic, name, quantity);
            this.AddCount(this.UsedPartsOre, name, quantity);
        }
    }
}
