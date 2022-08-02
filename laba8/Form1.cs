using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyLib;
using laba8.laba9;

namespace laba8
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Pen pen;
        ShapeContainer cont = new ShapeContainer();

        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<Operand> operands = new Stack<Operand>();
        Dictionary<string, PointF[]> points = new Dictionary<string, PointF[]>();

        public Form1()
        {
            InitializeComponent();

            this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            this.pen = new Pen(Color.Black, 5);
            Init.bitmap = this.bitmap;
            Init.pictureBox = pictureBox1;
            Init.pen = this.pen;
        }

        private void tbInputString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    foreach (var inputChar in tbInputString.Text)
                    {
                        if (IsNotOperation(inputChar))
                        {
                            if (!char.IsDigit(inputChar))
                            {
                                operands.Push(new Operand(operands.Pop().value.ToString() + inputChar));
                            }
                            else
                            {
                                operands.Push(new Operand(operands.Pop().value.ToString() + inputChar));
                            }
                        }
                        else if (operands.Count == 0 || operands.Peek().value.ToString() != "")
                        {
                            operands.Push(new Operand(""));
                        }

                        switch (inputChar)
                        {
                            case '(':
                                {
                                    operators.Push(OperatorContainer.FindOperator(inputChar));
                                    break;
                                }
                                
                            case ')':
                                {
                                    do
                                    {
                                        if (operators.Peek().symbolOperator == '(')
                                        {
                                            operators.Pop();
                                            break;
                                        }

                                        if (operators.Count == 0)
                                        {
                                            break;
                                        }
                                    } while (operators.Peek().symbolOperator != ')');

                                    if (operators.Peek() != null)
                                    {
                                        operands.Pop();
                                        SelectingPerformingOperation(operators.Peek());

                                        operands = new Stack<Operand>();
                                        operators = new Stack<Operator>();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Введенной операции не существует");
                                        cbHistory.Items.Add("Попытака ввода несуществубщей команды: '" + tbInputString.Text + "'");
                                    }

                                    break;
                                }
                            default:
                                {
                                    if (inputChar == 'A' || inputChar == 'T' || inputChar == 'M' || inputChar == 'D')
                                    {
                                        if (operators.Count == 0)
                                        {
                                            operators.Push(OperatorContainer.FindOperator(inputChar));
                                        }

                                        break;
                                    }
                                    break;
                                }
                        }
                    }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    cbHistory.Items.Add("Попытака ввода команды: '" + tbInputString.Text + "'");
                }
        }
        }

        private bool IsNotOperation(char item)
        {
            if (!(item == 'A' || item == 'T' || item == 'M' || item == 'D' || item == ',' || item == '(' || item == ')'))
                return true;
            else
                return false;
        }
        private void SelectingPerformingOperation(Operator op)
        {
            switch (op.symbolOperator)
            {
                case 'A':
                    {
                        //A(nameA, x1, y1, x2, y2, x3, y3)
                        int y2 = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                        int x2 = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                        int y1 = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                        int x1 = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                        int y0 = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                        int x0 = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                        string name = Convert.ToString(operands.Pop().value);

                        PointF[] pointF = new PointF[3];
                        pointF[0].X = x0; pointF[0].Y = y0;
                        pointF[1].X = x1; pointF[1].Y = y1;
                        pointF[2].X = x2; pointF[2].Y = y2;

                        cbHistory.Items.Add("Создан массив точек: " + name);
                        points.Add(name,pointF);
                        break;
                    }
                case 'T':
                    {
                        //T(name, nameA)
                        string nameA = Convert.ToString(operands.Pop().value);
                        string nameT = Convert.ToString(operands.Pop().value);

                        PointF[] pointF = new PointF[3];
                        foreach (var point in points)
                        {
                            if(point.Key == nameA)
                                pointF = point.Value;
                        }

                        Triangles b = new Triangles(pointF, nameT);
                        op = new Operator(b.Draw, 'T');
                        op.operatorMethod();
                        ShapeContainer.AddFigure(b);
                        cbHistory.Items.Add("Отрисован треугольник: " + b.name);
                        break;
                    }
                case 'M':
                    {
                        //M(name, dx, dy)
                        int dy = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                        int dx = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                        string name = Convert.ToString(operands.Pop().value);

                        for (int i = 0; i < ShapeContainer.figureList.Count; i++)
                        {
                            if (ShapeContainer.figureList[i].name == name)
                            {
                                if(ShapeContainer.figureList[i].MoveTo(dx, dy) == true)
                                {
                                    cbHistory.Items.Add("Перемещен треугольник: " + ShapeContainer.figureList[i].name);
                                }
                                else
                                {
                                    cbHistory.Items.Add("Неудалось переместить фигуру: " + ShapeContainer.figureList[i].name);
                                }
                            }
                        }

                        break;
                    }
                case 'D':
                    {
                        //D(name)
                        string nameF = Convert.ToString(operands.Pop().value);

                        var forDelete = ShapeContainer.figureList.Find(f => f.name == nameF);
                        ShapeContainer.figureList.Remove(forDelete);
                        cbHistory.Items.Add("Удалена фигура: " + nameF);
                        Graphics g = Graphics.FromImage(Init.bitmap);
                        g.Clear(Color.White);
                        pictureBox1.Invalidate();

                        for (int i = 0; i < ShapeContainer.figureList.Count; i++)
                        {
                            ShapeContainer.figureList[i].Draw();
                        }

                        break;
                    }
            }
        }
    }
}