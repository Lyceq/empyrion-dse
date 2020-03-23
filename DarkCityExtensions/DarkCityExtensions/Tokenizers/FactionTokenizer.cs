using Eleon.Modding;

namespace DarkCity.Tokenizers
{
    /// <summary>
    /// Tokenizes a FactionData instance. Currently not tested. Use at your own risk.
    /// </summary>
    public class FactionTokenizer : Tokenizer
    {
        public FactionData Faction { get; private set; }

        public FactionTokenizer(FactionData faction)
        {
            this.Faction = faction;
            this.Update();
        }

        public override void Update()
        {
            this.tokens["FactionId"] = this.Faction.Id.ToString();
            this.TokenizeFactionGroup(this.Faction.Group, "FactionGroup");
        }

        public void TokenizeFactionGroup(FactionGroup group, string key)
        {
            switch (group)
            {
                case FactionGroup.Admin: this.tokens[key] = "Admin"; break;
                case FactionGroup.Alien: this.tokens[key] = "Alien"; break;
                case FactionGroup.Faction: this.tokens[key] = "Faction"; break;
                case FactionGroup.NoFaction: this.tokens[key] = "Unaligned"; break;
                case FactionGroup.Player: this.tokens[key] = "Player"; break;
                case FactionGroup.Polaris: this.tokens[key] = "Polaris"; break;
                case FactionGroup.Predator: this.tokens[key] = "Predator"; break;
                case FactionGroup.Prey: this.tokens[key] = "Prey"; break;
                case FactionGroup.Talon: this.tokens[key] = "Talon"; break;
                case FactionGroup.Zirax: this.tokens[key] = "Zirax"; break;
                default: this.tokens[key] = "Unknown"; break;
            }
        }
    }
}
