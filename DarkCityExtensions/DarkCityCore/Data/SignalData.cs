namespace DarkCity.Data
{
    public class SignalData
    {
        public string Name { get; set; }
        public VectorInt3 blockPosition;
        public int Index { get; set; }
        public bool State { get; set; }

        public SignalData() { }

        public override string ToString()
        {
            return $"{this.Name} {this.blockPosition} {this.Index} {this.State}";
        }
    }
}
