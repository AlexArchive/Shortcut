using System;
using System.Windows.Forms;

namespace Shortcut
{
    /// <summary>
    /// Invisible window used to effectively look-out for incoming Windows messages that 
    /// indicate that a system-wide hot key registered to this application has been pressed.
    /// </summary>
    internal sealed class HotkeyWindow : NativeWindow, IDisposable
    {
        /// <summary>
        /// Occurs when a system-wide hot key registered to this application is pressed.
        /// </summary>
        internal event EventHandler<HotkeyPressedEventArgs> HotkeyPressed = delegate { }; 

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyWindow"/> class.
        /// </summary>
        internal HotkeyWindow()
        {
            CreateHandle(new CreateParams());    
        }

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
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

        /// <summary>
        /// Destroys the window and its handle. 
        /// </summary>
        public void Dispose()
        {
            DestroyHandle();
        }
    }
}