using System;

namespace DarkCity.Configuration
{
    public class Entity : EmpyrionObject
    {
        public bool IsEnemy => this.ResolveProperty("IsEnemy")?.GetValueAsBoolean() ?? true;
        public int MaxHealth => this.ResolveProperty("MaxHealth")?.GetValueAsInt32() ?? 1;

        public Entity(EmpyrionConfiguration configuration) : base(configuration) { }

        public Entity(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header, ConfigurationReader config)
            : base(configuration, header, config) { }
    }
}
