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
            return playfield;
        }

        public static void Write(this BinaryWriter writer, PlayfieldData playfield)
        {
            writer.Write(playfield.Name);
            writer.Write(playfield.PlayfieldType);
            writer.Write(playfield.PlanetType);
            writer.Write(playfield.IsPvP);
            writer.Write<EntityHeader>(playfield.Entities, p => Write(writer, p));
        }

        #endregion

        #region EntityHeader

        public static EntityHeader ReadEntityHeader(this BinaryReader reader)
        {
            EntityHeader entity = new EntityHeader();
            entity.Id = reader.ReadInt32();
            entity.Name = reader.ReadString();
            //entity.Position = reader.ReadVector3();
            //entity.FactionGroup = (FactionGroup)reader.ReadInt32();
            //entity.FactionId = reader.ReadInt32();
            return entity;
        }

        public static void Write(this BinaryWriter writer, EntityHeader entity)
        {
            writer.Write(entity.Id);
            writer.Write(entity.Name);
            //writer.Write(entity.Position);
            //writer.Write((Int32)entity.FactionGroup);
            //writer.Write(entity.FactionId);
        }

        #endregion

    }
}
