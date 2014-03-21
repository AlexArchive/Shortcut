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
        public void That_User_Cannot_Register_Same_HotkeyCombination_Twice()
        {
            _hotkeyBinder.Bind(_combination).To(_callback);
            
            Assert.Throws<HotkeyAlreadyBoundException>(() => _hotkeyBinder.Bind(_combination).To(_callback));
        }

        [Test]
        public void That_User_Can_Unbind_Bound_HotkeyCombination()
        {
            _hotkeyBinder.Bind(_combination);
            _hotkeyBinder.Unbind(_combination);

            Assert.DoesNotThrow(() => _hotkeyBinder.Bind(_combination));
        }

        [Test]
        public void Can_Successfully_Determine_Whether_HotkeyCombination_Is_Already_Registered()
        {
            Assert.False(_hotkeyBinder.IsHotkeyAlreadyRegistered(_combination));
            _hotkeyBinder.Bind(_combination).To(_callback);

            Assert.True(_hotkeyBinder.IsHotkeyAlreadyRegistered(_combination));
            _hotkeyBinder.Unbind(_combination);

            Assert.False(_hotkeyBinder.IsHotkeyAlreadyRegistered(_combination));
        }

        [Test]
        public void Cannot_Bind_HotkeyCombination_To_Null_Callback()
        {
            Assert.Throws<ArgumentNullException>(() => _hotkeyBinder.Bind(_combination).To(null));
        }

        [TearDown]
        public void TearDown()
        {
            if (_hotkeyBinder.IsHotkeyAlreadyRegistered(_combination))
            {
                _hotkeyBinder.Unbind(_combination);
            }
        }
    }
}
