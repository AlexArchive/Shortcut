using System.Collections.Generic;

namespace Shortcut
{
    internal class HotkeyContainer : Dictionary<Hotkey, HotkeyCallback>
    {
        internal new void Add(Hotkey hotkeyCombo, HotkeyCallback callback)
        {
            if (ContainsKey(hotkeyCombo))
                throw new HotkeyAlreadyBoundException("This HotkeyCombination has already been bound");

            base.Add(hotkeyCombo, callback);
        }

        internal new void Remove(Hotkey hotkeyCombo)
        {
            if (!ContainsKey(hotkeyCombo))
                throw new HotkeyNotBoundException("This HotkeyCombination was never bound");

            base.Remove(hotkeyCombo);
        }
    }
}