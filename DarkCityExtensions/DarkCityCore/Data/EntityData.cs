namespace DarkCity.Data
{
    public enum EntityTypeData : byte
    {
        Unknown,
        Player,
        BA,
        CV,
        SV,
        HV,
        AstRes,
        AstVoxel,
        EscapePod,
        Animal,
        Turret,
        Item,
        PlayerDrone,
        Trader,
        UnderRes,
        EnemyDrone,
        PlayerBackpack,
        DropContainer,
        ExplosiveDevice,
        PlayerBike,
        PlayerBikeFolded,
        Asteroid,
        Civilian,
        Cyborg,
        TroopTransport,
        MissionContainer,
        Proxy
    }

    public class EntityData
    {
        public int EntityId { get; set; }
        public string Name { get; set; }
        public int FactionId { get; set; }
        public FactionGroupData FactionGroup { get; set; }
        public Vector3 Position, Forward;
        public Quaternion Rotation;
        public bool IsLocal { get; set; }
        public EntityTypeData Type { get; set; }

        public EntityData() { }

        public override string ToString()
        {
            return $"{this.EntityId} {this.Name} {this.FactionId} {this.FactionGroup} {this.Position} {this.Forward} {this.Rotation} {this.IsLocal} {this.Type}";
        }
    }
}
