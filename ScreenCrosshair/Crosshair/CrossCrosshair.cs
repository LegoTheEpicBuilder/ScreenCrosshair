using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCrosshair.Crosshair
{
    public class CrossCrosshair : Crosshair
    {
        public override CrosshairType Type { get { return CrosshairType.Cross; } }

        public override void DrawCrosshair(Graphics graphics, Pen pen, SolidBrush brush, Point drawingPosition, int size)
        {
            float lineLengthMultiplier = 0.75f;

            //horizontal
            graphics.DrawLine(pen, drawingPosition.X - size * lineLengthMultiplier, drawingPosition.Y, drawingPosition.X + size * lineLengthMultiplier, drawingPosition.Y);
            //vertical
            graphics.DrawLine(pen, drawingPosition.X, drawingPosition.Y - size * lineLengthMultiplier, drawingPosition.X, drawingPosition.Y + size * lineLengthMultiplier);
        }
    }
}
