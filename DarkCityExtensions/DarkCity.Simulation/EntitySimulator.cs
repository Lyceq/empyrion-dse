using Eleon.Modding;
using UnityEngine;

namespace DarkCity.Simulation
{
    public class EntitySimulator : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public FactionData Faction { get; set; }

        public Vector3 position;
        public Vector3 Position { get => this.position; set => this.position = value; }

        public Vector3 forward;
        public Vector3 Forward { get => this.forward; set => this.forward = value; }

        public Quaternion rotation;
        public Quaternion Rotation { get => this.rotation; set => this.rotation = value; }

        public bool IsLocal { get; set; }

        public EntityType Type { get; set; }

        public IStructure Structure { get; set; }

        public EntitySimulator() { }

        public void DamageEntity(int damageAmount, int damageType) { }
        public bool LoadFromDSL() { return false; }
        public void Move(Vector3 direction) { }
        public void MoveForward(float speed) { }
        public void MoveStop() { }

        public override string ToString() => this.Name;
    }
}
