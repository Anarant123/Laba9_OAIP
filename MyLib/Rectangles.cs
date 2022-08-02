using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib
{
    public class Rectangles : Figure
    {
        private static int index;
        public override string name { get; set; }
        public Rectangles(int x, int y, int w, int h, string name)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.name = name;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, this.x, this.y, this.w, this.h);
            Init.pictureBox.Image = Init.bitmap;
        }
        public override void Draw(float angle)
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.TranslateTransform(0, 0);
            g.RotateTransform(angle);
            g.DrawRectangle(Init.pen, this.x, this.y, this.w, this.h);
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
