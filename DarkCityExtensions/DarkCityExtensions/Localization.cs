using Csv;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace DarkCity
{
    public class Localization
    {
        private Dictionary<string, Dictionary<string, string>> localization = new Dictionary<string, Dictionary<string, string>>();
        
        public Dictionary<string, string> SelectedLanguage { get; private set; }
        
        public List<string> Languages { get; private set; }

        public string this[string s]
        {
            get
            {
                if (this.SelectedLanguage.ContainsKey(s))
                    return this.SelectedLanguage[s];
                return null;
            }
        }

        /// <summary>
        /// English: m
        /// </summary>
        public string Meters { get { return this.SelectedLanguage["utsMeters"]; } }

        /// <summary>
        /// English: km
        /// </summary>
        public string Kilometers { get { return this.SelectedLanguage["utsKilometers"]; } }

        /// <summary>
        /// English: AU
        /// </summary>
        public string AU { get { return this.SelectedLanguage["utsAU"]; } }

        /// <summary>
        /// English: N
        /// </summary>
        public string Newton { get { return this.SelectedLanguage["utsNewton"]; } }

        /// <summary>
        /// English: Nm
        /// </summary>
        public string NewtonMeter { get { return this.SelectedLanguage["utsNewtonMeter"]; } }

        /// <summary>
        /// English: sec
        /// </summary>
        public string Second { get { return this.SelectedLanguage["utsSecond"]; } }

        /// <summary>
        /// English: mm
        /// </summary>
        public string Millimeter { get { return this.SelectedLanguage["utsMillimeter"]; } }

        /// <summary>
        /// English: RPM
        /// </summary>
        public string RPM { get { return this.SelectedLanguage["utsRpm"]; } }

        /// <summary>
        /// English: kg
        /// </summary>
        public string Kilogram { get { return this.SelectedLanguage["utsKilogram"]; } }

        /// <summary>
        /// English: t
        /// </summary>
        public string Ton { get { return this.SelectedLanguage["utsTon"]; } }

        /// <summary>
        /// English: kt
        /// </summary>
        public string Kiloton { get { return this.SelectedLanguage["utsKiloton"]; } }

        /// <summary>
        /// English: deg/s²
        /// </summary>
        public string CentigradePerSecondSquare { get { return this.SelectedLanguage["utsCentiDegPerSecSquare"].Replace("[sup]2[/sup]", "²"); } }

        /// <summary>
        /// English: *10^3 km
        /// </summary>
        public string Megameter { get { return this.SelectedLanguage["uts10p3km"]; } }

        /// <summary>
        /// English: M
        /// </summary>
        public string Mega { get { return this.SelectedLanguage["utsMegax"]; } }

        /// <summary>
        /// English: k
        /// </summary>
        public string Kilo { get { return this.SelectedLanguage["utsKilox"]; } }

        /// <summary>
        /// English: m/s²
        /// </summary>
        public string MetersPerSecondSquare { get { return this.SelectedLanguage["utsAccelMetersSecSquare"].Replace("[sup]2[/sup]", "²"); } }

        /// <summary>
        /// English: h
        /// </summary>
        public string Hours { get { return this.SelectedLanguage["utsTimeHourSuffix"]; } }

        /// <summary>
        /// English: m
        /// </summary>
        public string Minutes { get { return this.SelectedLanguage["utsTimeMinuteSuffix"]; } }

        /// <summary>
        /// English: s
        /// </summary>
        public string Seconds { get { return this.SelectedLanguage["utsTimeSecondSuffix"]; } }

        /// <summary>
        /// English: ID:
        /// </summary>
        public string ID { get { return this.SelectedLanguage["vstID"]; } }

        /// <summary>
        /// English: kg/m
        /// </summary>
        public string KilogramPerMeter { get { return this.SelectedLanguage["utsKilogramPerMeter"]; } }

        /// <summary>
        /// English: g
        /// </summary>
        public string Gravity { get { return this.SelectedLanguage["utsGravity"]; } }

        /// <summary>
        /// English: Base
        /// </summary>
        public string Base { get { return this.SelectedLanguage["Base"]; } }

        /// <summary>
        /// English: Capital Vessel
        /// </summary>
        public string CapitalVessel { get { return this.SelectedLanguage["Capital Vessel"]; } }

        /// <summary>
        /// English: Small Vessel
        /// </summary>
        public string SmallVessel { get { return this.SelectedLanguage["Small Vessel"]; } }

        /// <summary>
        /// English: Hover Vessel
        /// </summary>
        public string HoverVessel { get { return this.SelectedLanguage["Hover Vessel"]; } }

        /// <summary>
        /// English: BA
        /// </summary>
        public string BA { get { return this.SelectedLanguage["AbbrevBase"]; } }

        /// <summary>
        /// English: CV
        /// </summary>
        public string CV { get { return this.SelectedLanguage["AbbrevCV"]; } }

        /// <summary>
        /// English: SV
        /// </summary>
        public string SV { get { return this.SelectedLanguage["AbbrevGV"]; } }

        /// <summary>
        /// English: HV
        /// </summary>
        public string HV { get { return this.SelectedLanguage["AbbrevHV"]; } }

        /// <summary>
        /// English: Survival Constructor
        /// </summary>
        public string SurvivalConstructor { get { return this.SelectedLanguage["ttwSuitConstructor"]; } }

        /// <summary>
        /// English: Portable Constructor
        /// </summary>
        public string PortableConstructor { get { return this.SelectedLanguage["ConstructorSurvivalV2"]; } }

        /// <summary>
        /// English: Small Constructor
        /// </summary>
        public string SmallConstructor { get { return this.SelectedLanguage["ConstructorT0"]; } }

        /// <summary>
        /// English: Small Constructor
        /// </summary>
        public string HVConstructor { get { return this.SelectedLanguage["ConstructorHV"]; } }

        /// <summary>
        /// English: Mobile Constructor (SV)
        /// </summary>
        public string SVConstructor { get { return this.SelectedLanguage["ConstructorSV"]; } }

        /// <summary>
        /// English: Large Constructor
        /// </summary>
        public string LargeConstructor { get { return this.SelectedLanguage["ConstructorT1V2"]; } }

        /// <summary>
        /// English: Advanced Constructor
        /// </summary>
        public string AdvancedConstructor { get { return this.SelectedLanguage["ConstructorT2"]; } }

        /// <summary>
        /// English: Food Processor
        /// </summary>
        public string FoodProcessor { get { return this.SelectedLanguage["FoodProcessorV2"]; } }

        /// <summary>
        /// English: Furnace
        /// </summary>
        public string Furnace { get { return this.SelectedLanguage["Furnace"]; } }

        /// <summary>
        /// English: Deconstructor
        /// </summary>
        public string Deconstructor { get { return this.SelectedLanguage["Deconstructor"]; } }

        public Localization(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                CsvOptions options = new CsvOptions();
                //options.HeaderMode = HeaderMode.HeaderAbsent;

                //IEnumerator<ICsvLine> lines = CsvReader.Read(file, options).GetEnumerator();

                // Process header
                //ICsvLine header = lines.Current;
                //header.

                foreach (ICsvLine line in CsvReader.Read(file))
                {
                    if (this.localization == null)
                    {
                        this.Languages = new List<string>(line.Headers);
                        this.Languages.RemoveAt(0); // Remove the key index.

                        if (line.Headers[0] != "KEY")
                            throw new Exception("Empyrion localization file is not in the expected format.");

                        // Prepare dictionaries for each language.
                        for (int i = 1; i < line.Headers.Length; i++)
                            this.localization[line.Headers[i]] = new Dictionary<string, string>();
                    }

                    // Each line of the localization file contains a phrase, with each field being a different language of the prhase.
                    // The first field (phrase[0]) is the lookup key of that phrase.
                    for (int i = 1; i < line.ColumnCount; i++)
                        this.localization[line.Headers[i]][line[0]] = line[i];
                }
            }

            this.SelectLanguage(this.Languages[0]);
        }

        public void SelectLanguage(string language)
        {
            if (!this.localization.ContainsKey(language))
                throw new Exception($"The language {language} is not supported by the Empyrion localization database.");

            this.SelectedLanguage = this.localization[language];
        }
    }
}
