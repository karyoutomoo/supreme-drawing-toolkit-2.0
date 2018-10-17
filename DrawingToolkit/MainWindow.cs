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
        private IToolbox toolbox;
        private ICanvas canvas;

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
        public Graphics[] ArrayOfGraphics;

        Rectangle rec = new Rectangle(0, 0, 0, 0);

        public DrawingCanvas()
        {
            InitializeComponent();
            InitForm();
            graphics = panel1.CreateGraphics();
            this.DoubleBuffered = true;
        }
        
        private void InitForm()
        {
            //ToolInit
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

                else if (currentDrawingTool == 2)
                {
                    //circle
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

                    int[] minX = new[] { point1.X, point2.X, point3.X, point4.X };
                    int[] minY = new[] { point1.Y, point2.Y, point3.Y, point4.Y };

                    int mX = minX.Min();
                    int mY = minY.Min();

                    Rectangle rectangle = new Rectangle(mX, mY, width, height);
                    graphics.DrawEllipse(pen, rectangle);
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

                    int[] minX = new[] { point1.X, point2.X, point3.X, point4.X };
                    int[] minY = new[] { point1.Y, point2.Y, point3.Y, point4.Y };

                    int mX = minX.Min();
                    int mY = minY.Min();

                    Rectangle rectangle = new Rectangle(mX, mY, width, height);

                    graphics.DrawRectangle(pen, rectangle);
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rectangle rec = new Rectangle(e.X, e.Y, 0, 0);
                Invalidate();
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                rec.Width = e.X - rec.X;
                rec.Height = e.Y - rec.Y;
                Invalidate();
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
