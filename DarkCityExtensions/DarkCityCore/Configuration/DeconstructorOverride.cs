using System.Collections.Generic;

namespace DarkCity.Configuration
{
    /// <summary>
    /// Deconstructer override directive. Controls the behavior of the deconstructor when working on a type of item.
    /// </summary>
    public enum DeconstructorOverride
    {
        /// <summary>
        /// Default behavior of the deconstructor. Item will be deconstructed if it is not a base item.
        /// </summary>
        None = 0,

        /// <summary>
        /// Deconstructor will deconstruct this item, even if it is a base item.
        /// </summary>
        Continue = 1,

        /// <summary>
        /// Deconstructor will not deconstruc this item, even if it is not a base item.
        /// </summary>
        Stop = 2
    }

    /// <summary>
    /// Extension methods to assist handling of <see cref="DeconstructorOverride"/>.
    /// </summary>
    public static class DeconstructorOverrideExtension
    {
        /// <summary>
        /// Dictionary of strings to <see cref="DeconstructorOverride"/>.
        /// </summary>
        private readonly static Dictionary<string, DeconstructorOverride> stringLookup = new Dictionary<string, DeconstructorOverride>()
        {
            { "none", DeconstructorOverride.None },
            { "continue", DeconstructorOverride.Continue },
            { "stop", DeconstructorOverride.Stop }
        };

        private readonly static Dictionary<DeconstructorOverride, string> reverseLookup = new Dictionary<DeconstructorOverride, string>()
        {
            { DeconstructorOverride.None, "None" },
            { DeconstructorOverride.Continue, "Continue" },
            { DeconstructorOverride.Stop, "Stop" }
        };

        /// <summary>
        /// Converts a string to <see cref="DeconstructorOverride"/>. Throws an exception if the string cannot be converted.
        /// </summary>
        /// <param name="s">String to be converted to a <see cref="DeconstructorOverride"/>.</param>
        /// <returns>A <see cref="DeconstructorOverride"/> that matches the string.</returns>
        public static DeconstructorOverride ToDeconstructorOverride(this string s)
        {
            return stringLookup[s.ToLower()];
        }

        public static string ToString(this DeconstructorOverride d)
        {
            return reverseLookup[d];
        }
    }
}
