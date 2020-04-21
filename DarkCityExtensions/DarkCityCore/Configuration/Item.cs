using System;
namespace DarkCity.Configuration
{
    public class Item : EmpyrionObject
    {
        public int Armor => this.ResolveProperty("Armor")?.GetValueAsInt32() ?? 0;
        public int BlastDamage => this.ResolveProperty("BlastDamage")?.GetValueAsInt32() ?? 0;
        public int BlastRadius => this.ResolveProperty("BlastRadius")?.GetValueAsInt32() ?? 0;
        public string Category => this.ResolveProperty("Category")?.Value;
        public int Cold => this.ResolveProperty("Cold")?.GetValueAsInt32() ?? 0;
        public float DegradationProbability => this.ResolveProperty("DegradationProb")?.GetValueAsFloat() ?? 0.0f;
        public int Durability => this.ResolveProperty("Durability")?.GetValueAsInt32() ?? 0;
        public float FallDamageFactor => this.ResolveProperty("FallDamageFac")?.GetValueAsFloat() ?? 1.0f;
        public int FoodDecayTime => this.ResolveProperty("FoodDecayTime")?.GetValueAsInt32() ?? 0;
        public float FoodFactor => this.ResolveProperty("FoodFac")?.GetValueAsFloat() ?? 1.0f;
        public int Heat => this.ResolveProperty("Heat")?.GetValueAsInt32() ?? 0;
        public int NumberOfSlots => this.ResolveProperty("NrSlots")?.GetValueAsInt32() ?? 0;
        public int Oxygen => this.ResolveProperty("Oxygen")?.GetValueAsInt32() ?? 0;
        public bool PickupToToolbar => this.ResolveProperty("PickupToToolbar")?.GetValueAsBoolean() ?? false;
        public float PowerFactor => this.ResolveProperty("PowerFac")?.GetValueAsFloat() ?? 1.0f;
        public bool RadialMenu => this.ResolveProperty("RadialMenu")?.GetValueAsBoolean() ?? false;
        public int Radiation => this.ResolveProperty("Radiation")?.GetValueAsInt32() ?? 0;
        public int Range => this.ResolveProperty("Range")?.GetValueAsInt32() ?? 0;
        public float SpeedFactor => this.ResolveProperty("SpeedFac")?.GetValueAsFloat() ?? 1.0f;
        public int StackSize => this.ResolveProperty("StackSize")?.GetValueAsInt32() ?? 1;
        public float StaminaFactor => this.ResolveProperty("StaminaFac")?.GetValueAsFloat() ?? 1.0f;
        public string[] TechTreeNames => this.ResolveProperty("TechTreeNames")?.GetValueAsList();
        public string TechTreeParent => this.ResolveProperty("TechTreeParent")?.Value;
        public int UnlockCost => this.ResolveProperty("UnlockCost")?.GetValueAsInt32() ?? 0;
        public int UnlockLevel => this.ResolveProperty("UnlockLevel")?.GetValueAsInt32() ?? 0;
        public float Volume => this.ResolveProperty("Volume")?.GetValueAsFloat() ?? 1.0f;
        public float VolumeCapacity => this.ResolveProperty("VolumeCapacity")?.GetValueAsFloat() ?? 0.0f;

        public Item(EmpyrionConfiguration configuration) : base(configuration) { }

        public Item(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header, ConfigurationReader config) 
            : base(configuration, header, config) { }
    }
}
