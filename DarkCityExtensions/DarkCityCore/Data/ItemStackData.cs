namespace DarkCity.Data
{
    public class ItemStackData
    {
        public int ItemId { get; set; }
        public int Count { get; set; }
        public byte SlotIndex { get; set; }
        public int Ammo { get; set; }
        public int Decay { get; set; }

        public ItemStackData() { }

        public override string ToString()
        {
            return $"{this.ItemId} {this.Count} {this.SlotIndex} {this.Ammo} {this.Decay}";
        }
    }
}
