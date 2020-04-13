using System.Collections.Generic;
using Eleon.Modding;
using UnityEngine;

namespace DarkCity.Simulation
{
    public class PlayerSimulator : EntitySimulator, IPlayer
    {
        public string SteamId { get; set; }

        public string StartPlayfield { get; set; }

        public byte Origin { get; set; }

        public FactionData FactionData { get; set; }

        public FactionRole FactionRole { get; set; }

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

        public IStructure CurrentStructure { get; set; }

        public IEntity DrivingEntity { get; set; }

        public bool IsPilot { get; set; }

        public List<ItemStack> Toolbar { get; set; }

        public List<ItemStack> Bag { get; set; }

        public PlayerSimulator() { }

        public bool Teleport(string playfield, Vector3 pos, Vector3 rot) { return false; }
        public bool Teleport(Vector3 pos) { return false; }
    }
}
