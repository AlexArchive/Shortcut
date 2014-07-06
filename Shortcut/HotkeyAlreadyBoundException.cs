using System;
using System.ComponentModel;

namespace Shortcut
{
    /// <summary>
    /// Exception thrown to indicate that specified <see cref="HotkeyCombination"/>
    /// cannot be bound because it has been previously bound either by this application
    /// or another running application.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This normally occurs when you attempt to bind a <see cref="HotkeyCombination"/> 
    /// that has previously been bound by this application. 
    /// </para>
    /// <para>
    /// This can also occur when another running application has already bound the 
    /// specified <see cref="HotkeyCombination"/>.  
    /// </para>
    /// <para>
    /// Use the <see cref="HotkeyBinder.Unbind"/> Method to unbind a 
    /// <see cref="HotkeyCombination"/> previously bound by this application.
    /// </para>
    /// <para>
    /// Use the <see cref="HotkeyBinder.IsHotkeyAlreadyBound"/> Method to 
    /// determine whether the <see cref="HotkeyCombination"/> in question has already
    /// been bound either by this application or another running application.
    /// </para>
    /// </remarks>
    [Serializable]
    public sealed class HotkeyAlreadyBoundException : Win32Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyAlreadyBoundException"/> class with the specified error.
        /// </summary>
        /// <param name="errorCode">The Win32 error code associated with this exception.</param>
        public HotkeyAlreadyBoundException(int errorCode)
            : base(errorCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyAlreadyBoundException"/> class with the specified detailed description.
        /// </summary>
        /// <param name="message">A detailed description of the error.</param>
        public HotkeyAlreadyBoundException(string message)
            : base(message)
        {
        }
    }
}