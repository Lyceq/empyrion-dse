using System;
using System.Collections.Generic;

namespace DarkCity.Configuration
{
    public class LootGroup : EmpyrionObject
    {
        public Tuple<int, int> Count => this.ResolveProperty("Count")?.GetValueAsRange() ?? new Tuple<int, int>(0, 0);

        public List<Tuple<string, Tuple<int, int>, float>> Items
        {
            get
            {
                List<Tuple<string, Tuple<int, int>, float>> results = new List<Tuple<string, Tuple<int, int>, float>>();
                int i = 0;
                Property property = this.ResolveProperty("Item_" + i.ToString());
                while (property != null)
                {
                    results.Add(new Tuple<string, Tuple<int, int>, float>(property.Value, property.GetSubpropertyAsRange("data"), property.GetSubpropertyAsFloat("xdata") ?? 1.0f));
                    property = this.ResolveProperty("Item_" + (++i).ToString());
                }
                return results;
            }
        }

        public LootGroup(EmpyrionConfiguration configuration) : base(configuration) { }

        public LootGroup(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header, ConfigurationReader config)
            : base(configuration, header, config) { }
    }
}
