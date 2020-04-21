using System.Collections.Generic;

namespace DarkCity.Configuration
{
    public enum Material
    {
        Alien,
        Concrete,
        ConcreteArmored,
        Fertile,
        Hull,
        HullArmored,
        HullCombat,
        Human,
        Metal,
        MetalHard,
        MetalLight,
        Plants,
        Plastic,
        ResourceHard,
        ResourceMedium,
        ResourceSoft,
        WoodBlock
    }

    public static class MeterialExtensions
    {
        private static readonly Dictionary<string, Material> stringLookup = new Dictionary<string, Material>()
        {
            { "alien", Material.Alien },
            { "concrete", Material.Concrete },
            { "concretearmored", Material.ConcreteArmored },
            { "fertile", Material.Fertile },
            { "hull", Material.Hull },
            { "hullarmored", Material.HullArmored },
            { "hullcombat", Material.HullCombat },
            { "human", Material.Human },
            { "metal", Material.Metal },
            { "metalhard", Material.MetalHard },
            { "metallight", Material.MetalLight },
            { "plants", Material.Plants },
            { "plastic", Material.Plastic },
            { "resourcehard", Material.ResourceHard },
            { "resourcemedium", Material.ResourceMedium },
            { "resourcesoft", Material.ResourceSoft },
            { "woodblock", Material.WoodBlock }
        };

        private static readonly Dictionary<Material, string> reverseLookup = new Dictionary<Material, string>()
        {
            { Material.Alien, "alien" },
            { Material.Concrete, "concrete" },
            { Material.ConcreteArmored, "concretearmored" },
            { Material.Fertile, "fertile" },
            { Material.Hull, "hull" },
            { Material.HullArmored, "hullarmored" },
            { Material.HullCombat, "hullcombat" },
            { Material.Human, "human" },
            { Material.Metal, "metal" },
            { Material.MetalHard, "metalhard" },
            { Material.MetalLight, "metallight" },
            { Material.Plants, "plants" },
            { Material.Plastic, "plastic" },
            { Material.ResourceHard, "resourcehard" },
            { Material.ResourceMedium, "resourcemedium" },
            { Material.ResourceSoft, "resourcesoft" },
            { Material.WoodBlock, "woodblock" }
        };

        public static Material ToMaterial(this string s)
        {
            return stringLookup[s.ToLower()];
        }

        public static string ToString(this Material material)
        {
            return reverseLookup[material];
        }
    }
}
