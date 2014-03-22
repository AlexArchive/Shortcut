using System;
using System.Windows.Forms;
using NUnit.Framework;

namespace Shortcut.Test.Unit
{
    [TestFixture]
    public class HotkeyBinderTest
    {
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
        private readonly HotkeyCombination _hotkeyCombination = new HotkeyCombination(Modifiers.Control, Keys.F10);
        private readonly Action _callback = delegate { };

        [Test]
        public void CanUnbindHotkey()
        {
            _hotkeyBinder.Bind(_hotkeyCombination);
            _hotkeyBinder.Unbind(_hotkeyCombination);

            Assert.DoesNotThrow(() => _hotkeyBinder.Bind(_hotkeyCombination));
        }

        [Test]
        public void CannotRegisterSameHotkeyTwice()
        {
            _hotkeyBinder.Bind(_hotkeyCombination).To(_callback);

            Assert.Throws<HotkeyAlreadyBoundException>(() => _hotkeyBinder.Bind(_hotkeyCombination).To(_callback));
        }

        [Test]
        public void CanDetermineWhetherHotkeyHasAlreadyBeenBound()
        {
            Assert.False(_hotkeyBinder.IsHotkeyAlreadyBound(_hotkeyCombination));
            _hotkeyBinder.Bind(_hotkeyCombination).To(_callback);

            Assert.True(_hotkeyBinder.IsHotkeyAlreadyBound(_hotkeyCombination));
            _hotkeyBinder.Unbind(_hotkeyCombination);

            Assert.False(_hotkeyBinder.IsHotkeyAlreadyBound(_hotkeyCombination));
        }

        [TearDown]
        public void TearDown()
        {
            if (_hotkeyBinder.IsHotkeyAlreadyBound(_hotkeyCombination))
            {
                _hotkeyBinder.Unbind(_hotkeyCombination);
            }
        }
    }
}
