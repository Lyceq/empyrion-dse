using DarkCity.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkCity.Configuration
{
    public class Property
    {
        private static readonly char[] valueTrimChars = new char[] { ' ', '\t', '"', '\'', '\r', '\n' };

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

        public bool? GetValueAsBoolean()
        {
            bool b;
            if (bool.TryParse(this.Value, out b))
                return b;
            return null;
        }

        public bool? GetSubpropertyAsBoolean(string subproperty)
        {
            if (!this.Subproperties.ContainsKey(subproperty)) return null;
            bool b;
            if (bool.TryParse(this.Subproperties[subproperty], out b))
                return b;
            return null;
        }

        public int? GetValueAsInt32()
        {
            int i;
            if (int.TryParse(this.Value, out i))
                return i;
            return null;
        }

        public int? GetSubpropertyAsInt32(string subproperty)
        {
            if (!this.Subproperties.ContainsKey(subproperty)) return null;
            int i;
            if (int.TryParse(this.Subproperties[subproperty], out i))
                return i;
            return null;
        }

        public float? GetValueAsFloat()
        {
            float f;
            if (float.TryParse(this.Value, out f))
                return f;
            return null;
        }

        public float? GetSubpropertyAsFloat(string subproperty)
        {
            if (!this.Subproperties.ContainsKey(subproperty)) return null;
            float f;
            if (float.TryParse(this.Subproperties[subproperty], out f))
                return f;
            return null;
        }

        public string[] GetValueAsList()
        {
            return this.Value?.Trim(valueTrimChars).Split(',').Select(s => s.Trim()).ToArray();
        }

        public Tuple<int, int> GetValueAsRange()
        {
            try
            {
                string[] values = this.Value?.Trim(valueTrimChars).Split(',');
                if (values != null)
                {
                    if (values.Length == 1)
                    {
                        int i = int.Parse(values[0]);
                        return new Tuple<int, int>(i, i);
                    }
                    else if (values.Length == 2)
                        return new Tuple<int, int>(int.Parse(values[0]), int.Parse(values[1]));
                }
            } catch { }
            return null;
        }

        public Tuple<int, int> GetSubpropertyAsRange(string subproperty)
        {
            if (!this.Subproperties.ContainsKey(subproperty)) return null;
            try
            {
                string[] values = this.Subproperties[subproperty]?.Trim(valueTrimChars).Split(',');
                if (values != null)
                {
                    if (values.Length == 1)
                    {
                        int i = int.Parse(values[0]);
                        return new Tuple<int, int>(i, i);
                    }
                    else if (values.Length == 2)
                        return new Tuple<int, int>(int.Parse(values[0]), int.Parse(values[1]));
                }
            }
            catch { }
            return null;
        }

        public VectorInt3? GetValueAsVectorInt3()
        {
            try
            {
                string[] values = this.Value?.Trim(valueTrimChars).Split(',');
                if ((values != null) && (values.Length == 3))
                    return new VectorInt3(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
            } catch { }
            return null;
        }

        public VectorInt3? GetSubpropertyAsVectorInt3(string subproperty)
        {
            if (!this.Subproperties.ContainsKey(subproperty)) return null;
            try
            {
                string[] values = this.Subproperties[subproperty]?.Trim(valueTrimChars).Split(',');
                if ((values != null) && (values.Length == 3))
                    return new VectorInt3(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
            }
            catch { }
            return null;
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
