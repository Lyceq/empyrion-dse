using Eleon.Modding;
using System.Collections.Generic;

namespace DarkCity.Data
{
    public static class DataFactory
    {
        public static PlayfieldData PlayfieldData(IPlayfield playfield)
        {
            PlayfieldData data = new PlayfieldData();
            data.Name = playfield.Name;
            data.PlayfieldType = playfield.PlayfieldType.ToString();
            data.PlanetType = playfield.PlanetType.ToString();
            data.PlanetClass = playfield.PlanetClass.ToString();
            data.IsPvP = playfield.IsPvP;
            data.Entities = new List<EntityHeader>(playfield.Entities.Count + playfield.Players.Count);
            foreach (IPlayer player in playfield.Players.Values)
                data.Entities.Add(EntityHeader(player));
            foreach (IEntity entity in playfield.Entities.Values)
                data.Players.Add(EntityHeader(entity));
            return data;
        }

        public static EntityHeader EntityHeader(IEntity entity)
        {
            EntityHeader header = new EntityHeader();
            header.Id = entity.Id;
            header.Name = entity.Name;
            header.EntityType = entity.Type.ToString();
            header.FactionId = entity.Faction.Id;
            header.FactionGroup = entity.Faction.Group.ToString();
            header.Position.x = entity.Position.x;
            header.Position.y = entity.Position.y;
            header.Position.z = entity.Position.z;
            return header;
        }
    }
}
