using System;

namespace Keybinds
{
    public class KeybindEditCompletedEventArgs : EventArgs
    {
        public Keybind Keybind { get; private set; }

        public KeybindEditCompletedEventArgs(Keybind keybind) 
        { 
            Keybind = keybind;
        }
    }
}