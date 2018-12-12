using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class Line : DrawingObject
    {
        private const double EPSILON = 3.0;
        public Point point2 { get; set; }
        public Point point1 { get; set; }
        private Pen pen = new Pen(Color.Black, 3);

        public Line(Point point2, Point point1)
        {
            this.point2 = point2;
            this.point1 = point1;
        }

        public override void DrawObject(Graphics g)
        {
            g.DrawLine(pen, point2, point1);
            Debug.WriteLine("Drawing A Line");
        }

        public override bool Intersect(int xTest, int yTest)
        {
            double m = GetSlope();
            double b = point2.Y - m * point2.X;
            double y_point = m * xTest + b;

            if (Math.Abs(yTest - y_point) < EPSILON)
            {
                Debug.WriteLine("Object " + "line" + " is selected.");
                return true;
            }
            return false;
        }

        public double GetSlope()
        {
            double m = (double)(point2.Y - point1.Y) / (double)(point2.X - point1.X);
            return m;
        }

        public override void RenderOnPreview(Graphics g, int color)
        {
            if (color == 1)
            {
                this.pen.Color = Color.Black;
                g.DrawLine(this.pen, point1, point2);
            }
            else if (color == 2)
            {
                this.pen.Color = Color.Red;
                g.DrawLine(this.pen, point1, point2);
                DrawHandle(g);
            }
        }

        public override void DrawEdit()
        {
            throw new NotImplementedException();
        }

        public override void DrawStatic()
        {
            throw new NotImplementedException();
        }

        public override void DrawHandle(Graphics g)
        {
            for (int i = 1; i < 3; i++)
            {
                Point point = GetHandlePoint(i);
                point.Offset(-2, -2);
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(point.X, point.Y, 5, 5);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawRectangle(pen, rect);
            }
        }

        public override Point GetHandlePoint(int value)
        {
            Point result = Point.Empty;
            if (value == 1)//pojok kiri
                result = new Point(point1.X, point1.Y);
            else if (value == 2)//bawah kiri
                result = new Point(point2.X, point2.Y);
            return result;
        }

        public override int GetClickHandle(Point posisi)
        {
            for (int i = 1; i < 3; i++)
            {
                Point point = GetHandlePoint(i);
                point.Offset(-2, -2);
                if ((posisi.X >= point.X && posisi.X <= point.X + 5) && (posisi.Y >= point.Y && posisi.Y <= point.Y + 5))
                {
                    System.Diagnostics.Debug.WriteLine("Berubah" + i);
                    return i;
                }
            }
            return -1;
        }

        public override void Translate(int difX, int difY)
        {
            this.point1 = new Point(this.point1.X + difX, this.point1.Y + difY);
            this.point2 = new Point(this.point2.X + difX, this.point2.Y + difY);
        }

        public override void Resize(int posisiClick, Point posisi)
        {
            if (posisiClick == 1)//pojok kiri
            {
                this.point1 = posisi;
            }
            else if (posisiClick == 2)//bawah kiri
            {
                this.point2 = posisi;
            }
        }
    }

}