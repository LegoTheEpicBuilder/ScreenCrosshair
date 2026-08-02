using ScreenCrosshair;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Keybinds
{
    public class KeybindsManager
    {
        public event EventHandler<KeyPressedEventArgs> KeyPressed;
        public event EventHandler<KeybindEditCompletedEventArgs> KeybindEditCompleted;
        public event EventHandler<KeybindEditFailedEventArgs> KeybindEditFailed;

        public List<Keybind> Keybinds { get; private set; } = new List<Keybind> { };

        public Keybind KeybindToEdit { get; private set; }
        
        private IntPtr _windowHandle;
        
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey
        (
            IntPtr hWnd,
            int id,
            uint fsModifiers,
            Keys vk
        );

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey
        (
            IntPtr hWnd,
            int id
        );

        public KeybindsManager(IntPtr windowHandle) 
        { 
            _windowHandle = windowHandle;
        }

        public bool RegisterKeybind(Keybind keybind)
        {
            bool success = RegisterHotKey(_windowHandle, keybind.KeyId, 0, keybind.Key);

            return success;
        }

        public void RegisterAllKeybinds()
        {
            foreach (Keybind keybind in Keybinds)
            {
                RegisterKeybind(keybind);
            }
        }

        public void ChangeKeybindToEdit(Keybind keybind)
        {
            KeybindToEdit = keybind;
        }

        public void UnregisterKeybind(Keybind keybind)
        {
            UnregisterHotKey(_windowHandle, keybind.KeyId);
        }
        public void UnregisterAllKeybinds()
        {
            foreach (Keybind keybind in Keybinds)
            {
                UnregisterKeybind(keybind);
            }
        }

        public void ResetKeybindKeys()
        {
            foreach (Keybind keybind in Keybinds)
            {
                keybind.ResetKey();
            }
        }

        public void ChangeKeybind(Keybind keybind, Keys key)
        {
            if (keybind == null) { return; }
            
            Keys oldKey = keybind.Key;
            
            if (oldKey == key) //not allowed to assign a new key if the previous key was the same
            {
                KeybindEditFailed?.Invoke(this, new KeybindEditFailedEventArgs(keybind));
                return; 
            }

            if (Keybinds.Any(k => k != keybind && k.Key == key)) //duplicate keys not allowed in the same manager
            {
                KeybindEditFailed?.Invoke(this, new KeybindEditFailedEventArgs(keybind));

                return;
            }

            UnregisterKeybind(keybind);

            keybind.Key = key;

            bool success = RegisterKeybind(keybind);

            if (!success) //in case the keybind did not register, revert to the old key
            {
                keybind.Key = oldKey;
                RegisterKeybind(keybind);

                KeybindEditFailed?.Invoke(this, new KeybindEditFailedEventArgs(keybind));
            }
            else
            {
                KeybindEditCompleted?.Invoke(this, new KeybindEditCompletedEventArgs(keybind));
            }
        }

        public void OnFormClosing() //this has to run in the Form's OnFormClosing()
        {
            UnregisterAllKeybinds();
        }

        public void ProcessCmdKey(ref Message smg, Keys key) //this has to run in the Form's ProcessCmdKey() (only needed if you want to option to override keybinds)
        {
            Debug.WriteLine("ProcessCmdKey is processing");

            ChangeKeybind(KeybindToEdit, key);
            KeybindToEdit = null;
        }

        public void WndProc(Message m) //this has to run in the Form's WndProc()
        {
            if (KeybindToEdit != null) { return; }
            
            const int WM_HOTKEY = 0x0312;

            if (m.Msg != WM_HOTKEY) { return; }

            int id = m.WParam.ToInt32();

            //informing the subscriber which keybind was pressed
            Keybind keybind = Keybinds.FirstOrDefault(k => k.KeyId == id);

            if (keybind != null)
            {
                KeyPressed?.Invoke(this, new KeyPressedEventArgs(keybind));
            }
        }

        public Keybind GetKeybindFromKeyFunction(string keyFunction)
        {
            return CrosshairScreen.KeybindsManager.Keybinds.FirstOrDefault(keybind => keybind.KeyFunction.Equals(keyFunction));
        }
    }
}
