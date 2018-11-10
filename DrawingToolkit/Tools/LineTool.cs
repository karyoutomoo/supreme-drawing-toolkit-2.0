using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Tools
{
    public class Line : DrawingObject
    {
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

    }

}
