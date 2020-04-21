namespace DarkCity.Data
{
    public struct VectorInt3
    {
        public int x, y, z;

        public VectorInt3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"({x},{y},{z})";
        }
    }
}
