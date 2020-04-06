using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DarkCity.Configuration
{
    public class EmpyrionConfiguration
    {
        private char[] superTrim = new char[] { ' ', '\t', '{', '}', ':' };

        public int Version { get; set; }

        public Dictionary<string, EmpyrionObject> ObjectsByKey { get; set; } = new Dictionary<string, EmpyrionObject>();
        public Dictionary<int, EmpyrionObject> ObjectsByID { get; set; } = new Dictionary<int, EmpyrionObject>();
        public Dictionary<string, EmpyrionObject> ObjectsByName { get; set; } = new Dictionary<string, EmpyrionObject>();
        public Dictionary<int, Block> BlocksByID { get; set; } = new Dictionary<int, Block>();
        public Dictionary<string, Block> BlocksByName { get; set; } = new Dictionary<string, Block>();
        public Dictionary<int, EmpyrionObject> ContainersByID { get; set; } = new Dictionary<int, EmpyrionObject>();
        public Dictionary<string, EmpyrionObject> EntitiesByName { get; set; } = new Dictionary<string, EmpyrionObject>();
        public Dictionary<int, EmpyrionObject> ItemsByID { get; set; } = new Dictionary<int, EmpyrionObject>();
        public Dictionary<string, EmpyrionObject> ItemsByName { get; set; } = new Dictionary<string, EmpyrionObject>();
        public Dictionary<string, EmpyrionObject> LootGroupsByName { get; set; } = new Dictionary<string, EmpyrionObject>();
        public Dictionary<string, CraftingTemplate> TemplatesByName { get; set; } = new Dictionary<string, CraftingTemplate>();

        public EmpyrionConfiguration()
        {
            this.Version = 8;
        }

        public EmpyrionConfiguration(string path) : this()
        {
            this.Load(path);
        }

        public void Load(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                ConfigurationReader reader = new ConfigurationReader(file);
                KeyValuePair<string, string> line = reader.ReadParsedLine();
                while (line.Key != null)
                {
                    if (line.Key == "{")
                    {
                        // Line starts the definition of a new object. Detect the object type and pass control to the object for reading its configuration.
                        Tuple<EmpyrionObjectType, int?, string, string> header = ParseObjectHeader(line.Value);
                        string key = (header.Item2?.ToString() ?? "") + header.Item3;
                        if (this.ObjectsByKey.ContainsKey(key))
                        {
                            this.ObjectsByKey[key].ParseConfig(reader);
                        }
                        else
                        {
                            EmpyrionObject obj = null;
                            switch (header.Item1)
                            {
                                case EmpyrionObjectType.Block:
                                    Block block = new Block(this, header, reader);
                                    obj = block;
                                    this.BlocksByID[block.ID ?? -1] = block;
                                    this.BlocksByName[block.Name] = block;
                                    break;

                                case EmpyrionObjectType.Container:
                                    obj = new EmpyrionObject(this, header, reader);
                                    this.ContainersByID[obj.ID ?? -1] = obj;
                                    break;

                                case EmpyrionObjectType.Entity:
                                    obj = new EmpyrionObject(this, header, reader);
                                    this.EntitiesByName[obj.Name] = obj;
                                    break;

                                case EmpyrionObjectType.Item:
                                    obj = new EmpyrionObject(this, header, reader);
                                    this.ItemsByID[obj.ID ?? -1] = obj;
                                    this.ItemsByName[obj.Name] = obj;
                                    break;

                                case EmpyrionObjectType.LootGroup:
                                    obj = new EmpyrionObject(this, header, reader);
                                    this.LootGroupsByName[obj.Name] = obj;
                                    break;

                                case EmpyrionObjectType.Template:
                                    CraftingTemplate template = new CraftingTemplate(this, header, reader);
                                    obj = template;
                                    this.TemplatesByName[template.Name] = template;
                                    break;

                                default: obj = new EmpyrionObject(this, header, reader); break;
                            }

                            this.ObjectsByKey[obj.Key] = obj;
                            if (obj.ID != null) this.ObjectsByID[obj.ID ?? -1] = obj;
                            if (!string.IsNullOrWhiteSpace(obj.Name)) this.ObjectsByName[obj.Name] = obj;
                        }
                    }
                    else if (line.Key.ToLower() == "version")
                    {
                        this.Version = Int32.Parse(line.Value);
                    }
                    else
                    {
                        throw new Exception($"Unparsable line encountered: {line}");
                    }

                    line = reader.ReadParsedLine();
                }
            }
        }

        private void SkipObject(StreamReader file)
        {
            string line;
            do
            {
                line = file.ReadLine();
                if (string.IsNullOrEmpty(line)) return;
                line = line.Trim();
                if (line.StartsWith("{"))
                    // Encountered a sub-object. Skip that too.
                    this.SkipObject(file);
            } while (!line.StartsWith("}"));
        }

        private static Regex objectParse = new Regex(@"[\s{]*(?<type>block|item|entity|template|container|lootgroup)\s+(?:id:\s*(?<id>\d+))?,?\s*(?:name:\s*(?<name>[^\s,]+))?,?\s*(?:ref:\s*(?<ref>\S+))?", RegexOptions.IgnoreCase);
        public static Tuple<EmpyrionObjectType, int?, string, string> ParseObjectHeader(string header)
        {
            Match m = objectParse.Match(header);
            if (m.Success)
            {
                return new Tuple<EmpyrionObjectType, int?, string, string>(
                    m.Groups["type"].Value.ToEmpyrionObjectType(),
                    (m.Groups["id"]?.Success ?? false) ? (int?)int.Parse(m.Groups["id"].Value) : null,
                    (m.Groups["name"]?.Success ?? false) ? m.Groups["name"].Value : null,
                    (m.Groups["ref"]?.Success ?? false) ? m.Groups["ref"].Value : null);
            }
            else
            {
                throw new Exception($"Unable to parse object header: {header}");
            }
        }

        public static EmpyrionObjectType DetectObjectType(string header)
        {
            string[] words = header.Split(' ');
            return words[0].ToEmpyrionObjectType();
        }
    }
}
