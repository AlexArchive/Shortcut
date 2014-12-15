using System;
using System.Runtime.InteropServices;

namespace Shortcut
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool RegisterHotKey(
            IntPtr windowHandle, 
            int hotkeyId, 
            uint modifier, 
            uint key);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool UnregisterHotKey(
            IntPtr windowHandle, 
            int hotkeyId);

        [DllImport("user32.dll")]
        internal static extern bool HideCaret(IntPtr controlHandle);
    }
}