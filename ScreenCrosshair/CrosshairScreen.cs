using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using System.Diagnostics;
using Keybinds;
using ScreenCrosshair.Crosshair;

namespace ScreenCrosshair
{
    public partial class CrosshairScreen : Form
    {
        public static CrosshairScreen ActiveCrosshairScreen { get; private set; }
        public static KeybindsManager KeybindsManager { get; private set; }
        public static CrosshairManager CrosshairManager { get; private set; }
        public SettingsForm Settings { get; private set; }

        private int _refreshesPerSecond = Properties.Settings.Default.RefreshesPerSecond;
        public int RefreshesPerSecond
        {
            get { return _refreshesPerSecond; }
            set
            {
                if (_refreshesPerSecond == value) { return; }

                _refreshesPerSecond = value;

                UpdateTimer.Interval = 1000 / _refreshesPerSecond;
            }
        }

        private int _crosshairSize = Properties.Settings.Default.CrosshairSize;
        public int CrosshairSize { 
            get { return _crosshairSize; }
            set
            {
                if (_crosshairSize == value) { return; }

                _crosshairSize = value;

                CrosshairManager.Size = _crosshairSize;
            }
        }

        private int _crosshairRepositionAmount = 2;
        private int _colorPickingSize = 30;

        public StandardCrosshair CrosshairDrawing { get; private set; }
        private Color _colorReversed;
        
        // Windows API Interop constants
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x20;
        private Timer UpdateTimer;
        private IContainer components;
        private const int WS_EX_TOPMOST = 0x8;

        public CrosshairScreen()
        {
            InitializeComponent();

            ActiveCrosshairScreen = this;

            SetUpScreen();

            UpdateTimer.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _refreshesPerSecond = 1000 / UpdateTimer.Interval;

            Settings = new SettingsForm();
            Settings.Dispose();

            //keybind manager initializing
            KeybindsManager = new KeybindsManager(this.Handle);

            KeybindsManager.KeyPressed += OnKeybindPressed;

            new Keybind("ToggleSettings", Properties.Settings.Default.ToggleSettings, KeybindsManager);
            new KeybindButton("ResetCrosshairPosition", Properties.Settings.Default.ResetCrosshairPosition, KeybindsManager, null);

            new KeybindButton("MoveUp", Properties.Settings.Default.MoveUp, KeybindsManager, null);
            new KeybindButton("MoveDown", Properties.Settings.Default.MoveDown, KeybindsManager, null);
            new KeybindButton("MoveLeft", Properties.Settings.Default.MoveLeft, KeybindsManager, null);
            new KeybindButton("MoveRight", Properties.Settings.Default.MoveRight, KeybindsManager, null);

            KeybindsManager.RegisterAllKeybinds();

            //crosshair drawing initializing
            CrosshairManager = new CrosshairManager();
            CrosshairManager.SetCrosshairByType((CrosshairType)Properties.Settings.Default.CrosshairType);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            KeybindsManager?.OnFormClosing();
            
            base.OnFormClosing(e);
        }

        private void OnKeybindPressed(object sender, KeyPressedEventArgs e)
        {
            Debug.WriteLine(CrosshairManager.DrawingPosition);

            if (e.Keybind.KeyFunction.Equals("ResetCrosshairPosition")) 
            { 
                CrosshairManager.ResetDrawingPosition();
            }
            else if (e.Keybind.KeyFunction.Equals("MoveUp")) 
            {
                CrosshairManager.IncreaseDrawingPosition(new Point(0, -_crosshairRepositionAmount));
            }
            else if (e.Keybind.KeyFunction.Equals("MoveDown"))
            {
                CrosshairManager.IncreaseDrawingPosition(new Point(0, _crosshairRepositionAmount));
            }
            else if (e.Keybind.KeyFunction.Equals("MoveLeft"))
            {
                CrosshairManager.IncreaseDrawingPosition(new Point(-_crosshairRepositionAmount, 0));
            }
            else if (e.Keybind.KeyFunction.Equals("MoveRight"))
            {
                CrosshairManager.IncreaseDrawingPosition(new Point(_crosshairRepositionAmount, 0));
            }
            else if (e.Keybind.KeyFunction.Equals("ToggleSettings")) 
            {
                Debug.WriteLine(Settings.Visible);

                if (Settings.IsDisposed) 
                { 
                    Settings = new SettingsForm();
                    Settings.Show();
                }
                else
                {
                    Settings.Dispose();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //KeybindsManager?.ProcessCmdKey(ref msg, keyData);
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void WndProc(ref Message m)
        {
            KeybindsManager?.WndProc(m);

            base.WndProc(ref m);
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {            
            Color color = Utilities.GetAverageColorRaw(new Rectangle(CrosshairManager.DrawingPosition.X - _colorPickingSize / 2, CrosshairManager.DrawingPosition.Y - _colorPickingSize / 2, _colorPickingSize, _colorPickingSize));
            _colorReversed = Utilities.GetReverseBlackOrWhite(color);
            //MessageBox.Show($"{color.ToString()}/n{colorReverse.ToString()}");

            Invalidate();
        }

        private void SetUpScreen()
        {
            //fullscreen & borderless
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            //always on top
            this.TopMost = true;

            //transparent
            this.BackColor = Color.Wheat; // Any unique color
            this.TransparencyKey = Color.Wheat; // This hides the color AND passes clicks through

            //can click through this form
            int initialStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, initialStyle | WS_EX_TRANSPARENT | WS_EX_TOPMOST);

            //no flickering
            this.DoubleBuffered = true;

            this.Paint += CrosshairScreen_Paint;
        }

        private void CrosshairScreen_Paint(object sender, PaintEventArgs e)
        {
            CrosshairManager.ChangeColor(_colorReversed);
            CrosshairManager.Draw(e.Graphics);

            //debugging
            //e.Graphics.DrawRectangle(Pens.Red, CrosshairDrawing.DrawingPosition.X - _colorPickingSize / 2, CrosshairDrawing.DrawingPosition.Y - _colorPickingSize / 2, _colorPickingSize, _colorPickingSize);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Invalidate();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // CrosshairScreen
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "CrosshairScreen";
            this.ResumeLayout(false);

        }
    }
}