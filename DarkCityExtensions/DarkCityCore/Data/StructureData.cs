using System.Collections.Generic;

namespace DarkCity.Data
{
    public class StructureData : EntityData
    {
        public int StructureId { get; set; }
        public VectorInt3 posMinimum;
        public VectorInt3 posMaximum;
        public bool IsReady { get; set; }
        public bool IsPowered { get; set; }
        public bool IsOfflineProtectable { get; set; }
        public float DamageLevel { get; set; }
        public TankData FuelTank, OxygenTank, PentaxidTank;
        public int PilotId { get; set; }

        public List<int> DockedVessels { get; set; }
        public List<int> Passengers { get; set; }
        public List<SignalData> Signals { get; set; }
        public List<SignalFunctionData> SignalReceivers { get; set; }

        public StructureData() :base() { }

        public override string ToString()
        {
            return $"{base.ToString()} - {this.StructureId} {this.EntityId} {this.PilotId} {this.FuelTank} {this.OxygenTank} {this.PentaxidTank} {this.DockedVessels?.Count ?? 0} {this.Passengers?.Count ?? 0}";
        }
    }
}
