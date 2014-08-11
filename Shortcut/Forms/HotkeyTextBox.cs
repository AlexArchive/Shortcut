using System.Windows.Forms;

namespace Shortcut.Forms
{
    public sealed class HotkeyTextBox : TextBox
    {
        private Hotkey hotkey;
        public Hotkey Hotkey
        {
            get { return hotkey; }
            set
            {
                hotkey = value;

                if (hotkey != null)
                {
                    RenderText();
                }
            }
        }

        public HotkeyTextBox()
        {
            Text = "None";
            GotFocus += delegate { NativeMethods.HideCaret(Handle); };
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Reset();
                return;
            }

            var converter = new HotkeyConverter();
            Hotkey = (Hotkey) converter.ConvertFrom(e.KeyData);
            RenderText();
        }

        private void RenderText()
        {
            if (Hotkey.Modifier != Modifiers.None)
            {
                Text = Hotkey.Modifier.ToString().Replace(", ", " + ");

                if (Hotkey.Key != Keys.None && !IsModifier(hotkey.Key))
                {
                    Text += " + " + Hotkey.Key;
                }
                return;
            }

            Text = Hotkey.Key.ToString();
        }

        private static bool IsModifier(Keys keys)
        {
            // TODO: I feel as though there should be a clever way to do this using a binary operator.
            return keys == Keys.ControlKey || 
                   keys == Keys.Menu || 
                   keys == Keys.ShiftKey;
        }

        private void Reset()
        {
            Hotkey = new Hotkey(Modifiers.None, Keys.None);
            Text = "None";
        }
    }
}

// TODO: Not at all sure that this solution is robust. What will happen if the user enters a modifier but no key etc.?