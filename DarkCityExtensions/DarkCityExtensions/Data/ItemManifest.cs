using Eleon.Modding;
using System;
using System.Collections.Generic;

namespace DarkCity.Data
{
    public class ItemManifest
    {
        public Dictionary<int, int> Items { get; private set; } = new Dictionary<int, int>();

        public ItemManifest() { }

        public void Add(List<ItemStack> stacks)
        {
            if (stacks == null) return;

            foreach (ItemStack stack in stacks)
            {
                if (this.Items.ContainsKey(stack.id))
                    this.Items[stack.id] += stack.count;
                else
                    this.Items[stack.id] = stack.count;
            }
        }

        public void Add(IStructure structure)
        {
            if (structure == null) return;

            IDevicePosList containers = structure.GetDevices(DeviceTypeName.Container);
            if (containers != null)
            {
                for (int i = 0; i < containers.Count; i++)
                {
                    Eleon.Modding.VectorInt3 position = containers.GetAt(i);
                    IContainer container = structure.GetDevice<IContainer>(position);
                    if (container == null) continue;
                    this.Add(container.GetContent());
                }
            }
        }

        public void Add(IPlayer player)
        {
            if (player == null) return;
            this.Add(player.Bag);
            this.Add(player.Toolbar);
        }

    }
}
