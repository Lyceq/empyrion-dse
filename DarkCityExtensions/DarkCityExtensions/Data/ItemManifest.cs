using Eleon.Modding;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace DarkCity.Data
{
    public class ItemManifest
    {
        public List<ItemStack> Contents { get; private set; } = new List<ItemStack>();

        public ItemManifest() { }

        public void Add(List<ItemStack> inventory)
        {
            this.Contents.AddRange(inventory);
        }

        public void Add(IPlayer player)
        {
            if (player == null) return;
            this.Add(player.Bag);
            this.Add(player.Toolbar);
        }

        public void Add(IContainer container)
        {
            if (container == null) return;
            this.Contents.AddRange(container.GetContent());
        }


        public void Add(IStructure structure)
        {
            IDevicePosList devices = structure.GetDevices(DeviceTypeName.Container);
            if (devices != null)
            {
                for (int i = 0; i < devices.Count; i++)
                    this.Add(structure.GetDevice<IContainer>(devices.GetAt(i)));
            }
        }

        public Dictionary<int, int> GetItemTotals()
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (ItemStack stack in this.Contents)
            {
                if (counts.ContainsKey(stack.id))
                    counts[stack.id] += stack.count;
                else
                    counts[stack.id] = stack.count;
            }

            return counts;
        }
    }
}
