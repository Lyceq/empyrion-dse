
namespace DarkCity.Data
{
    public class EntityHeader
    {
        public int Id;
        public string Name;
        public string EntityType;
        public Vector3 Position;
        public string FactionGroup;
        public int FactionId;
        
        public EntityHeader() { }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
