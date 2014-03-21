using System;
using System.Windows.Forms;

namespace Shortcut
{
    internal sealed class HotkeyWindow : NativeWindow, IDisposable
    {
        internal event EventHandler<HotkeyPressedEventArgs> HotkeyPressed = delegate { }; 

        internal HotkeyWindow()
        {
            CreateHandle(new CreateParams());    
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                var modifier = (Modifiers) ((int) m.LParam & 0xFFFF);
                var key = (Keys) ((int) m.LParam >> 16);
                var combination = new HotkeyCombination(modifier, key);

                HotkeyPressed(this, new HotkeyPressedEventArgs(combination));
            }
            base.WndProc(ref m);
        }

        public void Dispose()
        {
            DestroyHandle();
        }
    }
}