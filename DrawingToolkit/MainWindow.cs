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
using DrawingToolkit.Tools;

namespace DrawingToolkit
{
    public partial class DrawingCanvas : Form
    {
        private IToolbox toolbox;
        private ICanvas canvas;

        public bool draw = false;
        public bool select = false;
        public bool undo = false;

        public int currentDrawingTool = 1;
        DrawingObject selectedObject, deselectedObject;

        private int loop = 0;
        public int toRedo = 0;
        public Point currentPoint = new Point();
        public Point oldPoint = new Point();

        public Point point1 = new Point();
        public Point point2 = new Point();
        public Point point3 = new Point();
        public Point point4 = new Point();

        public Pen pen = new Pen(Color.Black, 5);
        public Graphics graphics;

        List<DrawingObject> _objects = new List<DrawingObject>();
        List<DrawingObject> _fullobjects = new List<DrawingObject>();

        Tools.Rectangle rec = new Tools.Rectangle(0, 0, 0, 0);

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
            select = false;
        }

        private void LineTool_Click(object sender, EventArgs e)
        {
            draw = true;
            currentDrawingTool = 1;
            select = false;
        }

        private void CircleTool_Click(object sender, EventArgs e)
        {
            draw = true;
            currentDrawingTool = 2;
            select = false;
        }

        private void RectangleTool_Click(object sender, EventArgs e)
        {
            draw = true;
            currentDrawingTool = 3;
            select = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            oldPoint = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                draw = true;
                loop++;
            }

            if (select == true)
            {
                foreach (DrawingObject obj in _objects)
                {
                    if (obj.Intersect(e.X, e.Y))
                    {
                        selectedObject = obj;
                        obj.RenderOnPreview(graphics, 2);
                    }
                    else
                    {
                        deselectedObject = obj;
                        obj.RenderOnPreview(graphics, 1);
                    }
                }
            }
            panel1.Invalidate();
            Refresh();
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
                        Line line = new Line(currentPoint, oldPoint);
                        _objects.Add(line);
                        _fullobjects.Add(line);
                        oldPoint = currentPoint;
                        Debug.WriteLine("jml object :" + _objects.Count);
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

                    int[] minX = new[] { point1.X, point2.X, point3.X, point4.X };
                    int[] minY = new[] { point1.Y, point2.Y, point3.Y, point4.Y };

                    int mX = minX.Min();
                    int mY = minY.Min();

                    Tools.Rectangle rectangle = new Tools.Rectangle(mX, mY, width, height);
                    _objects.Add(rectangle);
                    _fullobjects.Add(rectangle);
                    graphics.DrawRectangle(pen, mX, mY, width, height);
                    Debug.WriteLine("jml object :" + _objects.Count);
                }


                else if (currentDrawingTool == 2)
                {
                    //circle
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

                    Tools.Ellipse ellipse = new Tools.Ellipse(mX, mY, width, height);
                    _objects.Add(ellipse);
                    _fullobjects.Add(ellipse);
                    graphics.DrawEllipse(pen, mX, mY, width, height);
                    Debug.WriteLine("jml object :" + _objects.Count);
                }
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Tools.Rectangle rec = new Tools.Rectangle(e.X, e.Y, 0, 0);
                Invalidate();
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                rec.Width = e.X - rec.mX;
                rec.Height = e.Y - rec.mY;
                Invalidate();
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            point2 = e.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _objects.Clear();
            _fullobjects.Clear();
            panel1.Invalidate();
            Debug.WriteLine("jml object setelah CLEAR :" + _objects.Count);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var o in _objects)
            {
                o.DrawObject(e.Graphics);
                Debug.WriteLine("redrawing");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int lastObjectPosition = _objects.Count - 1;
            if (lastObjectPosition > -1)
            {
                _objects.RemoveAt(lastObjectPosition);
                toRedo = lastObjectPosition;
                Debug.WriteLine("UNDO");
                Debug.WriteLine("jml object setelah UNDO :" + _objects.Count);
                undo = true;
                Refresh();
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            draw = false; select = false;
            currentDrawingTool = 4;
            select = true;
            Debug.WriteLine("S E L E C T ");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            select = false;
            if (undo = true)
            {
                int lastObjectPosition = _objects.Count - 1;
                if (lastObjectPosition < _fullobjects.Count && lastObjectPosition > -1 && _fullobjects[lastObjectPosition + 1] != null)
                {
                    _objects.Add(_fullobjects[lastObjectPosition + 1]);
                    Refresh();
                    Debug.WriteLine("REDO");
                    Debug.WriteLine("jml object setelah REDO :" + _objects.Count);
                }
                else if (_objects.Count == 0)
                {
                    _objects.Add(_fullobjects[0]);
                    Refresh();
                    Debug.WriteLine("REDO");
                    Debug.WriteLine("jml object setelah REDO :" + _objects.Count);
                }
                else Debug.WriteLine("Out of bounds!");
            }
            undo = false;
        }

        private void DrawControlBorder(int x, int y, int w, int h)
        {
            int DRAG_HANDLE_SIZE = 2;
            //define the 8 drag handles, that has the size of DRAG_HANDLE_SIZE
            System.Drawing.Rectangle one = new System.Drawing.Rectangle(
                new Point(x, y),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            System.Drawing.Rectangle two = new System.Drawing.Rectangle(
                new Point(x + w / 2, y),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            System.Drawing.Rectangle three = new System.Drawing.Rectangle(
                new Point(x + w, y),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            System.Drawing.Rectangle four = new System.Drawing.Rectangle(
                new Point(x, y + h / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            System.Drawing.Rectangle five = new System.Drawing.Rectangle(
                new Point(x + w, y + h / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            System.Drawing.Rectangle six = new System.Drawing.Rectangle(
                new Point(x, y + h),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            System.Drawing.Rectangle seven = new System.Drawing.Rectangle(
                new Point(x + w / 2, y + h),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            System.Drawing.Rectangle eight = new System.Drawing.Rectangle(
                new Point(x + w, y + h),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
        }
    }
}
