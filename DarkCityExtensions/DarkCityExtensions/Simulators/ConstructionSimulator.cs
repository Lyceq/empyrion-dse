using DarkCity.Configuration;
using System;
using System.Collections.Generic;

namespace DarkCity.Simulators
{
    public class ConstructionSimulator
    {
        public EmpyrionConfiguration Configuration { get; private set; } = new EmpyrionConfiguration();

        protected Dictionary<string, int> Inventory { get; private set; } = new Dictionary<string, int>();

        public ConstructionSimulationResults Results { get; private set; } = new ConstructionSimulationResults();

        /// <summary>
        /// Tracks how deep we are in producing basic parts.
        /// </summary>
        private int basePartDepth = 0;

        public ConstructionSimulator(EmpyrionConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public ConstructionSimulationResults Simulate(Dictionary<string, int> request)
        {
            this.Inventory.Clear();
            this.Results.Clear();
            this.basePartDepth = 0;

            // Pull each requested part from inventory. If not available then it will be constructed.
            foreach (KeyValuePair<string, int> part in request)
                this.PullPart(part.Key, part.Value);

            foreach (KeyValuePair<string, int> part in this.Inventory)
                if (part.Value > 0) this.Results.PartsExtra[part.Key] = part.Value;

            return this.Results;
        }

        protected void PullPart(string name, int quantity)
        {
            if (!this.Configuration.TemplatesByName.ContainsKey(name))
            {
                // If a template is not provided then it is assumed that it is a basic item and ore that is provided by the player.
                this.Results.AddUsedPart(name, quantity, this.basePartDepth < 1);
                return;
            }

            CraftingTemplate template = this.Configuration.TemplatesByName[name];
            if (template.BaseItem) this.basePartDepth++;

            // Account for items pulled from inventory.
            this.Results.AddUsedPart(template, quantity, this.basePartDepth == 1);

            // Ores are assumed to be provided by the player. All others must be pulled from inventory or manufactured.
            if (!template.IsOre)
            {
                // Determine if parts need to be manufactured.
                if (!this.Inventory.ContainsKey(name))
                    this.ManufacturePart(template, quantity);
                else if (this.Inventory[name] < quantity)
                    this.ManufacturePart(template, quantity - this.Inventory[name]);

                // Remove parts.
                this.Inventory[name] -= quantity;
            }

            if (template.BaseItem) this.basePartDepth--;
        }

        protected void ManufacturePart(CraftingTemplate template, int quantity)
        {
            // Calculate how many constructor runs are needed to produce the number of items requested.
            int runs = (int)Math.Ceiling((decimal)quantity / (decimal)template.OutputCount);

            // Pull each part needed to construct the item. If not available they will be constructed or assumed to be provided by the player.
            foreach (KeyValuePair<string, int> input in template.Inputs)
                this.PullPart(input.Key, input.Value * runs);

            // Add the produced items to inventory.
            this.Results.AddCount(this.Inventory, template.Name, template.OutputCount * runs);

            // Account for constructor time.
            this.AddConstructorTime(template, runs);
        }

        protected void AddConstructorTime(CraftingTemplate template, int runs)
        {
            Constructor[] constructors = new Constructor[this.Results.TimeToConstruct.Keys.Count];
            this.Results.TimeToConstruct.Keys.CopyTo(constructors, 0);

            foreach (Constructor constructor in constructors)
            {
                if (template.Targets.Contains(constructor))
                    // Add the amount of time, in seconds, that the constructor must work to produce the number of crafting runs requested.
                    this.Results.AddCount(this.Results.TimeToConstruct, constructor, (int)Math.Ceiling(template.CraftTime * constructor.SpeedFactor() * runs));
                else
                    this.Results.TimeToConstruct.Remove(constructor);
            }
        }
    }
}
