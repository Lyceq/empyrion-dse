using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmpyrionLogistics.Data
{
    public class EmpyrionConfiguration
    {
        private char[] superTrim = new char[] { ' ', '\t', '{', '}', ':' };

        public int Version { get; set; }

        public Dictionary<string, CraftingTemplate> TemplatesByName { get; set; }

        public EmpyrionConfiguration()
        {
            this.Version = 8;
            this.TemplatesByName = new Dictionary<string, CraftingTemplate>();
        }

        public EmpyrionConfiguration(string path) : this()
        {
            this.Load(path);
        }

        public void Load(string path)
        {
            StreamReader file = File.OpenText(path);
            string line = ""; // Raw line of text from file.
            string trim; // Trimmed line of text from file.
            string lower; // Trimmed and lower-cased line of text from file.

            while (line != null)
            {
                line = file.ReadLine();
                trim = line?.Trim();
                lower = trim?.ToLower();
                if (string.IsNullOrEmpty(trim)) continue; // Ignore blank lines.
                else if (lower.StartsWith("#")) continue; // Ignore comments.
                else if (lower.StartsWith("{"))
                {
                    // Line starts the definition of a new object. Detect the object type and pass control to the object for reading its configuration.
                    Tuple<EmpyrionObjectType, int?, string, string> header = ParseObjectHeader(line);
                    switch (header.Item1)
                    {
                        case EmpyrionObjectType.Block: this.SkipObject(file); break;
                        case EmpyrionObjectType.Item: this.SkipObject(file); break;
                        case EmpyrionObjectType.Entity: this.SkipObject(file); break;
                        case EmpyrionObjectType.Template:
                            if (string.IsNullOrEmpty(header.Item3) || !this.TemplatesByName.ContainsKey(header.Item3))
                            {
                                CraftingTemplate template = new CraftingTemplate(this, header, file);
                                this.TemplatesByName[template.Name] = template;
                            } else
                            {
                                this.TemplatesByName[header.Item3].ParseConfig(file);
                            }
                            break;

                        case EmpyrionObjectType.Container: this.SkipObject(file); break;
                        case EmpyrionObjectType.LootGroup: this.SkipObject(file); break;
                        default: throw new Exception($"Unknown object type encountered in line: {line}");
                    }
                } else if (lower.StartsWith("version"))
                {
                    this.Version = Int32.Parse(lower.Replace("version", "").Trim(superTrim));
                } else
                {
                    throw new Exception($"Unparsable line encountered: {line}");
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

        private static Regex objectParse = new Regex(@"[\s{]*(?<type>block|item|entity|template|container|lootgroup)\s+(?:id:\s*(?<id>\d+))?,?\s*(?:name:\s*(?<name>\S+))?,?\s*(?:ref:\s*(?<ref>\S+))?", RegexOptions.IgnoreCase);
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
            } else
            {
                throw new Exception($"Unable to parse object header: {header}");
            }
        }
    }
}
