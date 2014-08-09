using System;
using System.ComponentModel;

namespace Shortcut
{
    /// <summary>
    /// Exception thrown to indicate that specified <see cref="Hotkey"/> cannot be 
    /// bound because it has been previously bound either by this application or 
    /// another running application.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This exception normally occurs when you attempt to bind a 
    /// <see cref="Hotkey"/> that has previously been bound by this application. 
    /// </para>
    /// <para>
    /// This exception can also occur when another running application has already 
    /// bound the specified <see cref="Hotkey"/>.  
    /// </para>
    /// <para>
    /// Use the <see cref="HotkeyBinder.Unbind"/> method to unbind a 
    /// <see cref="Hotkey"/> previously bound by this application.
    /// </para>
    /// <para>
    /// Use the <see cref="HotkeyBinder.IsHotkeyAlreadyBound"/> function to 
    /// determine whether the <see cref="Hotkey"/> in question has already been 
    /// bound either by this application or another running application.
    /// </para>
    /// </remarks>
    [Serializable]
    public sealed class HotkeyAlreadyBoundException : Win32Exception
    {
        internal HotkeyAlreadyBoundException(int error) : base(error)
        {
        }

        internal HotkeyAlreadyBoundException(string message) : base(message)
        {
        }
    }
}