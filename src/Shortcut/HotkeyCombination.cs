using System;
using System.Windows.Forms;

namespace Shortcut
{
    /// <summary>
    /// Represents a combination of keys that constitute a system-wide hotkey.
    /// </summary>
    public class HotkeyCombination : IEquatable<HotkeyCombination>
    {
        /// <summary>
        /// The modifer key(s) that make up this <see cref="HotkeyCombination"/>.
        /// </summary>
        public Modifiers Modifier { get; private set; }

        /// <summary>
        /// The key(s) that make up this <see cref="HotkeyCombination"/>.
        /// </summary>
        public Keys Key { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyCombination"/> class.
        /// </summary>
        public HotkeyCombination(Modifiers modifier, Keys key)
        {
            Key = key;
            Modifier = modifier;
        }

        #region IEquatable<HotkeyCombination> Members

        /// <summary>
        /// Indicates whether the value of this <see cref="HotkeyCombination"/> is equal to the
        /// value of the specified <see cref="HotkeyCombination"/>.
        /// </summary>
        /// <param name="other">The value to compare with this instance.</param>
        /// <returns>
        /// true if the value of this <see cref="HotkeyCombination"/> is equal to the value
        /// of the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(HotkeyCombination other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Modifier.Equals(other.Modifier) && Key.Equals(other.Key);
        }

        #endregion

        #region Object overrides
        
        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specifed <see cref="System.Object"/> is equal to this instance;
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            return Equals((HotkeyCombination) other);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Modifier.GetHashCode() * 397) ^ Key.GetHashCode();
            }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Implements the operator == (equality).
        /// </summary>
        /// <param name="left">The left-hand side of the operator.</param>
        /// <param name="right">The right-hand side of the operator.</param>
        /// <returns><c>true</c> if values are equal to each other, otherwise <c>false</c>.</returns>
        public static bool operator ==(HotkeyCombination left, HotkeyCombination right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the operator != (inequality)
        /// </summary>
        /// <param name="left">The left-hand side of the operator.</param>
        /// <param name="right">The right-hand side of the operator.</param>
        /// <returns><c>true</c> if values are not equal to each other, otherwise <c>false</c>.</returns>
        public static bool operator !=(HotkeyCombination left, HotkeyCombination right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
