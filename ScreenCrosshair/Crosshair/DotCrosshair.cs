using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCrosshair.Crosshair
{
    public class DotCrosshair : Crosshair
    {
        public override CrosshairType Type { get { return CrosshairType.Dot; } }

        public override void DrawCrosshair(Graphics graphics, Pen pen, SolidBrush brush, Point drawingPosition, int size)
        {
            graphics.FillEllipse(brush, drawingPosition.X - size / 2, drawingPosition.Y - size / 2, size, size);   
        }
    }
}
