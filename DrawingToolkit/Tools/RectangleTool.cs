using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class Rectangle : DrawingObject
    {
        private const double EPSILON = 3.0;
        public Pen pen = new Pen(Color.Black, 5);
        public int mX { get; set; }
        public int mY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        bool dragging = false;
        System.Drawing.Rectangle areaRect;

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
            areaRect = new System.Drawing.Rectangle(mX, mY, Width, Height);
            g.DrawRectangle(pen, areaRect);
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= mX && xTest <= mX + Width) && (yTest >= mY && yTest <= mY + Height))
            {
                Debug.WriteLine("Object " + "rectangle" + " is selected.");
                return true;
            }
            return false;
        }
        

        public override void RenderOnPreview(Graphics g, int color)
        {
            if(color == 1)
            {
                this.pen.Color = Color.Black;
            }
            else if(color == 2)
            {
                this.pen.Color = Color.Red;
            }
            g.DrawRectangle(this.pen, mX, mY, Width, Height);
        }
    }
}
