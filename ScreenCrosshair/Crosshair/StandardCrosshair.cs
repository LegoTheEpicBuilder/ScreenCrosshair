using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScreenCrosshair.Crosshair
{
    public class StandardCrosshair : Crosshair
    {
        public override CrosshairType Type { get { return CrosshairType.Standard; } }
        public override void DrawCrosshair(Graphics graphics, Pen pen, Point drawingPosition, int size)
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            float lineLengthMultiplier = 0.75f;

            graphicsPath.AddEllipse(drawingPosition.X - size / 2, drawingPosition.Y - size / 2, size, size);
            
            //horizontal
            graphics.DrawLine(pen, drawingPosition.X - size * lineLengthMultiplier, drawingPosition.Y, drawingPosition.X + size * lineLengthMultiplier, drawingPosition.Y);
            //vertical
            graphics.DrawLine(pen, drawingPosition.X, drawingPosition.Y - size * lineLengthMultiplier, drawingPosition.X, drawingPosition.Y + size * lineLengthMultiplier);
            //drawing the hollow circle
            graphics.DrawPath(pen, graphicsPath);
        }
    }
}
