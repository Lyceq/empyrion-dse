using System.Collections.Generic;

namespace DarkCity.Configuration
{
    public enum EmpyrionObjectType
    {
        None = 0,
        Block = 1,
        Item = 2,
        Entity = 3,
        Template = 4,
        Container = 5,
        LootGroup = 6,
        Child = 7
    }

    public static class EmpyrionObjectTypeExtension
    {
        private readonly static Dictionary<string, EmpyrionObjectType> stringLookup = new Dictionary<string, EmpyrionObjectType>()
        {
            { "", EmpyrionObjectType.None },
            { "block", EmpyrionObjectType.Block },
            { "item", EmpyrionObjectType.Item },
            { "entity", EmpyrionObjectType.Entity },
            { "template", EmpyrionObjectType.Template },
            { "container", EmpyrionObjectType.Container },
            { "lootgroup", EmpyrionObjectType.LootGroup },
            { "child", EmpyrionObjectType.Child }
        };

        private readonly static Dictionary<EmpyrionObjectType, string> reverseLookup = new Dictionary<EmpyrionObjectType, string>()
        {
            { EmpyrionObjectType.None, "" },
            { EmpyrionObjectType.Block, "Block" },
            { EmpyrionObjectType.Item, "Item" },
            { EmpyrionObjectType.Entity, "Entity" },
            { EmpyrionObjectType.Template, "Template" },
            { EmpyrionObjectType.Container, "Container" },
            { EmpyrionObjectType.LootGroup, "LootGroup" },
            { EmpyrionObjectType.Child, "Child" }
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
