
namespace DarkCity.Data
{
    public class EntityHeader
    {
        public int Id;
        public string Name;
        public EntityTypeData EntityType;
        public Vector3 Position;
        public FactionGroupData FactionGroup;
        public int FactionId;
        
        public EntityHeader() { }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
