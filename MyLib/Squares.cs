using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib
{
    public class Squares : Rectangles
    {
        private static int index;
        public override string name { get; set; }
        public Squares(int x, int y, int w, string name) : base(x, y, w, w, name)
        {

        }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, this.x, this.y, this.w, this.w);
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
