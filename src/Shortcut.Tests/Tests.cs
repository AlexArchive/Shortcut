using System;
using System.Windows.Forms;
using NUnit.Framework;

namespace Shortcut.Tests
{
    [TestFixture]
    public class Tests
    {
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
        private readonly HotkeyCombination _combination = new HotkeyCombination(Modifiers.Control, Keys.F10);
        private readonly Action _callback = delegate { };

        [Test]
        public void Have_To_Register_HotkeyCombination_With_Valid_Method()
        {
            Assert.Throws<ArgumentNullException>(() => _hotkeyBinder.Bind(_combination).To(null));
            _hotkeyBinder.Unbind(_combination);
        }

        [Test]
        public void Is_Registered_Method_Works()
        {
            Assert.False(_hotkeyBinder.IsHotkeyAlreadyRegistered(_combination));
            _hotkeyBinder.Bind(_combination).To(_callback);
            Assert.True(_hotkeyBinder.IsHotkeyAlreadyRegistered(_combination));
            _hotkeyBinder.Unbind(_combination);
            Assert.False(_hotkeyBinder.IsHotkeyAlreadyRegistered(_combination));
        }

        [Test]
        public void That_User_Cannot_Register_Same_HotkeyCombination_Twice()
        {
            _hotkeyBinder.Bind(_combination).To(_callback);
            Assert.Throws<HotkeyAlreadyBoundException>(() => _hotkeyBinder.Bind(_combination).To(_callback));
            _hotkeyBinder.Unbind(_combination);
        }

        [Test]
        public void Unbind_Hotkey_Works()
        {
            _hotkeyBinder.Bind(_combination);
            Assert.DoesNotThrow(() => _hotkeyBinder.Unbind(_combination), "This hotkey has already been bound");
            _hotkeyBinder.Bind(_combination);
            _hotkeyBinder.Unbind(_combination);
        }
    }
}
