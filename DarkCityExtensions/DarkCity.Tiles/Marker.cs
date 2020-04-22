using DarkCity.Data;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace DarkCity.Tiles
{
    public class Marker
    {
        public EntityHeader Entity { get; set; } = null;
        public int Size { get; set; } = 32;

        public Marker() { }

        public Marker(EntityHeader entity)
        {
            this.Entity = entity;
        }

        public void Draw(Graphics g, Point offset, float scale)
        {
            if ((this.Entity == null) || (g == null)) return;
            
            Bitmap icon = IconLibrary.SelectEntityIcon(this.Entity);
            if (icon == null) return;

            ImageAttributes attributes = new ImageAttributes();
            attributes.TintByFaction(this.Entity.FactionGroup);
            icon = IconLibrary.AdjustBitmap(icon, this.Size, attributes);
            int dstX = (int)(offset.X + this.Entity.Position.x * scale - icon.Width / 2);
            int dstY = (int)(offset.Y + this.Entity.Position.z * scale - icon.Height / 2);

            g.DrawImage(icon, new Rectangle(dstX, dstY, icon.Width, icon.Height), 0, 0, icon.Width, icon.Height, GraphicsUnit.Pixel, attributes);
        }
    }
}
