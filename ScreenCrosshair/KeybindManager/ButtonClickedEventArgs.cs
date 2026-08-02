using System;

namespace Keybinds
{
    public class ButtonClickedEventArgs : EventArgs
    {
        public Keybind Keybind { get; private set; }

        public ButtonClickedEventArgs(Keybind keybind)
        {
            Keybind = keybind;
        }
    }
}