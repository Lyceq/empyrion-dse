using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EmpyrionLogistics.Data
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

        public override EmpyrionObjectType Type {  get { return EmpyrionObjectType.Template; } }

        /// <summary>
        /// Base items are used in the parts list when building a blueprint in the factory. Also used when using a Repair Bay to repair to template.
        /// </summary>
        public bool BaseItem
        {
            get { return this.baseItem ?? this.GetReferenceValue<bool?>("BaseItem") ?? (this.Inputs.Count < 1); }
            set { this.baseItem = value; }
        }
        private bool? baseItem = null;

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
            get { return this.outputCount ?? this.GetReferenceValue<int?>("OutputCount") ?? 1; }
            set { this.outputCount = value; }
        }
        private int? outputCount = null;

        /// <summary>
        /// Number of seconds it takes to build this template. This number is multiplied by the constructor factor to calculate the final time.
        /// </summary>
        public int CraftTime
        {
            get { return this.craftTime ?? this.GetReferenceValue<int?>("CraftTime") ?? 1; }
            set { this.craftTime = value; }
        }
        private int? craftTime = null;

        /// <summary>
        /// A list of <see cref="Constructor"/> types that are allowed to build this template.
        /// </summary>
        public List<Constructor> Targets { get; set; }
        public Dictionary<string, int> Inputs { get; set; }
        public DeconstructorOverride DeconstructorOverride { get; set; }
        

        public CraftingTemplate (EmpyrionConfiguration configuration) : base(configuration)
        {
            this.Name = "Blank Template";
            this.Targets = new List<Constructor>();
            this.Inputs = new Dictionary<string, int>();
        }

        public CraftingTemplate(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header, StreamReader config) : base(configuration, header)
        {
            this.Targets = new List<Constructor>();
            this.Inputs = new Dictionary<string, int>();
            this.ParseConfig(config);
        }

        public void ParseConfig(StreamReader config)
        {
            bool inputsMode = false;
            string line = "*";
            string trim;
            string[] kvp;

            while (!string.IsNullOrEmpty(line))
            {
                line = config.ReadLine();
                trim = line?.Trim();
                if (string.IsNullOrEmpty(trim)) continue; // Ignore blank lines.
                else if (trim.StartsWith("#")) continue; // Ignore comments.
                else if (trim.StartsWith("}"))
                {
                    if (inputsMode)
                    {
                        inputsMode = false; // End of sub-object.
                        continue;
                    }
                    else
                    {
                        return; // End of object.
                    }
                }
                
                kvp = trim.Split(splitChars, 2);

                if (inputsMode)
                {
                    this.Inputs[kvp[0]] = Int32.Parse(kvp[1]);
                }
                else
                {
                    // Lines are setting non-input properties.
                    switch (kvp[0].Trim().ToLower())
                    {
                        //case "template name": this.Name = kvp[1]; break;
                        case "baseitem": this.BaseItem = Boolean.Parse(kvp[1].Trim()); break;
                        case "crafttime": this.CraftTime = Int32.Parse(kvp[1].Trim()); break;
                        case "outputcount": this.OutputCount = Int32.Parse(kvp[1].Trim()); break;
                        case "target": this.Targets.AddRange(kvp[1].Trim(trimChars).Split(listSplitChars).ToList<string>().ConvertAll<Constructor>(s => s.Trim().ToConstructor())); break;
                        case "deconoverride": this.DeconstructorOverride = kvp[1].Trim().ToDeconstructorOverride(); break;
                        case "{ child inputs": inputsMode = true; break;
                        default: throw new InvalidDataException($"Unknown config line: {line}");
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{{ {this.Type} Name: {this.Name}");
            if (this.baseItem != null) result.AppendLine($"  BaseItem: {this.baseItem}");
            if (this.craftTime != null) result.AppendLine($"  CraftTime: {this.craftTime}");
            if (this.outputCount != null) result.AppendLine($"  OutputCount: {this.outputCount}");
            if (this.Targets.Count > 0) result.AppendLine($"  Target: \"{ string.Join(",", this.Targets)}\"");
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
    }
}
