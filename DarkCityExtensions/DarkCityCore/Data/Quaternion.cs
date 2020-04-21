namespace DarkCity.Data
{
    public struct Quaternion
    {
        public float w, x, y, z;

        public Quaternion(float w, float x, float y, float z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"[{w},{x},{y},{z}]";
        }
    }
}
