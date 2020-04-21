namespace DarkCity.Data
{
    public struct TankData
    {
        public float capacity, content;
        public bool usesIntegerAmounts;

        public TankData(int capacity, int content, bool usesIntegerAmounts = false)
        {
            this.capacity = capacity;
            this.content = content;
            this.usesIntegerAmounts = usesIntegerAmounts;
        }

        public override string ToString()
        {
            if (this.usesIntegerAmounts)
                return $"{this.content:D}/{this.capacity:D}";
            else
                return $"{this.content:F2}/{this.capacity:F2}";
        }
    }
}
