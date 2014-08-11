using Shortcut.Forms;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Shortcut
{
    /// <summary>
    /// Represents a combination of keys that constitute a system-wide hotkey.
    /// </summary>
    [Serializable]
    [Editor(typeof(HotkeyEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(HotkeyConverter))]
    public class Hotkey : IEquatable<Hotkey>
    {
        /// <summary>
        /// The modifer keys that constitute this <see cref="Hotkey"/>.
        /// </summary>
        public Modifiers Modifier { get; private set; }

        /// <summary>
        /// The keys that constitute this <see cref="Hotkey"/>.
        /// </summary>
        public Keys Key { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hotkey"/> class.
        /// </summary>
        public Hotkey(Modifiers modifier, Keys key)
        {
            Key = key;
            Modifier = modifier;
        }

        #region IEquatable<HotkeyCombination> Members

        /// <summary>
        /// Indicates whether the value of this <see cref="Hotkey"/> is equal to the
        /// value of the specified <see cref="Hotkey"/>.
        /// </summary>
        /// <param name="other">The value to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the value of this <see cref="Hotkey"/> is equal to the 
        /// value of the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Hotkey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Modifier.Equals(other.Modifier) && Key.Equals(other.Key);
        }

        #endregion

        #region Object overrides
        
        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to
        /// this instance.
        /// </summary>
        /// <param name="other">
        /// The <see cref="System.Object"/> to compare with this instance.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specifed <see cref="System.Object"/> is equal to this 
        /// instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            return Equals((Hotkey) other);
        }

        /// <summary>
        /// Returns the hash code for this <see cref="Hotkey"/>.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Modifier.GetHashCode() * 397) ^ Key.GetHashCode();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Modifier + ", " + Key;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Implements the operator == (equality).
        /// </summary>
        /// <param name="left">The left-hand side of the operator.</param>
        /// <param name="right">The right-hand side of the operator.</param>
        /// <returns>
        /// <c>true</c> if values are equal to each other, otherwise <c>false</c>.
        /// </returns>
        public static bool operator ==(Hotkey left, Hotkey right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the operator != (inequality)
        /// </summary>
        /// <param name="left">The left-hand side of the operator.</param>
        /// <param name="right">The right-hand side of the operator.</param>
        /// <returns>
        /// <c>true</c> if values are not equal to each other, otherwise <c>false</c>.
        /// </returns>
        public static bool operator !=(Hotkey left, Hotkey right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
