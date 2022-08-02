using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib
{
    public class Person : Figure
    {

        private static int index;
        public override string name { get; set; }

        public Circles c1;
        public Squares s1;
        public Rectangles r1;
        public Rectangles r2;
        public Triangles t1;
        public Triangles t2;
        public PointF[] pointF1;
        public PointF[] pointF2;

        public Person(int x, int y)
        {
            pointF1 = new PointF[3];
            pointF1[0].X = x + 60; pointF1[0].Y = y + 200;
            pointF1[1].X = x + 60; pointF1[1].Y = y + 280;
            pointF1[2].X = x + 140; pointF1[2].Y = y + 280;
            pointF2 = new PointF[3];
            pointF2[0].X = x + 40; pointF2[0].Y = y + 200;
            pointF2[1].X = x + 40; pointF2[1].Y = y + 280;
            pointF2[2].X = x - 40; pointF2[2].Y = y + 280;


            this.c1 = new Circles(x, y, 100);
            this.s1 = new Squares(x, y + 100, 100, "s1");
            this.r1 = new Rectangles(x + 120, y + 100, 80, 40, "r1");
            this.r2 = new Rectangles(x - 100, y + 100, 80, 40, "r2");
            this.t1 = new Triangles(pointF1, "t1");
            this.t2 = new Triangles(pointF2, "t1");
        }
        public override void Draw()
        {
            this.c1.Draw();
            this.c1.name = $"Persons Figure {c1.GetType().Name} №{index++}";
            ShapeContainer.AddFigure(c1);
            this.s1.Draw();
            this.s1.name = $"Persons Figure {s1.GetType().Name} №{index++}";
            ShapeContainer.AddFigure(s1);
            this.r1.Draw();
            this.r1.name = $"Persons Figure {r1.GetType().Name} №{index++}";
            ShapeContainer.AddFigure(r1);
            this.r2.Draw();
            this.r2.name = $"Persons Figure {r2.GetType().Name} №{index++}";
            ShapeContainer.AddFigure(r2);
            this.t1.Draw();
            this.t1.name = $"Persons Figure {t1.GetType().Name} №{index++}";
            ShapeContainer.AddFigure(t1);
            this.t2.Draw();
            this.t2.name = $"Persons Figure {t2.GetType().Name} №{index++}";
            ShapeContainer.AddFigure(t2);
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
