using System.Collections.Generic;

namespace Shortcut
{
    internal class HotkeyContainer : Dictionary<HotkeyCombination, HotkeyCallback>
    {
        internal new void Add(HotkeyCombination hotkeyCombo, HotkeyCallback callback)
        {
            if (ContainsKey(hotkeyCombo))
                throw new HotkeyAlreadyBoundException("This HotkeyCombination has already been bound");

            base.Add(hotkeyCombo, callback);
        }

        internal new void Remove(HotkeyCombination hotkeyCombo)
        {
            if (!ContainsKey(hotkeyCombo))
                throw new HotkeyNotBoundException("This HotkeyCombination was never bound");

            base.Remove(hotkeyCombo);
        }
    }
}