using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib
{
    public class Triangles : Polygons
    {
        private static int index;
        public override string name { get; set; }
        public Triangles(PointF[] pointF, string name) : base(pointF, name)
        {
            this.pointFs = pointF;
            this.name = name;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, pointFs);
            Init.pictureBox.Image = Init.bitmap;
        }
        public override bool MoveTo(int x, int y)
        {
            if (!(this.pointFs[0].X + x > Init.pictureBox.Width ||
                this.pointFs[1].X + x > Init.pictureBox.Width ||
                this.pointFs[2].X + x > Init.pictureBox.Width ||
                this.pointFs[0].Y + y > Init.pictureBox.Height ||
                this.pointFs[1].Y + y > Init.pictureBox.Height ||
                this.pointFs[2].Y + y > Init.pictureBox.Height) &&
                !(this.pointFs[0].X + x < 0 ||
                this.pointFs[1].X + x < 0 ||
                this.pointFs[2].X + x < 0 ||
                this.pointFs[0].Y + y < 0 ||
                this.pointFs[1].Y + y < 0 ||
                this.pointFs[2].Y + y < 0))
            {
                this.pointFs[0].X += x; this.pointFs[0].Y += y;
                this.pointFs[1].X += x; this.pointFs[1].Y += y;
                this.pointFs[2].X += x; this.pointFs[2].Y += y;
                this.DeleteF(this, false);
                this.Draw();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
