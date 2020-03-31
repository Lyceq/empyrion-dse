using System;
using System.Reflection;

namespace EmpyrionLogistics.Data
{
    public abstract class EmpyrionObject
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

        public int? ID { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// The <see cref="EmpyrionObject"/> used as a reference for this object. If this object does not have a value set,
        /// then the value is looked up from the reference object.
        /// </summary>
        public string Reference { get; set; }

        public abstract EmpyrionObjectType Type { get; }

        public EmpyrionObject(EmpyrionConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public EmpyrionObject(EmpyrionConfiguration configuration, Tuple<EmpyrionObjectType, int?, string, string> header)
        {
            if (this.Type != header.Item1)
                throw new Exception("Assigned an object header to the wrong object type.");

            this.Configuration = configuration;
            this.ID = header.Item2;
            this.Name = header.Item3;
            this.Reference = header.Item4;
        }

        protected T GetReferenceValue<T>(string property)
        {
            if (this.Reference == null) return default(T);
            return (T)this.GetReference().GetType().GetProperty(property).GetValue(this.Reference);
        }

        protected abstract EmpyrionObject GetReference();
    }
}
