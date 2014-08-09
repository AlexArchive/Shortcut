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

        // Unconventional, I know. But you can watch my screen-cast where I explain
        // this particular method in more detail if you want: http://youtu.be/dvtV3jc4maY
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                var combination = ExtractHotkeyCombination(m);
                HotkeyPressed(this, new HotkeyPressedEventArgs(combination));
            }
            base.WndProc(ref m);
        }

        private static Hotkey ExtractHotkeyCombination(Message m)
        {
            var modifier = (Modifiers) ((int) m.LParam & 0xFFFF);
            var key = (Keys) ((int) m.LParam >> 16);
            return new Hotkey(modifier, key);
        }

        public void Dispose()
        {
            DestroyHandle();
        }
    }
}