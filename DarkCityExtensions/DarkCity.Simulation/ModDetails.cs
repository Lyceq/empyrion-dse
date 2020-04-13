using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DarkCity.Simulation
{
    [Flags]
    public enum ModTargets
    {
        None = 0,
        DedicatedServer = 1,
        PlayfieldServer = 2,
        Client = 4
    }

    public class ModDetails
    {
        public DirectoryInfo ModPath { get; private set; }
        public string AssemblyPath { get; private set; }
        public string ShortName { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public string Version { get; private set; }
        public string Website { get; private set; }
        public ModTargets ModTargets { get; private set; }
        public Assembly Assembly { get; private set; }
        public List<Type> ModTypes { get; private set; }
        public string LoadError { get; private set; }

        public ModDetails(string path)
        {
            this.ModPath = new DirectoryInfo(path);
            this.ShortName = this.ModPath.Name;
            if (!this.ModPath.Exists)
            {
                this.LoadError = $"The directory {path} does not exist.";
                return;
            }

            try
            {
                this.LoadInfo();

                this.AssemblyPath = Path.Combine(this.ModPath.FullName, this.ShortName + ".dll");
                string symbolsPath = Path.Combine(this.ModPath.FullName, this.ShortName + ".pdb");
                //if (File.Exists(symbolsPath))
                //    this.Assembly = Assembly.Load(File.ReadAllBytes(this.AssemblyPath), File.ReadAllBytes(symbolsPath));
                //else
                    this.Assembly = Assembly.LoadFile(this.AssemblyPath);
                
                this.ModTypes = new List<Type>();
                foreach (Type type in this.Assembly.GetExportedTypes())
                {
                    foreach (Type iface in type.GetInterfaces())
                    {
                        if ((iface.Name == "IMod") || (iface.Name == "ModInterface"))
                        {
                            this.ModTypes.Add(type);
                            break;
                        }
                    }
                }
            } catch (Exception ex)
            {
                this.LoadError = ex.Message;
            }
        }

        protected void LoadInfo()
        {
            using (FileStream file = File.OpenRead(Path.Combine(this.ModPath.FullName, this.ShortName + "_Info.yaml")))
            {
                StreamReader reader = new StreamReader(file);
                string line = reader.ReadLine();
                string[] kvp;
                while (line != null)
                {
                    kvp = line.Split(new char[] { ':' }, 2);
                    if (kvp.Length == 2)
                    {
                        switch (kvp[0].Trim().ToLower())
                        {
                            case "name": this.Name = kvp[1].Trim(); break;
                            case "description": this.Description = kvp[1].Trim(); break;
                            case "author": this.Author = kvp[1].Trim(); break;
                            case "version": this.Version = kvp[1].Trim(); break;
                            case "website": this.Website = kvp[1].Trim(); break;
                            case "modtargets":
                                this.ModTargets = ModTargets.None;
                                kvp = kvp[1].Trim().Split(',');
                                for (int i = 0; i < kvp.Length; i++)
                                {
                                    switch (kvp[i].Trim().ToLower())
                                    {
                                        case "dedi": this.ModTargets |= ModTargets.DedicatedServer; break;
                                        case "pfserver": this.ModTargets |= ModTargets.PlayfieldServer; break;
                                        case "client": this.ModTargets |= ModTargets.Client; break;
                                    }
                                }
                                break;
                        }
                    }

                    line = reader.ReadLine();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.ShortName);
            result.Append("Name: ");
            result.AppendLine(this.Name);
            result.Append("Description: ");
            result.AppendLine(this.Description);
            result.Append("Author: ");
            result.AppendLine(this.Author);
            result.Append("Version: ");
            result.AppendLine(this.Version);
            result.Append("Website: ");
            result.AppendLine(this.Website);
            result.Append("ModTargets: ");
            result.AppendLine(this.ModTargets.ToString());
            result.Append("Types: ");
            if ((this.ModTypes == null) || (this.ModTypes.Count < 1))
                result.AppendLine("None");
            else
                result.AppendLine(string.Join(", ", this.ModTypes));
            if (!string.IsNullOrEmpty(this.LoadError))
            {
                result.Append("Load Error: ");
                result.AppendLine(this.LoadError);
            }
            return result.ToString();
        }
    }
}
