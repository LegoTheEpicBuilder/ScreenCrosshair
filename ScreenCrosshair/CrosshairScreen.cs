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
using System.Runtime.InteropServices;

namespace ScreenCrosshair
{
    public partial class CrosshairScreen : Form
    {
        public static CrosshairScreen ActiveCrosshairScreen { get; private set; }
        public static KeybindsManager KeybindsManager { get; private set; }
        public static CrosshairManager CrosshairManager { get; private set; }
        public static RegionReader RegionReader { get; private set; }

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

        private int _crosshairSize;
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
        private int _colorPickingSize = 40;

        public StandardCrosshair CrosshairDrawing { get; private set; }
        private Color _colorReversed;
        
        // Windows API Interop constants
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x20;
        private Timer UpdateTimer;
        private IContainer components;
        private const int WS_EX_TOPMOST = 0x8;

        private const uint WDA_NONE = 0x00000000;
        private const uint WDA_MONITOR = 0x00000001;
        private const uint WDA_EXCLUDEFROMCAPTURE = 0x00000011;

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

            //setting up standard values for temporarily settings
            _crosshairSize = Properties.Settings.Default.CrosshairSize;
            _refreshesPerSecond = 1000 / UpdateTimer.Interval;

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

            //region reader initializing
            RegionReader = new RegionReader();
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
                if (Settings == null || Settings.IsDisposed)
                {
                    Settings = new SettingsForm();
                    Settings.Show();
                }
                else if (Settings.Visible)
                {
                    Settings.Hide();
                }
                else
                {
                    Settings.Show();
                    Settings.Activate();
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
            _colorPickingSize = (int)Math.Round(CrosshairManager.Size * 1.5);

            Rectangle region = new Rectangle(CrosshairManager.DrawingPosition.X - _colorPickingSize / 2, CrosshairManager.DrawingPosition.Y - _colorPickingSize / 2, _colorPickingSize, _colorPickingSize);
            Rectangle excludingRegion = new Rectangle(CrosshairManager.DrawingPosition.X - CrosshairManager.Size / 2, CrosshairManager.DrawingPosition.Y - CrosshairManager.Size / 2, CrosshairManager.Size, CrosshairManager.Size);

            RegionReader.Region = region;
            RegionReader.ExcludingRegion = excludingRegion;

            _colorReversed = RegionReader.GetMostReadableColorOverRegion();

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

            if (!SetWindowDisplayAffinity(this.Handle, WDA_EXCLUDEFROMCAPTURE))
            {
                int error = Marshal.GetLastWin32Error();
                Debug.WriteLine($"SetWindowDisplayAffinity failed: {error}");
            }

            //no flickering
            this.DoubleBuffered = true;

            this.Paint += CrosshairScreen_Paint;
        }

        private void CrosshairScreen_Paint(object sender, PaintEventArgs e)
        {
            CrosshairManager.ChangeColor(_colorReversed);
            CrosshairManager.Draw(e.Graphics);

            //debugging
            //e.Graphics.DrawRectangle(Pens.Red, RegionReader.Region);
            //e.Graphics.DrawRectangle(Pens.Blue, RegionReader.ExcludingRegion);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Invalidate();
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

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