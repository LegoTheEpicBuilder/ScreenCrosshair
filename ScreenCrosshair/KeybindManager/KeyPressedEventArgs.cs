using Keybinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keybinds
{
    public class KeyPressedEventArgs : EventArgs
    {
        public Keybind Keybind { get; private set; }
        public KeyPressedEventArgs(Keybind keybind) 
        {
            Keybind = keybind;
        }
    }
}
