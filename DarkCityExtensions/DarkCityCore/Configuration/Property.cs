using DarkCity.Data;
using System;
using System.Collections.Generic;

namespace DarkCity.Configuration
{
    public class Property
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public Dictionary<string, string> Subproperties { get; private set; } = new Dictionary<string, string>();

        public string Type
        {
            get
            {
                if (this.Subproperties.ContainsKey("type"))
                    return this.Subproperties["type"];
                return null;
            }
        }

        public string Formatter
        {
            get
            {
                if (this.Subproperties.ContainsKey("formatter"))
                    return this.Subproperties["formatter"];
                return null;
            }
        }

        public Property() { }

        public Property(string config)
        {
            this.Load(config);
        }

        public void Load(string config)
        {
            string[] parameters = config.Split(',');
            int i = 0;

            string[] kvp = parameters[i].Split(':');
            if (kvp[1].Trim().StartsWith("\""))
            {
                rejoin(ref parameters, ref i);
                kvp = parameters[i].Split(':');
            }

            this.Key = kvp[0].Trim();
            this.Value = kvp[1].Trim();
            i++;

            for (; i < parameters.Length; i++)
            {
                kvp = parameters[i].Split(':');
                if (kvp[1].Trim().StartsWith("\""))
                {
                    rejoin(ref parameters, ref i);
                    kvp = parameters[i].Split(':');
                }

                this.Subproperties[kvp[0].Trim()] = kvp[1].Trim();
            }
        }

        private void rejoin(ref string[] parameters, ref int i)
        {
            List<string> parts = new List<string>();
            while ((i < parameters.Length) && !parameters[i].EndsWith("\""))
                parts.Add(parameters[i++]);
            if (i == parameters.Length)
                i = parameters.Length - 1;
            else
                parts.Add(parameters[i]);
            parameters[i] = string.Join<string>(",", parts);
        }

        public override string ToString()
        {
            string[] parts = new string[this.Subproperties.Count + 1];
            int i = 1;
            parts[0] = $"{this.Key}: {this.Value}";
            foreach (KeyValuePair<string, string> kvp in this.Subproperties)
                parts[i++] = $"{kvp.Key}: {kvp.Value}";
            return string.Join<string>(", ", parts);
        }

        public string GetLocalizedFormatter(Localization localization)
        {
            switch (this.Formatter?.ToLower())
            {
                case "hardness": return "";
                case "kilogram": return localization.Kilogram;
                case "liter": return localization.Liter;
                case "newton": return localization.Newton;
                case "newtonmeter": return localization.NewtonMeter;
                case "rof": return localization.RPM;
                case "watt": return localization.Watt;
                default: return "";
            }
        }

        public string GetFormattedValue()
        {
            return this.Value.ToString();
        }

        public string ToLocalizedString(Localization localization)
        {
            return $"{this.GetFormattedValue()}{this.GetLocalizedFormatter(localization)}";
        }

        public string[] ToArray()
        {
            if (string.IsNullOrWhiteSpace(this.Value))
                return null;

            return this.Value.Trim('"').Split(',');
        }
    }
}
