using System.Collections.Generic;

namespace DarkCity.Data
{
    public class PlayerData : EntityData
    {
        public string SteamId { get; set; }
        public string StartPlayfield { get; set; }
        public byte Origin { get; set; }
        public int FactionId { get; set; }
        public FactionGroupData FactionGroup { get; set; }
        public FactionRoleData FactionRole { get; set; }
        public float Health { get; set; }
        public float HealthMax { get; set; }
        public float Oxygen { get; set; }
        public float OxygenMax { get; set; }
        public float Stamina { get; set; }
        public float StaminaMax { get; set; }
        public float Food { get; set; }
        public float FoodMax { get; set; }
        public float Radiation { get; set; }
        public float RadiationMax { get; set; }
        public float BodyTemp { get; set; }
        public float BodyTempMax { get; set; }
        public int Kills { get; set; }
        public int Died { get; set; }
        public double Credits { get; set; }
        public int ExperiencePoints { get; set; }
        public int UpgradePoints { get; set; }
        public int Ping { get; set; }
        public int CurrentStructureId { get; set; }
        public int DrivingEntityId { get; set; }
        public bool IsPilot { get; set; }
        public List<ItemStackData> Toolbar { get; set; }
        public List<ItemStackData> Bag { get; set; }

        public PlayerData() : base() { }

        public override string ToString()
        {
            return $"{base.ToString()} - {this.SteamId} {this.StartPlayfield} {this.Origin} {this.FactionId} {this.FactionGroup} {this.FactionRole} {this.Health}/{this.HealthMax} {this.Oxygen}/{this.OxygenMax} {this.Stamina}/{this.StaminaMax} {this.Food}/{this.FoodMax} {this.Radiation}/{this.RadiationMax} {this.BodyTemp}/{this.BodyTempMax} {this.Kills}:{this.Died} {this.Credits} {this.ExperiencePoints} {this.UpgradePoints} {this.Ping} {this.CurrentStructureId} {this.DrivingEntityId} {this.IsPilot} {this.Toolbar?.Count ?? 0} {this.Bag?.Count ?? 0}";
        }
    }
}
