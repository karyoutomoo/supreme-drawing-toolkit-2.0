using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class DrawingCanvas : Form
    {
        public bool draw = false;
        public bool drag = false;

        public int currentDrawingTool=1;

        private int loop=0;
    
        public Point currentPoint = new Point();
        public Point oldPoint = new Point();

        public Point point1 = new Point();
        public Point point2 = new Point();
        public Point point3 = new Point();
        public Point point4 = new Point();

        public Pen pen = new Pen(Color.Black, 5);
        public Graphics graphics;
     
        public DrawingCanvas()
        {
            InitializeComponent();
            graphics = panel1.CreateGraphics();
        }
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DrawingCanvas_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LineTool_Click(object sender, EventArgs e)
        {
            currentDrawingTool = 1;
        }

        private void CircleTool_Click(object sender, EventArgs e)
        {
            currentDrawingTool = 2;
        }

        private void RectangleTool_Click(object sender, EventArgs e)
        {
            currentDrawingTool = 3;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            oldPoint = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                draw = true;
                loop++;
            }

           drag = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }


        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (draw == true)
            {
                if (currentDrawingTool == 1)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        currentPoint = e.Location;
                    }
                    if (e.Button == MouseButtons.Left)
                    {
                        graphics.DrawLine(pen, currentPoint, oldPoint);
                        oldPoint = currentPoint;
                    }
                }
                else if (currentDrawingTool == 3)
                {
                    //rectangle
                    point1 = oldPoint;
                    if (e.Button == MouseButtons.Left)
                    {
                        point2 = e.Location;
                    }

                    point3 = new Point(point1.X, point2.Y);
                    point4 = new Point(point2.X, point1.Y);

                    int width = Math.Abs(point2.X - point3.X);
                    int height = Math.Abs(point4.Y - point2.Y);

                    Debug.WriteLine("Point 1 :" + point1);
                    Debug.WriteLine("Point 2 :" + point2);
                    Debug.WriteLine("Point 3 :" + point3);
                    Debug.WriteLine("Point 4 :" + point4);

                    Debug.WriteLine("width :" + width);
                    Debug.WriteLine("height :" + height);

                    Rectangle rectangle = new Rectangle(point1.X, point1.Y, width, height);

                    graphics.DrawRectangle(pen, rectangle);
                }
                else if (currentDrawingTool == 2)
                {
                    //circle
                    point1 = oldPoint;
                    if (e.Button == MouseButtons.Left)
                    {
                        point2 = e.Location;
                    }
                    point4 = new Point(point2.X, point1.Y);
                    point3 = new Point(point1.X, point2.Y);

                    int width = point2.X - point3.X;
                    int height = point4.Y - point2.Y;

                    Debug.WriteLine("Point 1 :" + point1);
                    Debug.WriteLine("Point 2 :" + point2);
                    Debug.WriteLine("Point 3 :" + point3);
                    Debug.WriteLine("Point 4 :" + point4);

                    Debug.WriteLine("width :" + width);
                    Debug.WriteLine("height :" + height);

                    Rectangle rect = new Rectangle(point1.X, point1.Y, width, height);
                    graphics.DrawEllipse(pen, rect);
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            point2 = e.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
