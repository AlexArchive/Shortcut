using System;
using System.ComponentModel;

namespace Shortcut
{
    /// <summary>
    /// Exception thrown to indicate that the specified <see cref="HotkeyCombination"/>
    /// cannot be unbound because it has not previously been bound by this application.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This normally occurs when you attempt to unbind a <see cref="HotkeyCombination"/>
    /// that was not previously bound by this application.
    /// </para>
    /// <para>
    /// You cannot unbind a <see cref="HotkeyCombination"/> registered by another application.
    /// </para>
    /// </remarks>
    [Serializable]
    public sealed class HotkeyNotBoundException : Win32Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyAlreadyBoundException"/> class 
        /// with the specified error.
        /// </summary>
        /// <param name="errorCode">The Win32 error code associated with this exception.</param>
        public HotkeyNotBoundException(int errorCode)
            : base(errorCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyAlreadyBoundException"/> class 
        /// with the specified detailed description.
        /// </summary>
        /// <param name="message">A detailed description of the error.</param>
        public HotkeyNotBoundException(string message)
            : base(message)
        {
        }
    }
}