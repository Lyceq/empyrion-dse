using System;
using System.Collections.Generic;
using System.IO;

namespace DarkCity.Data
{
    public static class BinaryExtensions
    {

        #region Int32[]

        public static Int32[] ReadInt32Array(this BinaryReader reader)
        {
            Int32[] array = new int[reader.ReadInt32()];
            for (int i = 0; i < array.Length; i++)
                array[i] = reader.ReadInt32();
            return array;
        }

        public static void Write(this BinaryWriter writer, Int32[] array)
        {
            writer.Write(array.Length);
            for (int i = 0; i < array.Length; i++)
                writer.Write(array[i]);
        }

        #endregion

        #region List

        public static List<T> ReadList<T>(this BinaryReader reader, Func<T> readFunction)
        {
            int count = reader.ReadInt32();
            List<T> result = new List<T>(count);
            for (int i = 0; i < count; i++)
                result.Add(readFunction());
            return result;
        }

        public static void Write<T>(this BinaryWriter writer, List<T> list, Action<T> writeFunction)
        {
            writer.Write(list.Count);
            foreach (T item in list)
                writeFunction(item);
        }

        #endregion

        #region Vector3

        public static Vector3 ReadVector3(this BinaryReader reader)
        {
            return new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }

        public static void Write(this BinaryWriter writer, Vector3 vector)
        {
            writer.Write(vector.x);
            writer.Write(vector.y);
            writer.Write(vector.z);
        }

        #endregion

        #region VectorInt3

        public static VectorInt3 ReadVectorInt3(this BinaryReader reader)
        {
            return new VectorInt3(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        }

        public static void Write(this BinaryWriter writer, VectorInt3 vector)
        {
            writer.Write(vector.x);
            writer.Write(vector.y);
            writer.Write(vector.z);
        }

        #endregion

        #region Quaternion

        public static Quaternion ReadQuaternion(this BinaryReader reader)
        {
            Quaternion q = new Quaternion();
            q.w = reader.ReadSingle();
            q.x = reader.ReadSingle();
            q.y = reader.ReadSingle();
            q.z = reader.ReadSingle();
            return q;
        }

        public static void Write(this BinaryWriter writer, Quaternion q)
        {
            writer.Write(q.w);
            writer.Write(q.x);
            writer.Write(q.y);
            writer.Write(q.z);
        }

        #endregion

        #region PlayfieldData

        public static PlayfieldData ReadPlayfieldData(this BinaryReader reader)
        {
            PlayfieldData playfield = new PlayfieldData();
            playfield = new PlayfieldData();
            playfield.Name = reader.ReadString();
            playfield.PlayfieldType = reader.ReadString();
            playfield.PlanetType = reader.ReadString();
            playfield.IsPvP = reader.ReadBoolean();
            playfield.Entities = reader.ReadList<EntityHeader>(() => ReadEntityHeader(reader));
            playfield.Players = reader.ReadList<EntityHeader>(() => ReadEntityHeader(reader));
            return playfield;
        }

        public static void Write(this BinaryWriter writer, PlayfieldData playfield)
        {
            writer.Write(playfield.Name ?? "");
            writer.Write(playfield.PlayfieldType);
            writer.Write(playfield.PlanetType);
            writer.Write(playfield.IsPvP);
            writer.Write<EntityHeader>(playfield.Entities ?? new List<EntityHeader>(), p => Write(writer, p));
            writer.Write<EntityHeader>(playfield.Players ?? new List<EntityHeader>(), p => Write(writer, p));
        }

        #endregion

        #region EntityHeader

        public static EntityHeader ReadEntityHeader(this BinaryReader reader)
        {
            EntityHeader entity = new EntityHeader();
            entity.Id = reader.ReadInt32();
            entity.Name = reader.ReadString();
            entity.EntityType = (EntityTypeData)reader.ReadByte();
            entity.Position = reader.ReadVector3();
            entity.FactionGroup = (FactionGroupData)reader.ReadByte();
            entity.FactionId = reader.ReadInt32();
            return entity;
        }

        public static void Write(this BinaryWriter writer, EntityHeader entity)
        {
            writer.Write(entity.Id);
            writer.Write(entity.Name ?? "");
            writer.Write((byte)entity.EntityType);
            writer.Write(entity.Position);
            writer.Write((byte)entity.FactionGroup);
            writer.Write(entity.FactionId);
        }

        #endregion

        #region EntityData

        public static EntityData ReadEntityData(this BinaryReader reader, EntityData data = null)
        {
            if (data == null) data = new EntityData();
            data.EntityId = reader.ReadInt32();
            data.Name = reader.ReadString();
            data.FactionId = reader.ReadInt32();
            data.FactionGroup = (FactionGroupData)reader.ReadByte();
            data.Position = reader.ReadVector3();
            data.Forward = reader.ReadVector3();
            data.Rotation = reader.ReadQuaternion();
            data.IsLocal = reader.ReadBoolean();
            data.Type = (EntityTypeData)reader.ReadByte();
            return data;
        }

        public static void Write(this BinaryWriter writer, EntityData data)
        {
            writer.Write(data.EntityId);
            writer.Write(data.Name);
            writer.Write(data.FactionId);
            writer.Write((byte)data.FactionGroup);
            writer.Write(data.Position);
            writer.Write(data.Forward);
            writer.Write(data.Rotation);
            writer.Write(data.IsLocal);
            writer.Write((byte)data.Type);
        }

        #endregion

        #region PlayerData

        public static PlayerData ReadPlayerData(this BinaryReader reader)
        {
            PlayerData data = new PlayerData();
            reader.ReadEntityData(data);
            data.SteamId = reader.ReadString();
            data.StartPlayfield = reader.ReadString();
            data.Origin = reader.ReadByte();
            data.FactionId = reader.ReadInt32();
            data.FactionGroup = (FactionGroupData)reader.ReadByte();
            data.FactionRole = (FactionRoleData)reader.ReadByte();
            data.Health = reader.ReadSingle();
            data.HealthMax = reader.ReadSingle();
            data.Oxygen = reader.ReadSingle();
            data.OxygenMax = reader.ReadSingle();
            data.Stamina = reader.ReadSingle();
            data.StaminaMax = reader.ReadSingle();
            data.Food = reader.ReadSingle();
            data.FoodMax = reader.ReadSingle();
            data.Radiation = reader.ReadSingle();
            data.RadiationMax = reader.ReadSingle();
            data.BodyTemp = reader.ReadSingle();
            data.BodyTempMax = reader.ReadSingle();
            data.Kills = reader.ReadInt32();
            data.Died = reader.ReadInt32();
            data.Credits = reader.ReadDouble();
            data.ExperiencePoints = reader.ReadInt32();
            data.UpgradePoints = reader.ReadInt32();
            data.Ping = reader.ReadInt32();
            data.CurrentStructureId = reader.ReadInt32();
            data.DrivingEntityId = reader.ReadInt32();
            data.IsPilot = reader.ReadBoolean();
            data.Toolbar = reader.ReadList<ItemStackData>(() => reader.ReadItemStackData());
            data.Bag = reader.ReadList<ItemStackData>(() => reader.ReadItemStackData());
            return data;
        }

        public static void Write(this BinaryWriter writer, PlayerData data)
        {
            writer.Write((EntityData)data);
            writer.Write(data.SteamId);
            writer.Write(data.StartPlayfield);
            writer.Write(data.Origin);
            writer.Write(data.FactionId);
            writer.Write((byte)data.FactionGroup);
            writer.Write((byte)data.FactionRole);
            writer.Write(data.Health);
            writer.Write(data.HealthMax);
            writer.Write(data.Oxygen);
            writer.Write(data.OxygenMax);
            writer.Write(data.Stamina);
            writer.Write(data.StaminaMax);
            writer.Write(data.Food);
            writer.Write(data.FoodMax);
            writer.Write(data.Radiation);
            writer.Write(data.RadiationMax);
            writer.Write(data.BodyTemp);
            writer.Write(data.BodyTempMax); 
            writer.Write(data.Kills);
            writer.Write(data.Died);
            writer.Write(data.Credits);
            writer.Write(data.ExperiencePoints);
            writer.Write(data.UpgradePoints);
            writer.Write(data.Ping);
            writer.Write(data.CurrentStructureId);
            writer.Write(data.DrivingEntityId);
            writer.Write(data.IsPilot);
            writer.Write<ItemStackData>(data.Toolbar, (s) => writer.Write(s));
            writer.Write<ItemStackData>(data.Bag, (s) => writer.Write(s));
        }

        #endregion

        #region StructureData

        public static StructureData ReadStructureData(this BinaryReader reader)
        {
            StructureData data = new StructureData();
            reader.ReadEntityData(data);
            data.StructureId = reader.ReadInt32();
            data.EntityId = reader.ReadInt32();
            data.PilotId = reader.ReadInt32();
            data.posMinimum = reader.ReadVectorInt3();
            data.posMaximum = reader.ReadVectorInt3();
            data.IsReady = reader.ReadBoolean();
            data.IsPowered = reader.ReadBoolean();
            data.IsOfflineProtectable = reader.ReadBoolean();
            data.DamageLevel = reader.ReadSingle();
            data.FuelTank = reader.ReadTankData();
            data.OxygenTank = reader.ReadTankData();
            data.PentaxidTank = reader.ReadTankData();
            data.DockedVessels = reader.ReadList<int>(() => reader.ReadInt32());
            data.Passengers = reader.ReadList<int>(() => reader.ReadInt32());
            data.Signals = reader.ReadList<SignalData>(() => reader.ReadSignalData());
            data.SignalReceivers = reader.ReadList<SignalFunctionData>(() => reader.ReadSignalFunctionData());
            return data;
        }

        public static void Write(this BinaryWriter writer, StructureData data)
        {
            writer.Write((EntityData)data);
            writer.Write(data.StructureId);
            writer.Write(data.EntityId);
            writer.Write(data.PilotId);
            writer.Write(data.posMinimum);
            writer.Write(data.posMaximum);
            writer.Write(data.IsReady);
            writer.Write(data.IsPowered);
            writer.Write(data.IsOfflineProtectable);
            writer.Write(data.DamageLevel);
            writer.Write(data.FuelTank);
            writer.Write(data.OxygenTank);
            writer.Write(data.PentaxidTank);
            writer.Write<int>(data.DockedVessels, (d) => writer.Write(d));
            writer.Write<int>(data.Passengers, (d) => writer.Write(d));
            writer.Write<SignalData>(data.Signals, (s) => writer.Write(s));
            writer.Write<SignalFunctionData>(data.SignalReceivers, (s) => writer.Write(s));

        }

        #endregion

        #region TankData

        public static TankData ReadTankData(this BinaryReader reader)
        {
            TankData tank = new TankData();
            tank.capacity = reader.ReadSingle();
            tank.content = reader.ReadSingle();
            tank.usesIntegerAmounts = reader.ReadBoolean();
            return tank;
        }

        public static void Write(this BinaryWriter writer, TankData tank)
        {
            writer.Write(tank.capacity);
            writer.Write(tank.content);
            writer.Write(tank.usesIntegerAmounts);
        }

        #endregion

        #region SignalData

        public static SignalData ReadSignalData(this BinaryReader reader)
        {
            SignalData signal = new SignalData();
            signal.Name = reader.ReadString();
            signal.blockPosition = reader.ReadVectorInt3();
            signal.Index = reader.ReadInt32();
            signal.State = reader.ReadBoolean();
            return signal;
        }

        public static void Write(this BinaryWriter writer, SignalData signal)
        {
            writer.Write(signal.Name);
            writer.Write(signal.blockPosition);
            writer.Write(signal.Index);
            writer.Write(signal.State);
        }

        #endregion

        #region SignalFunction

        public static SignalFunctionData ReadSignalFunctionData(this BinaryReader reader)
        {
            SignalFunctionData data = new SignalFunctionData();
            data.Function = (BlockFunctionData)reader.ReadByte();
            data.Behavior = (SignalBehaviorData)reader.ReadByte();
            data.blockPosition = reader.ReadVectorInt3();
            data.IsInverting = reader.ReadBoolean();
            return data;
        }

        public static void Write(this BinaryWriter writer, SignalFunctionData signal)
        {
            writer.Write((byte)signal.Function);
            writer.Write((byte)signal.Behavior);
            writer.Write(signal.blockPosition);
            writer.Write(signal.IsInverting);
        }

        #endregion

        #region ItemStack

        public static ItemStackData ReadItemStackData(this BinaryReader reader)
        {
            ItemStackData data = new ItemStackData();
            data.ItemId = reader.ReadInt32();
            data.Count = reader.ReadInt32();
            data.SlotIndex = reader.ReadByte();
            data.Ammo = reader.ReadInt32();
            data.Decay = reader.ReadInt32();
            return data;
        }

        public static void Write(this BinaryWriter writer, ItemStackData data)
        {
            writer.Write(data.ItemId);
            writer.Write(data.Count);
            writer.Write(data.SlotIndex);
            writer.Write(data.Ammo);
            writer.Write(data.Decay);
        }

        #endregion
    }
}
