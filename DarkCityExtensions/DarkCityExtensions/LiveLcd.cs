using DarkCity.Tokenizers;
using Eleon.Modding;
using System;
using System.Collections.Generic;
using System.IO;

namespace DarkCity
{
    /// <summary>
    /// Enables ILcd devices to display live data about the structure they reside in.
    /// </summary>
    public static class LiveLcd
    {
        private static char[] kvpSeparator = new char[] { ':' };
        private static string liveLcdPhrase = "%LiveLCD%";
        private static string formatPhrase = "BEGIN";

        /// <summary>
        /// Examines an ILcd device to see if it contains LiveLCD code. ILcd devices without code are ignored.
        /// </summary>
        /// <param name="structure">The IStructure instance that the ILcd device resides in.</param>
        /// <param name="source">The ILcd device to be processed for LiveLCD code.</param>
        /// <param name="position">VectorInt3 containing the position of the ILcd device within the structure.</param>
        /// <param name="tokens">Token collection representing data from the parent structure.</param>
        public static void Process(IStructure structure, ILcd source, VectorInt3 position, Tokenizer tokens)
        {
            try
            {
                // Confirm that LCD has been marked as a LiveLCD.
                StringReader config = new StringReader(source.GetText());
                string header = config.ReadLine();
                if ((header == null) || (header.Trim() != liveLcdPhrase)) return;

                DarkCity.LogDebug($"Processing LiveLCD in {structure.Entity.Name} ({structure.Entity.Id}) @ {position}.");
                List<ILcd> targets = new List<ILcd>();

                // Process source LCD configuration.
                string line = config.ReadLine();
                while (line != null)
                {
                    // If the format phrase is found then configuration has finished.
                    line = line.Trim();
                    if (line == formatPhrase) break;

                    // Split the configuration line into a key/value pair.
                    string[] kvp = line.Split(kvpSeparator, 2);
                    if (kvp.Length == 2)
                    {
                        string key = kvp[0].Trim().ToLower();
                        string value = kvp[1].Trim();
                        switch (key)
                        {
                            // Gives the custom name of the LCD device that will display the results of formatted string from this LCD.
                            case "target":
                                ILcd target = structure.GetDevice<ILcd>(value);
                                if (target == null)
                                {
                                    DarkCity.LogDebug($"Could not find LiveLCD target {value}.");
                                }
                                else
                                {
                                    DarkCity.LogDebug($"Found LiveLCD target {value}.");
                                    targets.Add(target);
                                }
                                break;

                            // Ignore unknown config directives.
                            default: DarkCity.LogDebug($"Encountered unknown key {key}; Ignoring."); break;
                        }
                    }

                    line = config.ReadLine();
                }


                // Validate configuration.
                if (targets.Count < 1)
                {
                    DarkCity.LogDebug("Live LCD did not specify a target LCD or it could not be found.");
                    return;
                }

                // Read the rest of the source LCD text as a string format specifier and apply it to the target LCDs.
                string data = tokens.Tokenize(config.ReadToEnd());
                foreach (ILcd target in targets)
                {
                    target?.SetText(data);
                }
            }
            catch (Exception ex)
            {
                DarkCity.LogWarn($"Failed to process LCD due to exception ({ex.GetType()}) : {ex.Message}");
            }
        }
    }
}
