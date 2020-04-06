using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCity.Configuration
{
    public class ConfigurationReader
    {
        /// <summary>
        /// Array of characters that can be trimmed from a line prior to splitting it into a key/value pair.
        /// </summary>
        protected static char[] trimChars = new char[] { ' ', '\t', '"', '\r', '\n' };

        /// <summary>
        /// Characters to use as the separator when splitting a line into a key/value pair.
        /// </summary>
        protected static char[] splitValueChars = new char[] { ':' };

        /// <summary>
        /// Characters to use as the sparator when splitting a line into an object header.
        /// </summary>
        protected static char[] splitObjectChars = new char[] { ' ' };

        private StreamReader configFile;

        public ConfigurationReader(StreamReader configFile)
        {
            this.configFile = configFile;
        }

        /// <summary>
        /// Reads the next line of the config file that contains data. The line is trimmed of whitespace.
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {
            string line, trim;
            do
            {
                line = this.configFile.ReadLine();
                if (line == null) return null; // End of file reached.
                if (string.IsNullOrWhiteSpace(line)) continue; // Ignore empty lines.

                trim = line.Trim();
                if (trim.StartsWith("#")) continue; // Ignore comments.
                return trim;
            } while (line != null);
            return null;
        }

        /// <summary>
        /// Gets a <see cref="KeyValuePair{TKey, TValue}"/> represneting the next line with data. The contents of the KVP depend on what the next line is.
        ///   { string, string } - Line is a key value pair.
        ///   { "{", string } - Line is an object header. Value contains the object header.
        ///   { "}", null } - Line is an object closer.
        ///   { null, null } - End of configuration file.
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<string, string> ReadParsedLine()
        {
            string line = this.ReadLine(); // Already trimmed.
            if (line == null) return new KeyValuePair<string, string>(null, null);
            if (line.StartsWith("}")) return new KeyValuePair<string, string>("}", null); // End of object indicator.
            else if (line.StartsWith("{"))
            {
                // Line is an object header.
                return new KeyValuePair<string, string>("{", line.TrimStart('{', ' '));
            } else
            {
                // Line is assumed to be a key/value pair.
                string[] parts = line.Split(splitValueChars, 2);
                if (parts.Length == 1)
                    return new KeyValuePair<string, string>(parts[0], null);
                else
                    return new KeyValuePair<string, string>(parts[0], parts[1]);
            }
        }
    }
}
