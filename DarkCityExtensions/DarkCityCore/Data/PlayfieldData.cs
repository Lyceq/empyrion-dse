using System.Collections.Generic;
using System.Linq;

namespace DarkCity.Data
{
    public class PlayfieldData
    {
        public string Name;
        public string PlayfieldType;
        public string PlanetType;
        public string PlanetClass;
        public bool IsPvP;
        public List<EntityHeader> Entities;
        public List<EntityHeader> Players;

        public PlayfieldData() { }

        public override string ToString()
        {
            return $"{this.Name} {this.PlayfieldType} {this.PlanetType} {this.IsPvP} {string.Join(", ", this.Entities.Select(e => e.Name).ToArray())}";
        }
    }
}
