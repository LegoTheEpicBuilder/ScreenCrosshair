using System.Windows.Forms;

namespace Keybinds
{
    public class Keybind
    {
        public string KeyFunction { get; protected set; }
        public int KeyId { get; protected set; }

        protected Keys _key;
        public virtual Keys Key { get { return _key; } set { _key = value; } }
        public Keys OriginalKey { get; protected set; }

        public KeybindsManager Context { get; protected set; }

        public Keybind(string keyFunction, Keys key, KeybindsManager context)
        {
            KeyFunction = keyFunction;
            Key = key;
            OriginalKey = key;

            Context = context;
            KeyId = Context.Keybinds.Count;

            Context.Keybinds.Add(this);
        }

        public void ResetKey()
        {
            Key = OriginalKey;

            OnKeyReset();
        }

        protected virtual void OnKeyReset()
        {

        }
    }
}
