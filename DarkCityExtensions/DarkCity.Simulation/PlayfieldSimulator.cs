using Eleon.Modding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using LibNoise.Builder;

namespace DarkCity.Simulation
{
    public class PlayfieldSimulator : IPlayfield, IPlayfieldDescr
    {
        private System.Random random = new System.Random();

        public string Name { get; set; }

        public string PlayfieldType { get; set; }

        public string PlanetType { get; set; }

        public string PlanetClass { get; set; }

        public int SizeClass { get; set; }

        public bool IsPvP { get; set; }

        public Dictionary<int, IPlayer> Players { get; set; } = new Dictionary<int, IPlayer>();

        public Dictionary<int, IEntity> Entities { get; set; } = new Dictionary<int, IEntity>();

        public TerrainGenerator Terrain { get; set; }

        public string PlayfieldName { get { return this.Name; } set { this.Name = value; } }
        PlayfieldType IPlayfieldDescr.PlayfieldType { get; set; }

        public bool IsInstance => throw new NotImplementedException();

        public event EntityDelegate OnEntityLoaded;
        public event EntityDelegate OnEntityUnloaded;

        public PlayfieldSimulator() { }

        public void AddEntity(IEntity entity)
        {
            this.Entities[entity.Id] = entity;
            if (this.OnEntityLoaded != null)
                this.OnEntityLoaded(entity);
        }

        public void GenerateMap(string type, string planetClass, int sizeClass)
        {
            this.PlayfieldType = type;
            this.PlanetType = type;
            this.PlanetClass = planetClass;
            this.SizeClass = sizeClass;

            this.Terrain = new TerrainGenerator();
            this.Terrain.Width = (int)Math.Pow(2, sizeClass) * 2000;
            this.Terrain.Height = (int)Math.Pow(2, sizeClass) * 1000;
            this.Terrain.Render();
        }

        public void GeneratePoIs(int count)
        {
            EntitySimulator entity;
            for (int i = 0; i < count; i++)
            {
                entity = new EntitySimulator();
                entity.Id = SimulationHost.NextEntityId;
                entity.Name = "PoI #" + entity.Id.ToString();
                entity.Type = EntityType.BA;
                if (this.Terrain != null)
                {
                    entity.Position = new Vector3(
                        (float)((this.random.NextDouble() * this.Terrain.Width) - (this.Terrain.Width / 2.0)), 0.0f,
                        (float)((this.random.NextDouble() * this.Terrain.Height) - (this.Terrain.Height / 2.0)));
                    entity.position.y = this.GetTerrainHeightAt(entity.Position.x, entity.Position.z);
                }
                this.AddEntity(entity);
            }
        }

        public int AddVoxelArea(Vector3 pos, int sizeInMeter) { return 0; }

        public float GetTerrainHeightAt(float x, float z)
        {
            if (this.Terrain == null)
                return 0.0f;

            // Translate playfield coordinates to map coordinates.
            int mapx = (int)((x + this.Terrain.Width / 2) % this.Terrain.Width);
            int mapz = (int)((z + this.Terrain.Height / 2) % this.Terrain.Height);

            return this.Terrain.Map.GetValue(mapx, mapz) * 250 + 500;
        }

        public bool IsStructureDeviceLocked(int structureId, VectorInt3 posInStruct) { return false; }
        public bool LockStructureDevice(int structureId, VectorInt3 posInStruct, bool doLock, LockResultCallback resultHandler) { return false; }
        public bool MoveVoxelArea(int id, Vector3 pos) { return false; }

        public void RemoveEntity(int entityId)
        {
            if (this.Players.ContainsKey(entityId))
                this.Players.Remove(entityId);

            if (this.Entities.ContainsKey(entityId))
            {
                IEntity entity = this.Entities[entityId];
                this.Entities.Remove(entityId);
                if (this.OnEntityUnloaded != null)
                    this.OnEntityUnloaded(entity);
            }
        }

        public bool RemoveTestPlayer(int entityId)
        {
            if (this.Players.ContainsKey(entityId))
            {
                IPlayer player = this.Players[entityId];
                this.Players.Remove(entityId);
                if (this.OnEntityUnloaded != null)
                    this.OnEntityUnloaded(player);
                return true;
            }

            return false;
        }

        public bool RemoveVoxelArea(int id) { return false; }

        public int SpawnEntity(string entityType, Vector3 pos, Quaternion rot)
        {
            EntitySimulator entity = new EntitySimulator();
            entity.Id = SimulationHost.NextEntityId;
            entity.Name = "Simulated Entity #" + entity.Id.ToString();
            entity.Type = EntityType.Civilian;
            entity.Position = pos;
            entity.Rotation = rot;
            this.AddEntity(entity);
            return entity.Id;
        }

        public int SpawnPrefab(string prefabName, Vector3 pos) { return 0; }

        public int SpawnTestPlayer(Vector3 pos)
        {
            PlayerSimulator player = new PlayerSimulator();
            player.Id = SimulationHost.NextEntityId;
            player.Name = "Simulated Player #" + player.Id.ToString();
            player.Type = EntityType.Player;
            this.Players[player.Id] = player;
            this.AddEntity(player);
            this.Players[player.Id] = player;
            return player.Id;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
