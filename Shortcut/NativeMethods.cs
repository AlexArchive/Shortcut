using System;
using System.Runtime.InteropServices;

namespace Shortcut
{
    /// <summary>
    /// Platform Invocation methods are declared by this class.
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Registers a system-wide hot key.
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool RegisterHotKey(IntPtr windowHandle, int hotkeyId, uint modifier, uint key);

        /// <summary>
        /// Frees a system-wide hot key previously registered by this application.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool UnregisterHotKey(IntPtr windowHandle, int hotkeyId);
    }
}