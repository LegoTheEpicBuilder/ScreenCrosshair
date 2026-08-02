using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ScreenCrosshair
{
    public class CrosshairDrawing
    {
        public Rectangle Bounds { get { return Screen.PrimaryScreen.Bounds; } }

        private int _size = 16;
        public int Size 
        { 
            get { return _size; } 
            set
            {
                _size = value % 2 == 0 ? value : value + 1;
            }
        }
        public Point StartPosition { get { return new Point(Bounds.Left + Bounds.Width / 2, Bounds.Top + Bounds.Height / 2); } }
        public Point DrawingPosition { get; private set; }
        
        private Pen _pen;

        public CrosshairDrawing() 
        {
            _pen = new Pen(Color.Black);
            DrawingPosition = StartPosition;
        }

        public void ChangeColor(Color color)
        {
            _pen.Color = color;
        }

        public void DrawCrosshair(Graphics graphics)
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            float lineLengthMultiplier = 0.75f;

            graphicsPath.AddEllipse(DrawingPosition.X - Size / 2, DrawingPosition.Y - Size / 2, Size, Size);
            
            //horizontal
            graphics.DrawLine(_pen, DrawingPosition.X - Size * lineLengthMultiplier, DrawingPosition.Y, DrawingPosition.X + Size * lineLengthMultiplier, DrawingPosition.Y);
            //vertical
            graphics.DrawLine(_pen, DrawingPosition.X, DrawingPosition.Y - Size * lineLengthMultiplier, DrawingPosition.X, DrawingPosition.Y + Size * lineLengthMultiplier);
            //drawing the hollow circle
            graphics.DrawPath(_pen, graphicsPath);
        }

        public void IncreaseDrawingPosition(Point point)
        {
            DrawingPosition = new Point(DrawingPosition.X + point.X, DrawingPosition.Y + point.Y);
        }

        public void ResetDrawingPosition()
        {
            DrawingPosition = StartPosition;
        }
    }
}
