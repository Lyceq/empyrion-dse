using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCity.Data
{
    public enum MaterialType
    {
        ResourceSoft = 0,
        ResourceMedium = 1,
        ResourceHard = 2,
        Metal = 3,
        MetalLight = 4,
        MetalHard = 5,
        Hull = 6,
        HullArmored = 7,
        HullCombat = 8,
        Concrete = 9,
        ConcreteArmored = 10,
        Human = 11,
        Alien = 12,
        Fertile = 13,
        Plants = 14,
        Plastic = 15,
        WoodBlock = 16
    }

    /// <summary>
    /// Extension methods to assist handling of <see cref="MaterialType"/>.
    /// </summary>
    public static class MaterialTypeExtension
    {
        /// <summary>
        /// Dictionary of strings to <see cref="MaterialType"/>.
        /// </summary>
        private readonly static Dictionary<string, MaterialType> stringLookup = new Dictionary<string, MaterialType>()
        {
            { "resourcesoft", MaterialType.ResourceSoft },
            { "resourcemedium", MaterialType.ResourceMedium },
            { "resourcehard", MaterialType.ResourceHard },
            { "metal", MaterialType.Metal },
            { "metallight", MaterialType.MetalLight },
            { "metalhard", MaterialType.MetalHard },
            { "hull", MaterialType.Hull },
            { "hullarmored", MaterialType.HullArmored },
            { "hullcombat", MaterialType.HullCombat },
            { "concrete", MaterialType.Concrete },
            { "concretearmored", MaterialType.ConcreteArmored },
            { "human", MaterialType.Human },
            { "alien", MaterialType.Alien },
            { "fertile", MaterialType.Fertile },
            { "plants", MaterialType.Plants },
            { "plastic", MaterialType.Plastic },
            { "woodblock", MaterialType.WoodBlock }
        };

        private readonly static Dictionary<MaterialType, string> reverseLookup = new Dictionary<MaterialType, string>()
        {
            { MaterialType.ResourceSoft, "" },
            { MaterialType.ResourceMedium, "" },
            { MaterialType.ResourceHard, "" },
            { MaterialType.Metal, "" },
            { MaterialType.MetalLight, "" },
            { MaterialType.MetalHard, "" },
            { MaterialType.Hull, "" },
            { MaterialType.HullArmored, "" },
            { MaterialType.HullCombat, "" },
            { MaterialType.Concrete, "" },
            { MaterialType.ConcreteArmored, "" },
            { MaterialType.Human, "" },
            { MaterialType.Alien, "" },
            { MaterialType.Fertile, "" },
            { MaterialType.Plants, "" },
            { MaterialType.Plastic, "" },
            { MaterialType.WoodBlock, "" }
        };

        /// <summary>
        /// Converts a string to <see cref="MaterialType"/>. Throws an exception if the string cannot be converted.
        /// </summary>
        /// <param name="s">String to be converted to a <see cref="MaterialType"/>.</param>
        /// <returns>A <see cref="MaterialType"/> that matches the string.</returns>
        public static MaterialType ToMaterialType(this string s)
        {
            return stringLookup[s.ToLower()];
        }

        public static string ToString(this MaterialType d)
        {
            return reverseLookup[d];
        }
    }
}
