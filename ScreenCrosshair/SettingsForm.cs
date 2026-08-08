using Keybinds;
using ScreenCrosshair.Crosshair;
using ScreenCrosshair.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCrosshair
{
    public partial class SettingsForm : Form
    {
        private bool _initializing;

        public SettingsForm()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void MoveUpKeybindButton_Click(object sender, EventArgs e)
        {
            CrosshairScreen.KeybindsManager.ChangeKeybindToEdit(CrosshairScreen.KeybindsManager.Keybinds.First(keybind => keybind.KeyFunction.Equals("MoveUp")));
        }

        private void MoveDownKeybindButton_Click(object sender, EventArgs e)
        {
            CrosshairScreen.KeybindsManager.ChangeKeybindToEdit(CrosshairScreen.KeybindsManager.Keybinds.First(keybind => keybind.KeyFunction.Equals("MoveDown")));
        }

        private void MoveLeftKeybindButton_Click(object sender, EventArgs e)
        {
            CrosshairScreen.KeybindsManager.ChangeKeybindToEdit(CrosshairScreen.KeybindsManager.Keybinds.First(keybind => keybind.KeyFunction.Equals("MoveLeft")));
        }

        private void MoveRightKeybindButton_Click(object sender, EventArgs e)
        {
            CrosshairScreen.KeybindsManager.ChangeKeybindToEdit(CrosshairScreen.KeybindsManager.Keybinds.First(keybind => keybind.KeyFunction.Equals("MoveRight")));
        }

        private void ResetPositioningKeybindButton_Click(object sender, EventArgs e)
        {
            CrosshairScreen.KeybindsManager.ChangeKeybindToEdit(CrosshairScreen.KeybindsManager.Keybinds.First(keybind => keybind.KeyFunction.Equals("ResetCrosshairPosition")));
        }

        private void ResetControlsButton_Click(object sender, EventArgs e)
        {
            CrosshairScreen.KeybindsManager.ResetKeybindKeys();
        }
        private void RefreshesPerSecondNumericBox_ValueChanged(object sender, EventArgs e)
        {
            CrosshairScreen.ActiveCrosshairScreen.RefreshesPerSecond = (int)RefreshesPerSecondNumericBox.Value;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _initializing = true; //making sure events don't get raised when setting forms elements

            CrosshairTypeComboBox.DataSource = Enum.GetValues(typeof(CrosshairType));

            RefreshesPerSecondNumericBox.Value = CrosshairScreen.ActiveCrosshairScreen.RefreshesPerSecond;
            CrosshairSizeNumericBox.Value = CrosshairScreen.ActiveCrosshairScreen.CrosshairSize;
            CrosshairTypeComboBox.SelectedItem = CrosshairScreen.CrosshairManager.Model.Type;

            foreach (Keybind keybind in CrosshairScreen.KeybindsManager.Keybinds)
            {
                if (keybind is KeybindButton keybindButton) 
                {
                    if (keybindButton.KeyFunction.Equals("ResetCrosshairPosition")) { keybindButton.Button = ResetPositioningKeybindButton; }
                    else if (keybindButton.KeyFunction.Equals("MoveUp")) { keybindButton.Button = MoveUpKeybindButton; }
                    else if (keybindButton.KeyFunction.Equals("MoveDown")) { keybindButton.Button = MoveDownKeybindButton; }
                    else if (keybindButton.KeyFunction.Equals("MoveLeft")) { keybindButton.Button = MoveLeftKeybindButton; }
                    else if (keybindButton.KeyFunction.Equals("MoveRight")) { keybindButton.Button = MoveRightKeybindButton; }
                }
            }

            _initializing = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            CrosshairScreen.KeybindsManager?.ProcessCmdKey(ref msg, keyData);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SaveKeybind(string functionName, Action<Keys> saveAction)
        {
            if (CrosshairScreen.KeybindsManager.GetKeybindFromKeyFunction(functionName) is Keybind keybind)
            {
                saveAction(keybind.Key);
            }
        }

        private void SaveKeybindsButton_Click(object sender, EventArgs e)
        {
            SaveKeybind("ToggleSettings", key => Settings.Default.ToggleSettings = key);
            SaveKeybind("ResetCrosshairPosition", key => Settings.Default.ResetCrosshairPosition = key);
            SaveKeybind("MoveUp", key => Settings.Default.MoveUp = key);
            SaveKeybind("MoveDown", key => Settings.Default.MoveDown = key);
            SaveKeybind("MoveLeft", key => Settings.Default.MoveLeft = key);
            SaveKeybind("MoveRight", key => Settings.Default.MoveRight = key);

            Settings.Default.Save();
        }

        private void CrosshairSizeNumericBox_ValueChanged(object sender, EventArgs e)
        {
            CrosshairScreen.ActiveCrosshairScreen.CrosshairSize = (int)CrosshairSizeNumericBox.Value;
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Default.RefreshesPerSecond = (int)RefreshesPerSecondNumericBox.Value;
            Settings.Default.CrosshairSize = (int)CrosshairSizeNumericBox.Value;
            Settings.Default.CrosshairType = (int)((CrosshairType)CrosshairTypeComboBox.SelectedIndex);

            Settings.Default.Save();
        }

        private void ResetSettingsButton_Click(object sender, EventArgs e)
        {
            RefreshesPerSecondNumericBox.Value = 10;
            CrosshairSizeNumericBox.Value = 16;
            CrosshairTypeComboBox.SelectedItem = CrosshairType.Standard;
        }

        private void CrosshairTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initializing) { return; }

            CrosshairScreen.CrosshairManager.SetCrosshairByType((CrosshairType)CrosshairTypeComboBox.SelectedItem);
        }
    }
}
