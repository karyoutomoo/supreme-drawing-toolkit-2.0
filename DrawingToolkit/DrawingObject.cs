using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        private Graphics graphics;
        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        private DrawingState state;
        public abstract void DrawObject(Graphics g);
        public abstract void DrawEdit();
        public abstract void DrawStatic();
        public abstract void DrawHandle(Graphics g);
        public abstract Point GetHandlePoint(int value);
        public abstract int GetClickHandle(Point posisi);//mendapat titik yang diklik
        public abstract bool Intersect(int xTest, int yTest);
        public abstract void RenderOnPreview(Graphics graphics, int color);
        public abstract void Translate(int difX, int difY);
        public abstract void Resize(int posisiClick, Point posisi);

        public virtual void SetGraphics(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public virtual Graphics GetGraphics()
        {
            return this.graphics;
        }
    }
}
