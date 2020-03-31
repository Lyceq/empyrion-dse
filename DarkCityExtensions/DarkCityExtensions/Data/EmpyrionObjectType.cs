using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpyrionLogistics.Data
{
    public enum EmpyrionObjectType
    {
        Block = 0,
        Item = 1,
        Entity = 2,
        Template = 3,
        Container = 4,
        LootGroup = 5
    }

    public static class EmpyrionObjectTypeExtension
    {
        private readonly static Dictionary<string, EmpyrionObjectType> stringLookup = new Dictionary<string, EmpyrionObjectType>()
        {
            { "block", EmpyrionObjectType.Block },
            { "item", EmpyrionObjectType.Item },
            { "entity", EmpyrionObjectType.Entity },
            { "template", EmpyrionObjectType.Template },
            { "container", EmpyrionObjectType.Container },
            { "lootgroup", EmpyrionObjectType.LootGroup }
        };

        private readonly static Dictionary<EmpyrionObjectType, string> reverseLookup = new Dictionary<EmpyrionObjectType, string>()
        {
            { EmpyrionObjectType.Block, "Block" },
            { EmpyrionObjectType.Item, "Item" },
            { EmpyrionObjectType.Entity, "Entity" },
            { EmpyrionObjectType.Template, "Template" },
            { EmpyrionObjectType.Container, "Container" },
            { EmpyrionObjectType.LootGroup, "LootGroup" }
        };

        public static EmpyrionObjectType ToEmpyrionObjectType(this string s)
        {
            return stringLookup[s.ToLower()];
        }

        public static string ToString(this EmpyrionObjectType t)
        {
            return reverseLookup[t];
        }
    }
}
