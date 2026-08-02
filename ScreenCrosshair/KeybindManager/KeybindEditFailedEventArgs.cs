using System;

namespace Keybinds
{
    public class KeybindEditFailedEventArgs : EventArgs
    {
        public Keybind Keybind { get; private set; }

        public KeybindEditFailedEventArgs(Keybind keybind)
        {
            Keybind = keybind;
        }
    }
}