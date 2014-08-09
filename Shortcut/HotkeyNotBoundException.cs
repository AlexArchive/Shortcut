using System;
using System.ComponentModel;

namespace Shortcut
{
    /// <summary>
    /// Exception thrown to indicate that the specified <see cref="Hotkey"/> cannot 
    /// be unbound because it has not previously been bound by this application.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This exception normally occurs when you attempt to unbind a 
    /// <see cref="Hotkey"/> that was not previously bound by this application.
    /// </para>
    /// <para>
    /// You cannot unbind a <see cref="Hotkey"/> registered by another application.
    /// </para>
    /// </remarks>
    [Serializable]
    public sealed class HotkeyNotBoundException : Win32Exception
    {
        internal HotkeyNotBoundException(int errorCode) : base(errorCode)
        {
        }

        internal HotkeyNotBoundException(string message) : base(message)
        {
        }
    }
}