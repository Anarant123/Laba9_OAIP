using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib
{
    public class Polygons : Figure
    {
        public int POindex;
        public override string name { get; set; }
        public PointF[] pointFs;

        public Polygons(PointF[] pointF, string name)
        {
            this.name = name;
            this.pointFs = pointF;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, pointFs);
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
