using LibNoise;
using LibNoise.Builder;
using LibNoise.Demo.Ext.Dotnet;
using LibNoise.Filter;
using LibNoise.Modifier;
using LibNoise.Primitive;
using LibNoise.Renderer;
using System.Drawing;

namespace DarkCity.Simulation
{
    public enum NoiseMapProjection
    {
        Spherical,
        Cylindrical,
        Planar
    }

    public class TerrainGenerator
    {
        public int Seed { get; set; } = PrimitiveModule.DefaultSeed;
        public float Frequency { get; set; } = FilterModule.DEFAULT_FREQUENCY;
        public float Lacunarity { get; set; } = FilterModule.DEFAULT_LACUNARITY;
        public float Gain { get; set; } = FilterModule.DEFAULT_GAIN;
        public float Offset { get; set; } = FilterModule.DEFAULT_OFFSET;
        public float SpectralExponent { get; set; } = FilterModule.DEFAULT_SPECTRAL_EXPONENT;
        public float OctaveCount { get; set; } = FilterModule.DEFAULT_OCTAVE_COUNT;
        public bool Seamless { get; set; } = true;
        public GradientColor GradientColor { get; set; } = GradientColors.Grayscale;
        public NoiseQuality NoiseQuality { get; set; } = PrimitiveModule.DefaultQuality;
        public NoisePrimitive Primitive { get; set; } = NoisePrimitive.SimplexPerlin;
        public NoiseFilter Filter { get; set; } = NoiseFilter.SumFractal;
        public NoiseMapProjection Projection { get; set; } = NoiseMapProjection.Cylindrical;
        public int Width { get; set; } = 2048;
        public int Height { get; set; } = 2048;
        public NoiseMap Map { get; private set; }
        public Bitmap Bitmap { get; private set; }

        public TerrainGenerator() { }

        public NoiseMap Render()
        {
            PrimitiveModule primitive = null;

            switch (this.Primitive)
            {
                case NoisePrimitive.Constant:
                    primitive = new Constant(this.Offset);
                    break;

                case NoisePrimitive.Cylinders:
                    primitive = new Cylinders(this.Offset);
                    this.Seamless = false;
                    break;

                case NoisePrimitive.Spheres:
                    primitive = new Spheres(this.Offset);
                    this.Seamless = false;
                    break;

                case NoisePrimitive.BevinsGradient: primitive = new BevinsGradient(); break;
                case NoisePrimitive.BevinsValue: primitive = new BevinsValue(); break;
                case NoisePrimitive.ImprovedPerlin: primitive = new ImprovedPerlin(); break;
                case NoisePrimitive.SimplexPerlin: primitive = new SimplexPerlin(); break;
            }

            primitive.Seed = this.Seed;
            primitive.Quality = this.NoiseQuality;

            FilterModule filter = null;
            ScaleBias scale = null;

            switch (this.Filter)
            {
                case NoiseFilter.Pipe: filter = new Pipe(); break;
                case NoiseFilter.SumFractal: filter = new SumFractal(); break;
                case NoiseFilter.SinFractal: filter = new SinFractal(); break;
                case NoiseFilter.MultiFractal:
                    filter = new MultiFractal();
                    // Used to show the difference with our gradient color (-1 + 1)
                    scale = new ScaleBias(filter, 1f, -0.8f);
                    break;

                case NoiseFilter.Billow:
                    filter = new Billow();
                    ((Billow)filter).Bias = -0.2f;
                    ((Billow)filter).Scale = 2f;
                    break;

                case NoiseFilter.HeterogeneousMultiFractal:
                    filter = new HeterogeneousMultiFractal();
                    // Used to show the difference with our gradient color (-1 + 1)
                    scale = new ScaleBias(filter, -1f, 2f);
                    break;

                case NoiseFilter.HybridMultiFractal:
                    filter = new HybridMultiFractal();
                    // Used to show the difference with our gradient color (-1 + 1)
                    scale = new ScaleBias(filter, 0.7f, -2f);
                    break;

                case NoiseFilter.RidgedMultiFractal:
                    filter = new RidgedMultiFractal();
                    // Used to show the difference with our gradient color (-1 + 1)
                    scale = new ScaleBias(filter, 0.9f, -1.25f);
                    break;

                case NoiseFilter.Voronoi: filter = new Voronoi(); break;
            }

            filter.Frequency = this.Frequency;
            filter.Lacunarity = this.Lacunarity;
            filter.OctaveCount = this.OctaveCount;
            filter.Offset = this.Offset;
            filter.Gain = this.Gain;
            filter.Primitive3D = (IModule3D)primitive;

            IModule3D final = scale ?? (IModule3D)filter;

            NoiseMapBuilder projection;

            switch (this.Projection)
            {
                case NoiseMapProjection.Spherical:
                    projection = new NoiseMapBuilderSphere();
                    ((NoiseMapBuilderSphere)projection).SetBounds(-90f, 90f, -180f, 180f); // degrees
                    break;

                case NoiseMapProjection.Cylindrical:
                    projection = new NoiseMapBuilderCylinder();
                    ((NoiseMapBuilderCylinder)projection).SetBounds(-180f, 180f, -10f, 10f);
                    break;

                case NoiseMapProjection.Planar:
                default:
                    float bound = 2f;
                    projection = new NoiseMapBuilderPlane(bound, bound * 2, bound, bound * 2, this.Seamless);
                    break;
            }

            NoiseMap noise = new NoiseMap();
            projection.SetSize(this.Width, this.Height);
            projection.SourceModule = final;
            projection.NoiseMap = noise;
            projection.Build();

            float min, max;
            noise.MinMax(out min, out max);

            this.Map = noise;
            return noise;
        }

        public Bitmap Raster()
        {
            if (this.Map == null) this.Render();

            BitmapAdaptater bitmap = new BitmapAdaptater(this.Map.Width, this.Map.Height);
            ImageRenderer raster = new ImageRenderer();
            raster.NoiseMap = this.Map;
            raster.Gradient = this.GradientColor;
            raster.LightBrightness = 2;
            raster.LightContrast = 8;
            raster.Image = bitmap;

            raster.Render();

            this.Bitmap = bitmap.Bitmap;
            return this.Bitmap;
        }
    }
}
