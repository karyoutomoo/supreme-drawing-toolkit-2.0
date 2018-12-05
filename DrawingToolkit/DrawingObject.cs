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

        public abstract void DrawObject(Graphics g);
        public abstract bool Intersect(int xTest, int yTest);
        public abstract void RenderOnPreview(Graphics graphics, int color);

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
