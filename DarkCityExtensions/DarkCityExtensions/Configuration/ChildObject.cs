using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCity.Configuration
{
    public class ChildObject : EmpyrionObject
    {
        //public override EmpyrionObjectType Type => EmpyrionObjectType.Child;

        public ChildObject(EmpyrionConfiguration configuraion) : base(configuraion) { }

        public ChildObject(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header, ConfigurationReader config)
            : base(configuration, header, config) { }

        public override EmpyrionObject GetReference()
        {
            return null;
        }

        /*
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("{ Child " + this.Name);
            foreach (Property p in this.Properties.Values)
                result.AppendLine("  " + p.ToString());
            result.AppendLine("}");
            return result.ToString();
        }
        */
    }
}
