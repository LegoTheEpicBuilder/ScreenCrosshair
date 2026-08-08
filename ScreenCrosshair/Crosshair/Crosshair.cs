using Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ScreenCrosshair.Crosshair
{
    public abstract class Crosshair : ModelBaseClass
    {
        public abstract CrosshairType Type { get; }
        public abstract void DrawCrosshair(Graphics graphics, Pen pen, SolidBrush brush, Point drawingPosition, int size);
    }
}
