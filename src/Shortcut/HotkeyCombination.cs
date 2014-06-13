using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Shortcut
{
    /// <summary>
    /// Represents a combination of keys that constitute a system-wide hotkey.
    /// </summary>
    [Serializable]
    [Editor(typeof(HotkeyCombinationEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(HotkeyCombinationConverter))]
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

        // Casts are explicit as data can be lost (the win key mod)

        /// <summary>
        /// Explicit cast from HotkeyCombination to Keys
        /// </summary>
        public static explicit operator Keys(HotkeyCombination hotkey)
        {
            Keys keys = Keys.None;

            if (hotkey.Modifier.HasFlag(Modifiers.Alt))
                keys |= Keys.Alt;

            if (hotkey.Modifier.HasFlag(Modifiers.Control))
                keys |= Keys.Control;

            if (hotkey.Modifier.HasFlag(Modifiers.Shift))
                keys |= Keys.Shift;

            keys |= hotkey.Key;

            return keys;
        }

        /// <summary>
        /// Extract non-modifiers from the low word of keys
        /// </summary>
        private static Keys ExtractNonMods(Keys keys)
        {
            return (Keys)((int)keys & 0x0000FFFF);
        }

        /// <summary>
        /// Explicit cast from Keys to HotkeyCombination
        /// </summary>
        public static explicit operator HotkeyCombination(Keys keys)
        {
            var mods = Modifiers.None;
            if (keys.HasFlag(Keys.Alt)) mods |= Modifiers.Alt;
            if (keys.HasFlag(Keys.Control)) mods |= Modifiers.Control;
            if (keys.HasFlag(Keys.Shift)) mods |= Modifiers.Shift;
            Keys nonMods = ExtractNonMods(keys);
            return new HotkeyCombination(mods, nonMods);
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

    /// <summary>
    /// Provides an editor for a HotkeyCombination 
    /// </summary>
    public class HotkeyCombinationEditor : ShortcutKeysEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            Keys keys = (value == null) ? Keys.None : (Keys)((HotkeyCombination)value);
            object obj = base.EditValue(context, provider, keys);
            return (HotkeyCombination)((Keys)obj);
        } 
    }

    /// <summary>
    /// Provides a converter for a HotkeyCombination 
    /// </summary>
    public class HotkeyCombinationConverter : KeysConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var obj = base.ConvertFrom(context, culture, value);
            if (obj == null) return null;
            return (HotkeyCombination)((Keys)obj);
        }
    } 
}
