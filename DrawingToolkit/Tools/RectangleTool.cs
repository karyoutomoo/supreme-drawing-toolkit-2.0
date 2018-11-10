using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Tools
{
    public class Rectangle : DrawingObject
    {
        public Pen pen = new Pen(Color.Black, 5);
        public int mX { get; set; }
        public int mY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int mX, int mY, int width, int height)
        {
            this.mX = mX;
            this.mY = mY;
            this.Width = width;
            this.Height = height;
        }
        
        public override void DrawObject(Graphics g)
        {
            Debug.WriteLine("Drawing A Rectangle");
            g.DrawRectangle(pen,mX,mY,Width,Height);
        }
    }
}
