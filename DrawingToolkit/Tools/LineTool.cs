using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class ExampleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;

        public Cursor Cursor => throw new NotImplementedException();

        public ICanvas TargetCanvas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
