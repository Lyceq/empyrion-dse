using Eleon.Modding;

namespace DarkCity.Tokenizers
{
    /// <summary>
    /// Tokenizes an IEntity instance.
    /// </summary>
    public class EntityTokenizer : Tokenizer
    {
        /// <summary>
        /// The IEntity instance that provides the data for token values. Set by the contrustor.
        /// </summary>
        protected IEntity Entity { get; private set; }

        public StructureTokenizer StructureTokens { get; private set; }

        /// <summary>
        /// Creates an EntityTokenizer that provides access to the entity data via token names.
        /// </summary>
        /// <param name="entity">The IEntity instance the provides data values for the tokens.</param>
        public EntityTokenizer(IEntity entity)
        {
            this.Entity = entity;
            if (this.Entity?.Structure != null) this.StructureTokens = new StructureTokenizer(this.Entity.Structure);
            this.Update();
        }

        /// <summary>
        /// Processes Entity data into the token dictionary.
        /// </summary>
        public override void Update()
        {
            if (this.Entity == null)
            {
                DarkCity.LogWarn("Attempted to tokenize a null entity.");
            }
            else
            {
                this.tokens["EntityID"] = this.Entity.Id.ToString();
                this.tokens["Name"] = this.Entity.Name;
                this.TokenizeEntityType(this.Entity.Type, "EntityType");
                
                this.TokenizeVector3(this.Entity.Position, "Position");
                this.TokenizeQuaternion(this.Entity.Rotation, "Heading");
            }
        }

        /// <summary>
        /// Processes a string for tokens and replaces them with the token value. Token names must be enclosed in curly braces. This includes tokens from the entity's structure, if available.
        /// </summary>
        /// <param name="format">The string containing tokens to be replaced.</param>
        /// <returns>A string with the tokens replaced.</returns>
        public override string Tokenize(string format)
        {
            if (this.StructureTokens != null)
                return base.Tokenize(this.StructureTokens.Tokenize(format));
            else
                return base.Tokenize(format);
        }

        /// <summary>
        /// Tokenizes an EntityType, mapping different values fo EntityType to friendly string names.
        /// </summary>
        /// <param name="type">The EntityType to be tokenized.</param>
        /// <param name="key">The key to use for the name of the token.</param>
        private void TokenizeEntityType(EntityType type, string key)
        {
            switch (type)
            {
                case EntityType.Animal: this.tokens[key] = "Animal"; break;
                case EntityType.Asteroid: this.tokens[key] = "Asteroid"; break;
                case EntityType.AstRes: this.tokens[key] = "AstRes"; break;
                case EntityType.AstVoxel: this.tokens[key] = "AstVoxel"; break;
                case EntityType.BA: this.tokens[key] = "BA"; break;
                case EntityType.Civilian: this.tokens[key] = "Civilian"; break;
                case EntityType.CV: this.tokens[key] = "CV"; break;
                case EntityType.Cyborg: this.tokens[key] = "Cyborg"; break;
                case EntityType.DropContainer: this.tokens[key] = "Drop Container"; break;
                case EntityType.EnemyDrone: this.tokens[key] = "Enemy Drone"; break;
                case EntityType.EscapePod: this.tokens[key] = "Escape Pod"; break;
                case EntityType.ExplosiveDevice: this.tokens[key] = "Explosive Device"; break;
                case EntityType.HV: this.tokens[key] = "HV"; break;
                case EntityType.Item: this.tokens[key] = "Item"; break;
                case EntityType.MissionContainer: this.tokens[key] = "Mission Container"; break;
                case EntityType.Player: this.tokens[key] = "Player"; break;
                case EntityType.PlayerBackpack: this.tokens[key] = "Backpack"; break;
                case EntityType.PlayerBike: this.tokens[key] = "Motorcycle"; break;
                case EntityType.PlayerBikeFolded: this.tokens[key] = "Motorcycle"; break;
                case EntityType.PlayerDrone: this.tokens[key] = "Drone"; break;
                case EntityType.Proxy: this.tokens[key] = "Proxy"; break;
                case EntityType.SV: this.tokens[key] = "SV"; break;
                case EntityType.Trader: this.tokens[key] = "Trader"; break;
                case EntityType.TroopTransport: this.tokens[key] = "Troop Transport"; break;
                case EntityType.Turret: this.tokens[key] = "Turret"; break;
                case EntityType.UnderRes: this.tokens[key] = "UnderRes"; break;
                case EntityType.Unknown: this.tokens[key] = "Unknown"; break;
                default: this.tokens[key] = "Really Unknown"; break;
            }
        }
    }
}
