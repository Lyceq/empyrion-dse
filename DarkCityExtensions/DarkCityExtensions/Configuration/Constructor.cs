using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCity.Configuration
{
    /// <summary>
    /// A constructor that takes inputs to produce an item from it. Each constructor has a different speed and item templates may allow only specific constructors.
    /// </summary>
    public enum Constructor
    {
        Deconstructor = 0,
        Survival = 1,
        Portable = 2,
        SV = 3,
        HV = 4,
        Base = 5,
        Large = 6,
        Advanced = 7,
        FoodProcessor = 8,
        Furnace = 9
    }

    /// <summary>
    /// Extension methods to support the <see cref="Constructor"/> data type.
    /// </summary>
    public static class ConstructorExtensions
    {
        private readonly static Dictionary<string, Constructor> stringLookup = new Dictionary<string, Constructor>()
        {
            { "", Constructor.Deconstructor },
            { "suitc", Constructor.Survival },
            { "survc", Constructor.Portable },
            { "smallc", Constructor.SV },
            { "hoverc", Constructor.HV },
            { "basec", Constructor.Base },
            { "largec", Constructor.Large },
            { "advc", Constructor.Advanced },
            { "foodp", Constructor.FoodProcessor },
            { "furn", Constructor.Furnace }
        };

        private readonly static Dictionary<Constructor, string> reverseLookup = new Dictionary<Constructor, string>()
        {
            { Constructor.Deconstructor, "" },
            { Constructor.Survival, "SuitC" },
            { Constructor.Portable, "SurvC" },
            { Constructor.SV, "SmallC" },
            { Constructor.HV, "HoverC" },
            { Constructor.Base, "BaseC" },
            { Constructor.Large, "LargeC" },
            { Constructor.Advanced, "AdvC" },
            { Constructor.FoodProcessor, "FoodP" },
            { Constructor.Furnace, "Furn" }
        };

        private readonly static Dictionary<Constructor, float> factorLookup = new Dictionary<Constructor, float>()
        {
            { Constructor.Deconstructor,  0.5f },
            { Constructor.Survival, 1.8f },
            { Constructor.Portable, 1.6f },
            { Constructor.SV, 1.4f },
            { Constructor.HV, 1.4f },
            { Constructor.Base, 1.2f },
            { Constructor.Large, 1.0f },
            { Constructor.Advanced, 0.5f },
            { Constructor.FoodProcessor, 1.0f },
            { Constructor.Furnace, 0.2f }
        };

        /// <summary>
        /// Converts a string to a <see cref="Constructor"/>. Throws an exception if the string cannot be converted.
        /// </summary>
        /// <param name="s">String to be converted to <see cref="Constructor"/>.</param>
        /// <returns>The <see cref="Constructor"/> represented by the string.</returns>
        public static Constructor ToConstructor(this string s)
        {
            return stringLookup[s.ToLower()];
        }

        /// <summary>
        /// Gets the speed factor of a <see cref="Constructor"/>. Determine the construction time of a template by multiplying its CraftTime by this value.
        /// </summary>
        /// <param name="c">Which constructor's speed factor is returned.</param>
        /// <returns>The speed factor of <see cref="Constructor"/> c.</returns>
        public static float SpeedFactor(this Constructor c)
        {
            return factorLookup[c];
        }

        /// <summary>
        /// Converts a <see cref="Constructor"/> to a string. This string is usable in the Config.ecf file.
        /// </summary>
        /// <param name="c"><see cref="Constructor"/> to convert.</param>
        /// <returns>String that represents the constructor in a Config.ecf file.</returns>
        public static string ToString(this Constructor c)
        {
            return reverseLookup[c];
        }

        /// <summary>
        /// Converts the constructor into the localized name of the constructor.
        /// </summary>
        /// <param name="c"><see cref="Constructor"/> to convert.</param>
        /// <param name="l">Localization data used to determine the language text returned.</param>
        /// <returns></returns>
        public static string ToLocalizedString(this Constructor c, Localization l)
        {
            switch(c)
            {
                case Constructor.Advanced: return l.AdvancedConstructor;
                case Constructor.Base: return l.SmallConstructor;
                case Constructor.Deconstructor: return l.Deconstructor;
                case Constructor.FoodProcessor: return l.FoodProcessor;
                case Constructor.Furnace: return l.Furnace;
                case Constructor.HV: return l.HVConstructor;
                case Constructor.Large: return l.LargeConstructor;
                case Constructor.Portable: return l.PortableConstructor;
                case Constructor.Survival: return l.SurvivalConstructor;
                case Constructor.SV: return l.SVConstructor;
                default: return "<invalid>";
            }
        }
    }
}
