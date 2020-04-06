using DarkCity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace DarkCity.Configuration
{
    /// <summary>
    /// A crafting template for an Empyrion item. Includes information about its component parts, what contructor can build it, crafting time, and more.
    /// </summary>
    public class CraftingTemplate : EmpyrionObject
    {
        private static readonly List<string> ores = new List<string>()
        {
            "WoodLogs",
            "CrushedStone",
            "WaterBottle",
            "WaterJug",
            "IronOre",
            "CopperOre",
            "SiliconOre",
            "PromethiumOre",
            "PentaxidOre",
            "CobaltOre",
            "MagnesiumOre",
            "NeodymiumOre",
            "SathiumOre",
            "ErestrumOre",
            "ZascosiumOre",
            "GoldOre",
            "XenoSubstrate"
        };

        private static readonly List<string> ingots = new List<string>()
        {
            "WoodPlanks",
            "RockDust",
            "IronIngot",
            "CopperIngot",
            "SiliconIngot",
            "PromethiumPellets",
            "PentaxidElement",
            "PentaxidCrystal",
            "CobaltIngot",
            "MagnesiumPowder",
            "NeodymiumIngot",
            "SathiumIngot",
            "ErestrumIngot",
            "ZascosiumIngot",
            "GoldIngot"
        };

        /// <summary>
        /// Base items are used in the parts list when building a blueprint in the factory. Also used when using a Repair Bay to repair to template.
        /// </summary>
        public bool BaseItem
        {
            get {
                bool result;
                if (bool.TryParse(this.ResolveProperty("BaseItem")?.Value, out result))
                    return result;
                return false;
            }
        }

        /// <summary>
        /// True if the item counts as an Ore item.
        /// </summary>
        public bool IsOre
        {
            get { return ores.Contains(this.Name); }
        }

        /// <summary>
        /// True if the item counts as an Ingot item.
        /// </summary>
        public bool IsIngot
        {
            get { return ingots.Contains(this.Name); }
        }

        /// <summary>
        /// How many items are produced when this template is built.
        /// </summary>
        public int OutputCount
        {
            get
            {
                int result;
                if (int.TryParse(this.ResolveProperty("OutputCount")?.Value, out result))
                    return result;
                return 1;
            }
        }

        /// <summary>
        /// Number of seconds it takes to build this template. This number is multiplied by the constructor factor to calculate the final time.
        /// </summary>
        public int CraftTime
        {
            get
            {
                int result;
                if (int.TryParse(this.ResolveProperty("CraftTime")?.Value, out result))
                    return result;
                return 1;
            }
        }

        /// <summary>
        /// A list of <see cref="Constructor"/> types that are allowed to build this template.
        /// </summary>
        public List<Constructor> Targets
        {
            get
            {
                string[] targets = this.ResolveProperty("Target")?.ToArray();
                if (targets == null) return null;
                List<Constructor> result = new List<Constructor>(targets.Length);
                for (int i = 0; i < targets.Length; i++)
                    result.Add(targets[i].ToConstructor());
                return result;
            }
        }

        public Dictionary<string, int> Inputs
        {
            get
            {
                EmpyrionObject child = null;
                foreach (EmpyrionObject c in this.Children)
                {
                    if (c?.Name == "Inputs")
                    {
                        child = c;
                        break;
                    }
                }

                if (child == null) return null;
                Dictionary<string, int> inputs = new Dictionary<string, int>();
                int count;
                foreach (Property p in child.Properties.Values)
                    if (int.TryParse(p.Value, out count))
                        inputs.Add(p.Key, count);
                return inputs;
            }
        }

        public DeconstructorOverride DeconstructorOverride
        {
            get
            {
                return this.ResolveProperty("DeconOverride")?.Value?.ToDeconstructorOverride() ?? DeconstructorOverride.None;
            }
        }


        public CraftingTemplate(EmpyrionConfiguration configuration)
            : base(configuration) { }

        public CraftingTemplate(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header, ConfigurationReader config)
            : base(configuration, header, config) { }

        /*
        public override void ParseConfig(ConfigurationReader config)
        {
            bool inputsMode = false;
            KeyValuePair<string, string> line = config.ReadParsedLine();

            while (line.Key != null)
            {
                if (line.Key == "{")
                {
                    inputsMode = true;
                }
                else if (line.Key == "}")
                {
                    if (inputsMode)
                        inputsMode = false;
                    else
                        return;
                }
                else
                {
                    if (inputsMode)
                    {
                        this.Inputs[line.Key] = Int32.Parse(line.Value);
                    }
                    else
                    {
                        // Lines are setting non-input properties.
                        switch (line.Key.Trim().ToLower())
                        {
                            //case "template name": this.Name = kvp[1]; break;
                            case "baseitem": this.BaseItem = Boolean.Parse(line.Value.Trim()); break;
                            case "crafttime": this.CraftTime = Int32.Parse(line.Value.Trim()); break;
                            case "outputcount": this.OutputCount = Int32.Parse(line.Value.Trim()); break;
                            case "target": this.Targets.AddRange(line.Value.Trim(trimChars).Split(listSplitChars).ToList<string>().ConvertAll<Constructor>(s => s.Trim().ToConstructor())); break;
                            case "deconoverride": this.DeconstructorOverride = line.Value.Trim().ToDeconstructorOverride(); break;
                            default: throw new InvalidDataException($"Unknown config line: {line}");
                        }
                    }
                }

                line = config.ReadParsedLine();
            }
        }
        

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{{ {this.Type} Name: {this.Name}");
            if (this.baseItem != null) result.AppendLine($"  BaseItem: {this.baseItem}");
            if (this.craftTime != null) result.AppendLine($"  CraftTime: {this.craftTime}");
            if (this.outputCount != null) result.AppendLine($"  OutputCount: {this.outputCount}");
            if (this.Targets.Count > 0) result.AppendLine($"  Target: \"{ string.Join(",", this.Targets.Select(s => ConstructorExtensions.ToString(s)))}\"");
            if (this.DeconstructorOverride != DeconstructorOverride.None) result.AppendLine($" DeconOverride: {this.DeconstructorOverride}");
            if (this.Inputs.Count > 0)
            {
                result.AppendLine("  { Child Inputs");
                foreach (KeyValuePair<string, int> input in this.Inputs)
                {
                    result.AppendLine($"    {input.Key}: {input.Value}");
                }
                result.AppendLine("  }");
            }
            result.AppendLine("}");
            return result.ToString();
        }

        protected override EmpyrionObject GetReference()
        {
            if (string.IsNullOrEmpty(this.Reference))
                throw new Exception($"Tried to get a null reference in {this.Type} object {this.Name}.");

            return Configuration.TemplatesByName[this.Reference];
        }
        */
    }
}
