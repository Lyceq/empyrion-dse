using DarkCity.Data;
using LibNoise;
using LibNoise.Demo.Ext.Dotnet;
using LibNoise.Builder;
using LibNoise.Renderer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCity.Tiles
{
    public class PlayfieldMapRender
    {
        public PlayfieldMap Map { get; set; } = null;

        public PlayfieldData Data { get; set; } = null;

        public ImageRenderer Renderer { get; set; } = new ImageRenderer();

        public Bitmap Image { get; private set; } = null;

        public PlayfieldMapRender()
        {
            GradientColor gradient = new GradientColor();
            gradient.AddGradientPoint(0, new LibNoise.Renderer.Color(0, 0, 0xc0));
            gradient.AddGradientPoint(20, new LibNoise.Renderer.Color(0, 0, 0xff));
            gradient.AddGradientPoint(21, new LibNoise.Renderer.Color(0xa0, 0xa0, 0));
            gradient.AddGradientPoint(30, new LibNoise.Renderer.Color(0xc0, 0xc0, 0));
            gradient.AddGradientPoint(40, new LibNoise.Renderer.Color(0, 0x80, 0));
            gradient.AddGradientPoint(100, new LibNoise.Renderer.Color(0x40, 0xa0, 0x40));
            gradient.AddGradientPoint(150, new LibNoise.Renderer.Color(0x60, 0x60, 0));
            gradient.AddGradientPoint(200, new LibNoise.Renderer.Color(0x80, 0x80, 0x80));
            gradient.AddGradientPoint(300, new LibNoise.Renderer.Color(0xa0, 0xa0, 0xa0));
            gradient.AddGradientPoint(320, new LibNoise.Renderer.Color(0xc0, 0xc0, 0xc0));
            gradient.AddGradientPoint(500, new LibNoise.Renderer.Color(0xff, 0xff, 0xff));
            gradient.AddGradientPoint(510, new LibNoise.Renderer.Color(0x80, 0x80, 0x80));
            gradient.AddGradientPoint(1000, new LibNoise.Renderer.Color(0xa0, 0xa0, 0xa0));

            this.Renderer.Gradient = gradient;

            this.Renderer.LightEnabled = false;
            //this.Renderer.LightBrightness = 2;
            //this.Renderer.LightContrast = 3;
            //this.Renderer.WrapEnabled = true;
        }

        public PlayfieldMapRender(PlayfieldMap map) : this()
        {
            this.Map = map;
        }

        public PlayfieldMapRender(PlayfieldMap map, PlayfieldData data) : this(map)
        {
            this.Data = data;
        }

        public PlayfieldMapRender(PlayfieldMap map, PlayfieldData data, ImageRenderer renderer)
        {
            this.Map = map;
            this.Data = data;
            this.Renderer = renderer;
        }

        public Bitmap Render()
        {
            NoiseMap noise = new NoiseMap(this.Map.MapWidth, this.Map.MapHeight);

            // Copy map data to noise map.
            for (int z = 0; z < noise.Height; z++)
                for (int x = 0; x < noise.Width; x++)
                    noise.SetValue(x, z, this.Map.HeightMap[x, z] * this.Map.Resolution);

            this.Renderer.NoiseMap = noise;

            BitmapAdaptater adapter = new BitmapAdaptater(noise.Width, noise.Height);
            this.Renderer.Image = adapter;
            this.Renderer.Render();
            this.Image = adapter.Bitmap;
            return this.Image;
        }

    }
}
