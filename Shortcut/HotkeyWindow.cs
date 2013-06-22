using System;
using System.Windows.Forms;

namespace Shortcut
{
    internal sealed class HotkeyWindow : NativeWindow, IDisposable
    {
        internal event EventHandler<HotkeyPressedEventArgs> HotkeyPressed;

        internal HotkeyWindow()
        {
            CreateHandle(new CreateParams());    
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                HotkeyCombination pressedHotkeyCombination =
                    new HotkeyCombination((Modifiers)((uint)m.LParam & 0xFFFF), (Keys)((uint)m.LParam >> 16));

                if (HotkeyPressed != null)
                    HotkeyPressed(this, new HotkeyPressedEventArgs(pressedHotkeyCombination));
            }
            base.WndProc(ref m);
        }

        public void Dispose()
        {
            DestroyHandle();
        }
    }
}
