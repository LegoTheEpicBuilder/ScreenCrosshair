using System;
using System.Windows.Forms;

namespace Keybinds
{
    public class KeybindButton : Keybind
    {
        private Button _button;
        public Button Button 
        { 
            get { return _button; } 
            set 
            { 
                if (_button == value) { return; }

                if (_button != null) 
                {
                    _button.Click -= Button_OnClick;
                }

                _button = value;

                if (_button != null) 
                {
                    _button.Click += Button_OnClick;
                    
                    UpdateButtonText();
                }
            } 
        }

        public override Keys Key 
        {
            get { return _key; }
            set 
            { 
                _key = value; 
                
                if (Button != null) 
                { 
                    UpdateButtonText();
                }
            }
        }

        public KeybindButton(string keyFunction, Keys key, KeybindsManager context, Button button) : base(keyFunction, key, context)
        {
            Button = button;
        }

        private void Button_OnClick(object sender, EventArgs e)
        {
            Context.ChangeKeybindToEdit(this);
        }

        protected override void OnKeyReset()
        {
            base.OnKeyReset();

            Context.UnregisterKeybind(this);
            Context.RegisterKeybind(this);

            UpdateButtonText();
        }

        public void UpdateButtonText()
        {
            Button.Text = Key.ToString();
        }
    }
}
