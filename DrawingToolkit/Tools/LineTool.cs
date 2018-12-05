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
        public Point currentPoint { get; set; }
        public Point oldPoint { get; set; }

        public Line(Point currentPoint, Point oldPoint)
        {
            this.currentPoint = currentPoint;
            this.oldPoint = oldPoint;
        }

        public override void DrawObject(Graphics g)
        {
            g.DrawLine(new Pen(Color.Black, 5), currentPoint, oldPoint);
            Debug.WriteLine("Drawing A Line");
        }

        public override bool Intersect(int xTest, int yTest)
        {
            double m = GetSlope();
            double b = currentPoint.Y - m * currentPoint.X;
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
            double m = (double)(currentPoint.Y - oldPoint.Y) / (double)(currentPoint.X - oldPoint.X);
            return m;
        }

        public override void RenderOnPreview(Graphics graphics, int color)
        {
            /*pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            if (this.GetGraphics() != null)
            {
                this.GetGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                this.GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);

            }*/
        }
    }

}