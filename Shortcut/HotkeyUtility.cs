using System;
using System.Windows.Forms;

namespace Shortcut
{
    public static class HotkeyUtility
    {
        public static Modifiers MapKeysToModifiers(Keys key)
        {
            Modifiers modifier = Modifiers.None;

            if (Enum.IsDefined(typeof(Modifiers), key.ToString()))
            {
                modifier |= (Modifiers) Enum.Parse(typeof (Modifiers), key.ToString());
            }

            return modifier;
        }

        public static Keys MapModifiersToKeys(Modifiers modifier)
        {
            Keys key = Keys.None;

            key |= (Keys) Enum.Parse(typeof (Keys), modifier.ToString());

            return key;
        }
    }
}