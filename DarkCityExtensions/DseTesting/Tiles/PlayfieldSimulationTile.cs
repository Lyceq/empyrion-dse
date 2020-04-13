using Eleon.Modding;
using DarkCity.Simulation;
using DarkCity.Tiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkCity.Testing.Tiles
{
    public partial class PlayfieldSimulationTile : UserControl
    {
        private SimulationHost simulation = null;
        public SimulationHost Simulation
        {
            get { return this.simulation; }
            set
            {
                this.simulation = value;

                if (this.simulation != null)
                {
                    this.simulation.IApplication.OnPlayfieldLoaded += IApplication_OnPlayfieldLoaded;
                    this.simulation.IApplication.OnPlayfieldUnloading += IApplication_OnPlayfieldUnloading;
                }

                this.cboPlayfield.BeginUpdate();
                try
                {
                    this.cboPlayfield.Items.Clear();
                    if (this.simulation?.IApplication?.Playfields != null)
                        this.cboPlayfield.Items.AddRange(this.simulation.IApplication.Playfields.ToArray());
                } finally
                {
                    this.cboPlayfield.EndUpdate();
                }
            }
        }

        public PlayfieldSimulationTile()
        {
            InitializeComponent();
        }

        private void IApplication_OnPlayfieldLoaded(Eleon.Modding.IPlayfield playfield)
        {
            if (!this.cboPlayfield.Items.Contains(playfield))
                this.cboPlayfield.Items.Add(playfield);
        }

        private void IApplication_OnPlayfieldUnloading(Eleon.Modding.IPlayfield playfield)
        {
            if (this.cboPlayfield.Items.Contains(playfield))
                this.cboPlayfield.Items.Remove(playfield);
        }

        private void cboPlayfield_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPlayfield playfield = this.cboPlayfield.SelectedItem as IPlayfield;
            bool isSimulator = (playfield is PlayfieldSimulator);
            txtPlayfieldType.ReadOnly = !isSimulator;
            txtPlanetType.ReadOnly = !isSimulator;
            txtPlanetClass.ReadOnly = !isSimulator;
            nudSizeClass.ReadOnly = !isSimulator;
            nudTerrainSeed.ReadOnly = !isSimulator;
            btnGenerateTerrain.Enabled = !isSimulator;
            pbTerrain.Enabled = !isSimulator;

            txtPlayfieldType.Text = playfield?.PlayfieldType;
            txtPlanetType.Text = playfield?.PlanetType;
            txtPlanetClass.Text = playfield?.PlanetClass;
            
            if (isSimulator)
            {
                PlayfieldSimulator simulator = playfield as PlayfieldSimulator;
                nudSizeClass.Value = simulator?.SizeClass ?? 1;
                nudTerrainSeed.Value = simulator?.Terrain?.Seed ?? DateTime.Now.Ticks % 100000;
                if ((simulator?.Terrain != null) && (simulator?.Terrain?.Bitmap == null))
                    simulator.Terrain.Raster();
                pbTerrain.Image = simulator?.Terrain?.Bitmap;
            } else
            {
                nudSizeClass.Value = 1;
                pbTerrain.Image = null;
            }
        }
    }
}
