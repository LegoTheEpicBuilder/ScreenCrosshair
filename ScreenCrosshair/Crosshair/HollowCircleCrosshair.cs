using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScreenCrosshair.Crosshair
{
    public class HollowCircleCrosshair : Crosshair
    {
        public override void DrawCrosshair(Graphics graphics, Pen pen, Point drawingPosition, int size)
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            graphicsPath.AddEllipse(drawingPosition.X - size / 2, drawingPosition.Y - size / 2, size, size);

            graphics.DrawPath(pen, graphicsPath);
        }
    }
}
