using System;

namespace DarkCity.Configuration
{
    public class Block : EmpyrionObject
    {
        //public override EmpyrionObjectType Type => EmpyrionObjectType.Block;

        public Block(EmpyrionConfiguration configuration) : base(configuration) { }

        public Block(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header, ConfigurationReader config)
            : base(configuration, header, config) { }


        /*
        protected override EmpyrionObject GetReference()
        {
            if (string.IsNullOrEmpty(this.Reference))
                throw new Exception($"Tried to get a null reference in {this.Type} object {this.Name}.");

            return Configuration.BlocksByID[int.Parse(this.Reference)];
        }
        */
    }
}
