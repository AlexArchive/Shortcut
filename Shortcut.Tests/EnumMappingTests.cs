using System.Windows.Forms;
using NUnit.Framework;

namespace Shortcut.Tests
{
    [TestFixture]
    public class EnumMappingTests
    {
        [Test]
        public void Test_Mapping_Keys_Enumeration_Value_To_Modifiers_Enumeration_Value()
        {
            Assert.That(HotkeyUtility.MapKeysToModifiers(Keys.Control) == Modifiers.Control);
            Assert.That(HotkeyUtility.MapKeysToModifiers(Keys.Alt) == Modifiers.Alt);
            Assert.That(HotkeyUtility.MapKeysToModifiers(Keys.Shift) == Modifiers.Shift);

            Assert.That(HotkeyUtility.MapKeysToModifiers(Keys.A) == Modifiers.None);
        }

        [Test]
        public void Test_Mapping_Modifiers_Enumeration_Value_To_Keys_Enumeration_Value()
        {
            Assert.That(HotkeyUtility.MapModifiersToKeys(Modifiers.Control) == Keys.Control);
            Assert.That(HotkeyUtility.MapModifiersToKeys(Modifiers.Alt) == Keys.Alt);
            Assert.That(HotkeyUtility.MapModifiersToKeys(Modifiers.Shift) == Keys.Shift);

            Assert.That(HotkeyUtility.MapModifiersToKeys(Modifiers.Control) == Keys.Control);

        }
    }
}
