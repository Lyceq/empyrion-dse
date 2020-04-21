using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DarkCity.Data
{
    public class SortedRegistry : IEnumerable<string>
    {
        public Dictionary<string, string> Registry = new Dictionary<string, string>();

        public SortedRegistry() { }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (KeyValuePair<string, string> kvp in this.Registry.ToList().OrderBy(s => s.Key))
                yield return kvp.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
