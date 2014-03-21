using System;
using System.Windows.Forms;

namespace Shortcut
{
    public class HotkeyCombination : IEquatable<HotkeyCombination>
    {
        public Modifiers Modifier { get; private set; }

        public Keys Key { get; private set; }

        public HotkeyCombination(Modifiers modifier, Keys key)
        {
            Key = key;
            Modifier = modifier;
        }

        public bool Equals(HotkeyCombination other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Modifier.Equals(other.Modifier) && Key.Equals(other.Key);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            return Equals((HotkeyCombination) other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Modifier.GetHashCode() * 397) ^ Key.GetHashCode();
            }
        }

        public static bool operator ==(HotkeyCombination a, HotkeyCombination b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(HotkeyCombination a, HotkeyCombination b)
        {
            return !Equals(a, b);
        }
    }
}
