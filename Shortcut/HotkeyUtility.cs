using System;
using System.Windows.Forms;

namespace Shortcut
{
    public static class HotkeyUtility
    {
        public static Modifiers MapKeysToModifiers(Keys key)
        {
            //TODO: The algorithm needs adopting so that when Keys.LWin or Keys.RWin is input 
            //TODO: the function will return Modifiers.Win (it currently returns Modifiers.None)

            Modifiers modifier = Modifiers.None;

            if (Enum.IsDefined(typeof(Modifiers), key.ToString()))
            {
                modifier |= (Modifiers) Enum.Parse(typeof (Modifiers), key.ToString());
            }

            return modifier;
        }

        public static Keys MapModifiersToKeys(Modifiers modifier)
        {
            //TODO: This algorithm does not acount for the Modifiers.Win value!!

            Keys key = Keys.None;

            key |= (Keys) Enum.Parse(typeof (Keys), modifier.ToString());

            return key;
        }
    }
}