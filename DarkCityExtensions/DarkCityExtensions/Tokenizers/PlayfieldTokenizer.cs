using Eleon.Modding;
using System;
using System.Text;
using UnityEngine;

namespace DarkCity.Tokenizers
{
    public class PlayfieldTokenizer : Tokenizer
    {
        public IPlayfield Playfield { get; private set; }

        public PlayfieldTokenizer(IPlayfield playfield)
        {
            this.Playfield = playfield;
            this.Update();
        }

        /// <summary>
        /// Updates tokens with basic playfield data. Additional information can be included by invoking the other Update methods.
        /// </summary>
        public override void Update()
        {
            // Clears out tokens of previous updates because there might be data from specific positions or factions.
            this.tokens.Clear();

            if (this.Playfield == null)
            {
                DarkCity.LogWarn("Attempted to tokenize a null playfield.");
            }
            else
            {
                this.tokens["PlayfieldName"] = this.Playfield.Name;
                this.tokens["PlayfieldPvP"] = this.Playfield.IsPvP ? "PvP" : "PvE";
                this.tokens["PlanetClass"] = this.Playfield.PlanetClass;
                this.tokens["PlanetType"] = this.Playfield.PlanetType;
                this.tokens["PlayfieldType"] = this.Playfield.PlayfieldType;
            }
        }

        /// <summary>
        /// Updates tokens with playfield data related to a specific position.
        /// </summary>
        /// <param name="position"></param>
        public void UpdateWithPosition(Vector3 position)
        {
            this.tokens["GroundLevel"] = this.Playfield.GetTerrainHeightAt(position.x, position.z).ToString("F0");
        }

        public void UpdateWithFaction(int factionId)
        {
            StringBuilder list = new StringBuilder();
            foreach (IPlayer player in this.Playfield.Players.Values)
            {
                if (player.Faction.Id != factionId) continue;
                list.Append(player.Name);
                if (player.FactionRole == FactionRole.Admin)
                    list.Append(" [Admin]");
                else if (player.FactionRole == FactionRole.Founder)
                    list.Append(" [Founder]");
                list.Append(Environment.NewLine);
            }

            this.tokens["FactionMembersInPlayfield"] = list.ToString().Trim();
        }
    }
}
