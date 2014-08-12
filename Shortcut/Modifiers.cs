using System;

namespace Shortcut
{
    /// <summary>
    /// Modifier Keys.
    /// </summary>
    [Flags]
    public enum Modifiers
    {
        /// <summary>
        /// No modifier key pressed.
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// The ALT modifier key.
        /// </summary>
        Alt = 0x0001,

        /// <summary>
        /// The CTRL modifier key.
        /// </summary>
        Control = 0x0002,

        /// <summary>
        /// The SHIFT modifier key.
        /// </summary>
        Shift = 0x0004,

        /// <summary>
        /// The Windows logo key (Microsoft Natural Keyboard).
        /// </summary>
        Win = 0x0008
    }
}