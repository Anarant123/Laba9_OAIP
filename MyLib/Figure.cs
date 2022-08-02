using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib
{
    abstract public class Figure
    {
        public virtual string name { get; set; }

        public int x;
        public int y;
        public int w;
        public int h;

        public virtual void Draw()
        { 
        
        }
        public virtual void Draw(PointF[] pointFs)
        { 
        
        }
        public virtual void Draw(float angle)
        {

        }
        public virtual bool MoveTo(int x, int y)
        {
            int width = 0;
            int height = 0;
            if (this is Rectangles || this is Ellipses)
            {
                width = this.w;
                height = this.h;
            }
            if(this is Squares || this is Circles)
            {
                width = this.w;
                height = this.w;
            }
            if(this is Person)
            {
                width = 300;
                height = 280;
            }

            if (!((this.x + x < 0 && this.y + y < 0)
                || (this.y + y < 0)
                || (this.x + x > Init.pictureBox.Width && this.y + y < 0)
                || (this.x + width + x > Init.pictureBox.Width)
                || (this.x + x > Init.pictureBox.Width && this.y + y > Init.pictureBox.Height)
                || (this.y + height + y > Init.pictureBox.Height)
                || (this.x + x < 0 && this.y + y > Init.pictureBox.Height)
                || (this.x + x < 0)))
            {
                this.x += x;
                this.y += y;
                this.DeleteF(this, false);
                this.Draw();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }

        public void DeleteF(Figure figure, bool flag = true)
        {
            if (flag == true)
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figureList.Remove(figure);
                this.Clear();
                Init.pictureBox.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figureList)
                {
                    f.Draw();
                }
            }
            else
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figureList.Remove(figure); 
                this.Clear();
                Init.pictureBox.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figureList)
                {
                    f.Draw();
                }
                ShapeContainer.figureList.Add(figure);
            }
        }
    }
}
