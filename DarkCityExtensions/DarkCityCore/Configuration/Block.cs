using DarkCity.Data;
using System;

namespace DarkCity.Configuration
{
    public class Block : EmpyrionObject
    {
        public bool AboveTerrainCheck => this.ResolveProperty("AboveTerrainCheck")?.GetValueAsBoolean() ?? true;
        public int BlastDamage => this.ResolveProperty("BlastDamage")?.GetValueAsInt32() ?? 0;
        public int BlastRadius => this.ResolveProperty("BlastRadius")?.GetValueAsInt32() ?? 0;
        public VectorInt3 BlockColor => this.ResolveProperty("BlockColor")?.GetValueAsVectorInt3() ?? new VectorInt3(255, 255, 255);
        public string Category => this.ResolveProperty("Category")?.Value;
        public string[] ChildBlocks => this.ResolveProperty("ChildBlocks")?.GetValueAsList();
        public int CpuIn => this.ResolveProperty("CPUIn")?.GetValueAsInt32() ?? 0;
        public int EnergyIn => this.ResolveProperty("EnergyIn")?.GetValueAsInt32() ?? 0;
        public int EnergyInIdle => this.ResolveProperty("EnergyInIdle")?.GetValueAsInt32() ?? 0;
        public int EnergyOut => this.ResolveProperty("EnergyOut")?.GetValueAsInt32() ?? 0;
        public string[] FuelAccept => this.ResolveProperty("FuelAccept")?.GetValueAsList();
        public int FuelCapacity => this.ResolveProperty("FuelCapacity")?.GetValueAsInt32() ?? 0;
        public string Group => this.ResolveProperty("Group")?.Value;
        public int HitPoints => this.ResolveProperty("HitPoints")?.GetValueAsInt32() ?? 1;
        public float HVEngineDampCoefficient => this.ResolveProperty("HVEngineDampCoef")?.GetValueAsFloat() ?? 0.0f;
        public float HVEngineDampPower => this.ResolveProperty("HVEngineDampPow")?.GetValueAsFloat() ?? 0.0f;
        public string Info => this.ResolveProperty("Info")?.Value;
        public bool IsAccessible => this.ResolveProperty("IsAccessible")?.GetValueAsBoolean() ?? false;
        public bool IsIgnoreLC => this.ResolveProperty("IsIgnoreLC")?.GetValueAsBoolean() ?? false;
        public bool IsLockable => this.ResolveProperty("IsLockable")?.GetValueAsBoolean() ?? false;
        public bool IsOxygenTight => this.ResolveProperty("IsOxygenTight")?.GetValueAsBoolean() ?? true;
        public int LootList => this.ResolveProperty("LootList")?.GetValueAsInt32() ?? 0;
        public float Mass => this.ResolveProperty("Mass")?.GetValueAsFloat() ?? 1.0f;
        public Material Material => this.ResolveProperty("Material")?.Value?.ToMaterial() ?? Material.ResourceMedium;
        public int MaxCount => this.ResolveProperty("MaxCount")?.GetValueAsInt32() ?? 0;
        public float MaxVolumeCapacity => this.ResolveProperty("MaxVolumeCapacity")?.GetValueAsFloat() ?? 0.0f;
        public string[] O2Accept => this.ResolveProperty("O2Accept")?.GetValueAsList();
        public int O2Capacity => this.ResolveProperty("O2Capacity")?.GetValueAsInt32() ?? 0;
        public int PanelAngle => this.ResolveProperty("PanelAngle")?.GetValueAsInt32() ?? 0;
        public float Radiation => this.ResolveProperty("Radiation")?.GetValueAsFloat() ?? 0.0f;
        public float ReturnFactor => this.ResolveProperty("ReturnFactor")?.GetValueAsFloat() ?? 0.0f;
        public int RotationSpeed => this.ResolveProperty("RotSpeed")?.GetValueAsInt32() ?? 0;
        public int ShieldCapacity => this.ResolveProperty("ShieldCapacity")?.GetValueAsInt32() ?? 0;
        public int ShieldCooldown => this.ResolveProperty("ShieldCooldown")?.GetValueAsInt32() ?? 0;
        public int ShieldPerCrystal => this.ResolveProperty("ShieldPerCrystal")?.GetValueAsInt32() ?? 0;
        public int ShieldRecharge => this.ResolveProperty("ShieldRecharge")?.GetValueAsInt32() ?? 0;
        public bool ShowBlockName => this.ResolveProperty("ShowBlockName")?.GetValueAsBoolean() ?? false;
        public float SolarPanelEfficiency => this.ResolveProperty("SolarPanelEfficiency")?.GetValueAsFloat() ?? 0.0f;
        public int StackSize => this.ResolveProperty("StackSize")?.GetValueAsInt32() ?? 1;
        public string[] TechTreeNames => this.ResolveProperty("TechTreeNames")?.GetValueAsList();
        public string TechTreeParent => this.ResolveProperty("TechTreeParent")?.Value;
        public int Temperature => this.ResolveProperty("Temperature")?.GetValueAsInt32() ?? 0;
        public int TemperatureGain => this.ResolveProperty("TemperatureGain")?.GetValueAsInt32() ?? 0;
        public string TemplateRoot => this.ResolveProperty("TemplateRoot")?.Value;
        public int ThrusterForce => this.ResolveProperty("ThrusterForce")?.GetValueAsInt32() ?? 0;
        public int Torque => this.ResolveProperty("Torque")?.GetValueAsInt32() ?? 0;
        public bool TurretTargetIngore => this.ResolveProperty("TurretTargetIgnore")?.GetValueAsBoolean() ?? false;
        public int UnlockCost => this.ResolveProperty("UnlockCost")?.GetValueAsInt32() ?? 0;
        public int UnlockLevel => this.ResolveProperty("UnlockLevel")?.GetValueAsInt32() ?? 0;
        public float Volume => this.ResolveProperty("Volume")?.GetValueAsFloat() ?? 1.0f;
        public float VolumeCapacity => this.ResolveProperty("VolumeCapacity")?.GetValueAsFloat() ?? 0.0f;
        public string WeaponItem => this.ResolveProperty("WeaponItem")?.Value;
        public float XpFactor => this.ResolveProperty("XpFactor")?.GetValueAsFloat() ?? 0.0f;
        public float Zoom => this.ResolveProperty("Zoom")?.GetValueAsFloat() ?? 0.0f;

        public Block(EmpyrionConfiguration configuration) : base(configuration) { }

        public Block(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header, ConfigurationReader config)
            : base(configuration, header, config) { }


        /*
        protected override EmpyrionObject GetReference()
        {
            if (string.IsNullOrEmpty(this.Reference))
                throw new Exception($"Tried to get a null reference in {this.Type} object {this.Name}.");

            return Configuration.BlocksByID[int.Parse(this.Reference)];
        }
        */
    }
}
