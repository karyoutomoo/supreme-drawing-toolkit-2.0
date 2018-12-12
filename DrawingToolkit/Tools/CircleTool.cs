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
    class Ellipse : DrawingObject
    {
        private const double EPSILON = 3.0;
        public Pen pen = new Pen(Color.Black, 2);
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        System.Drawing.Rectangle areaRect;

        public Ellipse(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }
        public override void DrawObject(Graphics g)
        {
            Debug.WriteLine("Drawing A Circle");
            areaRect = new System.Drawing.Rectangle(point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
            g.DrawEllipse(pen, areaRect);
        }

        public override bool Intersect(int xTest, int yTest)
        {
            Width = point2.X - point1.X;
            Height = point2.Y - point1.Y;
            if ((xTest >= point1.X && xTest <= point1.X + Width) && (yTest >= point1.Y && yTest <= point1.Y + Height))
            {
                Debug.WriteLine("Object " + "ellipse" + " is selected.");
                return true;
            }
            return false;
        }

        public override void RenderOnPreview(Graphics g, int color)
        {
            if (color == 1)
            {
                this.pen.Color = Color.Black;
                g.DrawEllipse(this.pen, point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
            }
            else if (color == 2)
            {
                this.pen.Color = Color.Red;
                DrawHandle(g);
                g.DrawEllipse(this.pen, point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
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
            for (int i = 1; i < 9; i++)
            {
                Point point = GetHandlePoint(i);
                point.Offset(-2, -2);
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(point.X, point.Y, 5, 5);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawRectangle(pen, rect);
            }
            System.Diagnostics.Debug.WriteLine("DrawHandle");
        }

        public override Point GetHandlePoint(int value)
        {
            //System.Diagnostics.Debug.WriteLine(from);
            Point result = Point.Empty;
            if (value == 1)//pojok kiri
                result = new Point(point1.X, point1.Y);
            else if (value == 2)//tengah kiri
                result = new Point(point1.X, point1.Y + (Height / 2));
            else if (value == 3)//bawah kiri
                result = new Point(point1.X, point2.Y);
            else if (value == 4)
                result = new Point(point1.X + (Width / 2), point1.Y);
            else if (value == 5)
                result = new Point(point1.X + (Width / 2), point2.Y);
            else if (value == 6)
                result = new Point(point2.X, point1.Y);
            else if (value == 7)
                result = new Point(point2.X, point1.Y + (Height / 2));
            else if (value == 8)
                result = new Point(point2.X, point2.Y);
            System.Diagnostics.Debug.WriteLine("GetHandlePoint");
            return result;
        }

        public override int GetClickHandle(Point posisi)
        {
            for (int i = 1; i < 9; i++)
            {
                Point point = GetHandlePoint(i);
                point.Offset(-2, -2);
                if ((posisi.X >= point.X && posisi.X <= point.X + 5) && (posisi.Y >= point.Y && posisi.Y <= point.Y + 5))
                {
                    // System.Diagnostics.Debug.WriteLine("Berubah"+i);
                    return i;
                }
            }
            System.Diagnostics.Debug.WriteLine("GetClickHandle");
            return -1;
        }

        public override void Translate(int difX, int difY)
        {
            this.point1 = new Point(this.point1.X + difX, this.point1.Y + difY);
            this.point2 = new Point(this.point2.X + difX, this.point2.Y + difY);

            System.Diagnostics.Debug.WriteLine("Translate");
        }

        public override void Resize(int posisiClick, Point posisi)
        {
            //System.Diagnostics.Debug.WriteLine(from);
            if (posisiClick == 1)//pojok kiri
            {
                this.point1 = posisi;
                System.Diagnostics.Debug.WriteLine("POJOK KIRI");
            }
            else if (posisiClick == 2)//tengah kiri
            {
                this.point1 = new Point(posisi.X, point1.Y);
            }
            else if (posisiClick == 3)//bawah kiri
            {
                this.point1 = new Point(posisi.X, point1.Y);
                this.point2 = new Point(point2.X, posisi.Y);
            }
            else if (posisiClick == 4)
            {
                this.point1 = new Point(point1.X, posisi.Y);
            }
            else if (posisiClick == 5)
            {
                this.point2 = new Point(point2.X, posisi.Y);
            }
            else if (posisiClick == 6)
            {
                this.point1 = new Point(point1.X, posisi.Y);
                this.point2 = new Point(posisi.X, point2.Y);
            }
            else if (posisiClick == 7)
            {
                this.point2 = new Point(posisi.X, point2.Y);
            }
            else if (posisiClick == 8)
            {
                this.point2 = posisi;
            }
            this.Width = Math.Abs(point1.X - point2.X);
            this.Height = Math.Abs(point1.Y - point2.Y);
            System.Diagnostics.Debug.WriteLine("RESIZE");
        }
    }
}