using System;

namespace Shortcut
{
    internal class HotkeyPressedEventArgs : EventArgs
    {
        internal HotkeyCombination HotkeyCombination { get; private set; }

        internal HotkeyPressedEventArgs(HotkeyCombination hotkeyCombination)
        {
            HotkeyCombination = hotkeyCombination;
        }
    }
}