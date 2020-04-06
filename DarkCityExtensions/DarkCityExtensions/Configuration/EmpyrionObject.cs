using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DarkCity.Configuration
{
    public class EmpyrionObject
    {
        /// <summary>
        /// Array of characters that can be trimmed from a line prior to splitting it into a key/value pair.
        /// </summary>
        protected static char[] trimChars = new char[] { ' ', '\t', '"', '{', '}', '\r', '\n' };

        /// <summary>
        /// Characters to use as the separator when splitting a line into a key/value pair.
        /// </summary>
        protected static char[] splitChars = new char[] { ':' };

        /// <summary>
        /// Characters to use as the separator when splitting a value into list elements.
        /// </summary>
        protected static char[] listSplitChars = new char[] { ',' };

        public EmpyrionConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets an aggregation of the ID and Name. Intended only for use as a dictionary key.
        /// </summary>
        public string Key
        {
            get { return this.ID + this.Name; }
        }

        public EmpyrionObjectType Type { get; protected set; }

        public int? ID { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// The <see cref="EmpyrionObject"/> used as a reference for this object. If this object does not have a value set,
        /// then the value is looked up from the reference object.
        /// </summary>
        public string Reference { get; set; }

        public Dictionary<string, Property> Properties { get; private set; } = new Dictionary<string, Property>();

        public List<EmpyrionObject> Children { get; private set; } = new List<EmpyrionObject>();

        public virtual void ParseConfig(ConfigurationReader config)
        {
            KeyValuePair<string, string> line = config.ReadParsedLine();
            while (line.Key != null)
            {
                if (line.Key == "{")
                {
                    if (string.IsNullOrEmpty(line.Value))
                    {
                        // Just an untyped child object.
                        this.Children.Add(new EmpyrionObject(
                            this.Configuration,
                            new Tuple<EmpyrionObjectType, int?, string, string>(EmpyrionObjectType.None, null, null, null),
                            config));
                    }
                    else
                    {
                        string[] header = line.Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        this.Children.Add(new ChildObject(
                            this.Configuration,
                            new Tuple<EmpyrionObjectType, int?, string, string>(EmpyrionObjectType.Child, null, header[1], null),
                            config));
                    }
                }
                else if (line.Key == "}")
                {
                    // End of this object.
                    return;
                }
                else
                {
                    // Assumed to be a new property.
                    Property p = new Property($"{line.Key}: {line.Value}");
                    this.Properties[p.Key.ToLower()] = p;
                }

                line = config.ReadParsedLine();
            }
        }

        public EmpyrionObject(EmpyrionConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public EmpyrionObject(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header, ConfigurationReader config)
        {
            this.Configuration = configuration;
            this.Type = header.Item1;
            this.ID = header.Item2;
            this.Name = header.Item3;
            this.Reference = header.Item4;
            this.ParseConfig(config);
        }

        /// <summary>
        /// Gets a property of the object. If the property is not set, then resolve the reference chain until the property is found.
        /// </summary>
        /// <param name="property">The name of the property to resolve.</param>
        /// <returns>The resolved property or null if it does not exist in the reference chain.</returns>
        public Property ResolveProperty(string property)
        {
            property = property.ToLower();
            if (this.Properties.ContainsKey(property)) return this.Properties[property];
            return this.GetReference()?.ResolveProperty(property);
        }

        public Dictionary<string, Property> ResolveAllProperties()
        {
            Dictionary<string, Property> result = this.GetReference()?.ResolveAllProperties() ?? new Dictionary<string, Property>();
            foreach (KeyValuePair<string, Property> property in this.Properties)
                result[property.Key] = property.Value;
            return result;
        }

        public virtual EmpyrionObject GetReference()
        {
            if (!string.IsNullOrWhiteSpace(this.Reference) && this.Configuration.ObjectsByName.ContainsKey(this.Reference))
                return this.Configuration.ObjectsByName[this.Reference];
            return null;
        }

        public override string ToString()
        {
            return this.ToString(false);
        }

        public string ToString(bool resolve)
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{{ {EmpyrionObjectTypeExtension.ToString(this.Type)} ");
            List<string> header = new List<string>();
            if (this.ID != null) header.Add($"Id: {this.ID}");
            if (!string.IsNullOrWhiteSpace(this.Name)) header.Add($"Name: {this.Name}");
            if (!string.IsNullOrWhiteSpace(this.Reference)) header.Add($"Ref: {this.Reference}");
            result.AppendLine(string.Join(", ", header));

            foreach (Property p in (resolve ? this.ResolveAllProperties().Values : this.Properties.Values))
                result.AppendLine($"  {p}");

            foreach (EmpyrionObject child in this.Children)
            {
                StringReader s = new StringReader(child.ToString());
                string line = s.ReadLine();
                while (line != null)
                {
                    result.AppendLine($"  {line}");
                    line = s.ReadLine();
                }
            }

            result.AppendLine("}");
            return result.ToString();
        }

    }
}
