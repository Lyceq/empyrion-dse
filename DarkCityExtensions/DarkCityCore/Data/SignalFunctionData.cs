using System.IO;

namespace DarkCity.Data
{
    public enum BlockFunctionData : byte
    {
        Undefined,
        Powered,
        Unlock,
        Open
    }

    public enum SignalBehaviorData : byte
    {
        Undefined,
        Follow,
        Toggle,
        On,
        Off
    }

    public class SignalFunctionData
    {
        public BlockFunctionData Function { get; set; }
        public SignalBehaviorData Behavior { get; set; }
        public VectorInt3 blockPosition;
        public bool IsInverting { get; set; }

        public SignalFunctionData() { }

        public override string ToString()
        {
            return $"{this.Function} {this.Behavior} {this.blockPosition} {this.IsInverting}";
        }
    }
}
