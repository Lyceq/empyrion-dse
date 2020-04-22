using Eleon.Modding;
using System.Collections.Generic;

namespace DarkCity.Data
{
    public static class DataFactory
    {
        public static readonly Dictionary<EntityType, EntityTypeData> EntityTypes = new Dictionary<EntityType, EntityTypeData>()
        {
            { EntityType.Animal, EntityTypeData.Animal },
            { EntityType.Asteroid, EntityTypeData.Asteroid },
            { EntityType.AstRes, EntityTypeData.AstRes },
            { EntityType.AstVoxel, EntityTypeData.AstVoxel },
            { EntityType.BA, EntityTypeData.BA },
            { EntityType.Civilian, EntityTypeData.Civilian },
            { EntityType.CV, EntityTypeData.CV },
            { EntityType.Cyborg, EntityTypeData.Cyborg },
            { EntityType.DropContainer, EntityTypeData.DropContainer },
            { EntityType.EnemyDrone, EntityTypeData.EnemyDrone },
            { EntityType.EscapePod, EntityTypeData.EscapePod },
            { EntityType.ExplosiveDevice, EntityTypeData.ExplosiveDevice },
            { EntityType.HV, EntityTypeData.HV },
            { EntityType.Item, EntityTypeData.Item },
            { EntityType.MissionContainer, EntityTypeData.MissionContainer },
            { EntityType.Player,EntityTypeData.Player },
            { EntityType.PlayerBackpack, EntityTypeData.PlayerBackpack },
            { EntityType.PlayerBike, EntityTypeData.PlayerBike },
            { EntityType.PlayerBikeFolded, EntityTypeData.PlayerBikeFolded },
            { EntityType.PlayerDrone, EntityTypeData.PlayerDrone },
            { EntityType.Proxy, EntityTypeData.Proxy },
            { EntityType.SV, EntityTypeData.SV },
            { EntityType.Trader, EntityTypeData.Trader },
            { EntityType.TroopTransport, EntityTypeData.TroopTransport },
            { EntityType.Turret, EntityTypeData.Turret },
            { EntityType.UnderRes, EntityTypeData.UnderRes },
            { EntityType.Unknown, EntityTypeData.Unknown }
        };

        public static readonly Dictionary<FactionGroup, FactionGroupData> FactionGroups = new Dictionary<FactionGroup, FactionGroupData>()
        {
            { FactionGroup.Admin, FactionGroupData.Admin },
            { FactionGroup.Alien, FactionGroupData.Alien },
            { FactionGroup.Faction, FactionGroupData.Faction },
            { FactionGroup.NoFaction, FactionGroupData.NoFaction },
            { FactionGroup.Player, FactionGroupData.Player },
            { FactionGroup.Polaris, FactionGroupData.Polaris },
            { FactionGroup.Predator, FactionGroupData.Predator },
            { FactionGroup.Prey, FactionGroupData.Prey },
            { FactionGroup.Talon, FactionGroupData.Talon },
            { FactionGroup.Zirax, FactionGroupData.Zirax }
        };

        public static PlayfieldData PlayfieldData(IPlayfield playfield)
        {
            PlayfieldData data = new PlayfieldData();
            data.Name = playfield.Name;
            data.PlayfieldType = playfield.PlayfieldType.ToString();
            data.PlanetType = playfield.PlanetType.ToString();
            data.PlanetClass = playfield.PlanetClass.ToString();
            data.IsPvP = playfield.IsPvP;
            data.Entities = new List<EntityHeader>(playfield.Entities.Count);
            foreach (IEntity entity in playfield.Entities.Values)
                data.Entities.Add(EntityHeader(entity));
            data.Players = new List<EntityHeader>(playfield.Players.Count);
            foreach (IPlayer player in playfield.Players.Values)
                data.Players.Add(EntityHeader(player));
            return data;
        }

        public static EntityHeader EntityHeader(IEntity entity)
        {
            EntityHeader header = new EntityHeader();
            header.Id = entity.Id;
            header.Name = entity.Name;
            header.EntityType = EntityTypes[entity.Type];
            header.FactionId = entity.Faction.Id;
            header.FactionGroup = FactionGroups[entity.Faction.Group];
            header.Position.x = entity.Position.x;
            header.Position.y = entity.Position.y;
            header.Position.z = entity.Position.z;
            return header;
        }
    }
}
