using System;

namespace Shortcut
{
    public class HotkeyPressedEventArgs : EventArgs
    {
        public HotkeyCombination HotkeyCombination { get; private set; }

        public HotkeyPressedEventArgs(HotkeyCombination hotkeyCombination)
        {
            HotkeyCombination = hotkeyCombination;
        }
    }
}
