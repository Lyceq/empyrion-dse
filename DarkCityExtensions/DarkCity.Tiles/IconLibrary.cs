using DarkCity.Data;
using DarkCity.Tiles.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace DarkCity.Tiles
{
    public static class IconLibrary
    {
        // Person: https://freesvg.org/vector-illustration-of-simple-man-or-person-silhouette-icon
        // POI: https://freesvg.org/vector-image-of-black-location-pin
        // Starship: https://freesvg.org/starship-vector-silhouette
        // Rocketship: https://commons.wikimedia.org/wiki/File:Spaceship_-_The_Noun_Project.svg
        // Mine: https://commons.wikimedia.org/wiki/File:Mining_symbol.svg
        // Moon: https://commons.wikimedia.org/wiki/File:Icona_asteroide.svg
        // Tank: https://freesvg.org/black-army-tank-vector-icon
        // Base: https://commons.wikimedia.org/wiki/File:Maki-castle-11.svg
        // Dino: https://www.needpix.com/photo/1563764/silhouette-dinosaur-dino-giant-lizard-replica-prehistoric-times-hagbard-predator-urtier
        // Backpack: https://commons.wikimedia.org/wiki/File:Backpack_(2551)_-_The_Noun_Project.svg
        // Motorcycle: https://freesvg.org/motorcycle-vector-icon
        // UFO: https://pngimg.com/download/71590

        public static Bitmap SelectEntityIcon(EntityHeader entity)
        {
            if (entity.EntityType == EntityTypeData.Animal) return Resource.dino;
            if (entity.EntityType == EntityTypeData.Asteroid) return Resource.moon;
            if (entity.EntityType == EntityTypeData.BA) {
                if (entity.FactionGroup == FactionGroupData.Player)
                    return Resource._base;
                else
                    return Resource.poi;
            }
            if (entity.EntityType == EntityTypeData.CV) return Resource.starship;
            if (entity.EntityType == EntityTypeData.EnemyDrone) return Resource.ufo;
            if (entity.EntityType == EntityTypeData.HV) return Resource.tank;
            if (entity.EntityType == EntityTypeData.Player) return Resource.person;
            if (entity.EntityType == EntityTypeData.PlayerBackpack) return Resource.backpack;
            if (entity.EntityType == EntityTypeData.PlayerBike) return Resource.motorcycle;
            if (entity.EntityType == EntityTypeData.PlayerBikeFolded) return Resource.motorcycle;
            if (entity.EntityType == EntityTypeData.Proxy) return Resource.poi;
            if (entity.EntityType == EntityTypeData.SV) return Resource.rocketship;
            if (entity.EntityType == EntityTypeData.UnderRes) return Resource.mine;
            return null;
        }

        public static Bitmap AdjustBitmap(Bitmap image, int size, ImageAttributes attributes = null)
        {
            Bitmap result = new Bitmap(size, size);
           
            float sizeRatio = (float)(size) / Math.Max(image.Width, image.Height);
            int dstWidth = (int)(image.Width * sizeRatio), dstHeight = (int)(image.Height * sizeRatio);
            int dstX = (size - dstWidth) / 2, dstY = (size - dstHeight) / 2;

            Graphics g = Graphics.FromImage(result);
            g.DrawImage(image, new Rectangle(dstX, dstY, dstWidth, dstHeight), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            return result;
        }

        public static ColorMatrix CreateColorTint(Color color, float depth)
        {
            return new ColorMatrix(new float[][] {
                new float[] {1, 0, 0, 0, 0 },
                new float[] {0, 1, 0, 0, 0 },
                new float[] {0, 0, 1, 0, 0 },
                new float[] {0, 0, 0, 1, 0 },
                new float[] {color.R / 255 * depth, color.G / 255 * depth, color.B / 255 * depth, 0, 1 }
            });
        }

        public static ImageAttributes TintByFaction(this ImageAttributes attributes, FactionGroupData group)
        {
            if (attributes == null) return null;

            switch (group)
            {
                case FactionGroupData.Alien: attributes.SetColorMatrix(CreateColorTint(Color.Purple, 0.75f)); break;
                case FactionGroupData.Faction: attributes.SetColorMatrix(CreateColorTint(Color.White, 0.75f)); break;
                case FactionGroupData.Player: attributes.SetColorMatrix(CreateColorTint(Color.Yellow, 0.75f)); break;
                case FactionGroupData.Polaris: attributes.SetColorMatrix(CreateColorTint(Color.Blue, 0.75f)); break;
                case FactionGroupData.Predator: attributes.SetColorMatrix(CreateColorTint(Color.MistyRose, 0.5f)); break;
                case FactionGroupData.Prey: attributes.SetColorMatrix(CreateColorTint(Color.LimeGreen, 0.5f)); break;
                case FactionGroupData.Talon: attributes.SetColorMatrix(CreateColorTint(Color.Green, 0.75f)); break;
                case FactionGroupData.Zirax: attributes.SetColorMatrix(CreateColorTint(Color.Red, 0.75f)); break;
            }

            return attributes;
        }
    }
}
