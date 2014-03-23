using System.Windows.Forms;

namespace Shortcut
{
    public static class HotkeyExtensions
    {
        public static HotkeyCallback Bind(this HotkeyBinder hotkeyBinder, Modifiers modifier, Keys key)
        {
            return hotkeyBinder.Bind(new HotkeyCombination(modifier, key));
        }
    }
}
