using System;

namespace DarkCity.Configuration
{
    public class Container : EmpyrionObject
    {
        public Tuple<int, int> Count => this.ResolveProperty("Count")?.GetValueAsRange() ?? new Tuple<int, int>(0, 0);
        public bool DestroyOnClose => this.ResolveProperty("DestroyOnClose")?.GetValueAsBoolean() ?? false;
        public string SfxClose => this.ResolveProperty("SfxClose")?.Value;
        public string SfxOpen => this.ResolveProperty("SfxOpen")?.Value;
        public Tuple<int, int> Size => this.ResolveProperty("Size")?.GetValueAsRange() ?? new Tuple<int, int>(0, 0);

        public Container(EmpyrionConfiguration configuration) : base(configuration) { }

        public Container(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header, ConfigurationReader config)
            : base(configuration, header, config) { }

    }
}
