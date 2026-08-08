using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScreenCrosshair.Crosshair
{
    public class HollowCircleCrosshair : Crosshair
    {
        public override CrosshairType Type { get { return CrosshairType.HollowCircle; } }
        public override void DrawCrosshair(Graphics graphics, Pen pen, SolidBrush brush, Point drawingPosition, int size)
        {
            graphics.DrawEllipse(pen, drawingPosition.X - size / 2, drawingPosition.Y - size / 2, size, size);
        }
    }
}
