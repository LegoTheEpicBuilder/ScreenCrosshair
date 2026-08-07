using Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace ScreenCrosshair.Crosshair
{
    public class CrosshairManager : PresenterBaseClass<Crosshair>
    {
        protected Pen _pen;
        public Rectangle Bounds { get { return Screen.PrimaryScreen.Bounds; } }
        public Point StartPosition { get { return new Point(Bounds.Left + Bounds.Width / 2, Bounds.Top + Bounds.Height / 2); } }
        public Point DrawingPosition { get; protected set; }

        private int _size = 16;
        public int Size
        {
            get { return _size; }
            set
            {
                _size = value % 2 == 0 ? value : value + 1;
            }
        }

        public CrosshairManager()
        {
            _pen = new Pen(Color.Black);
            DrawingPosition = StartPosition;
        }

        protected override void ModelSetInitialization(Crosshair previousModel)
        {
            base.ModelSetInitialization(previousModel);
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        public void Draw(Graphics graphics)
        {
            Model.DrawCrosshair(graphics, _pen, DrawingPosition, Size);
        }
        public void ChangeColor(Color color)
        {
            _pen.Color = color;
        }
        public void IncreaseDrawingPosition(Point point)
        {
            DrawingPosition = new Point(DrawingPosition.X + point.X, DrawingPosition.Y + point.Y);
        }

        public void ResetDrawingPosition()
        {
            DrawingPosition = StartPosition;
        }

        public void SetCrosshairByType(CrosshairType crosshairType)
        {
            if (Model != null && crosshairType.Equals(Model.Type)) { return; }

            if (crosshairType.Equals(CrosshairType.Standard)) { Model = new StandardCrosshair(); }
            else if (crosshairType.Equals(CrosshairType.HollowCircle)) { Model = new HollowCircleCrosshair(); }
        }
    }
}
