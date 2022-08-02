using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib
{
    public class Circles : Ellipses
    {
        private static int index;
        public override string name { get; set; }
        public Circles(int x, int y, int w) : base(x, y, w, w)
        {

        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawEllipse(Init.pen, this.x, this.y, this.w, this.w);
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
