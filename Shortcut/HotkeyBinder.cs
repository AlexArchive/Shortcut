using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Shortcut
{
    public class HotkeyBinder
    {
        public IDictionary<HotkeyCombination, HotkeyCallback> _hotkeyCallbacks =
            new Dictionary<HotkeyCombination, HotkeyCallback>();

        private readonly HotkeyWindow _hotkeyWindow = new HotkeyWindow();

        public HotkeyBinder()
        {
            _hotkeyWindow.HotkeyPressed += OnHotkeyPressed;
        }

        public HotkeyCallback Bind(HotkeyCombination hotkeyCombination)
        {
            if (hotkeyCombination == null)
                throw new ArgumentNullException("hotkeyCombination");

            HotkeyCallback callback = new HotkeyCallback(this);
            Foo(hotkeyCombination, callback);

            RegisterHotkeyCombination(hotkeyCombination);

            return callback;
        }

        private void Foo(HotkeyCombination hotkeyCombination, HotkeyCallback callback)
        {
            if (_hotkeyCallbacks.ContainsKey(hotkeyCombination))
                throw new HotkeyAlreadyBoundException("This hotkey has already been bound");
            
            _hotkeyCallbacks.Add(hotkeyCombination, callback);
        }
        

        private void OnHotkeyPressed(object sender, HotkeyPressedEventArgs e)
        {
            HotkeyCallback callback = _hotkeyCallbacks[e.HotkeyCombination];
            callback.Invoke();
        }

        private void RegisterHotkeyCombination(HotkeyCombination hotkeyCombination)
        {
            bool success = NativeMethods.RegisterHotKey(_hotkeyWindow.Handle, hotkeyCombination.GetHashCode(), (uint) hotkeyCombination.Modifier, (uint) hotkeyCombination.Key);
            
            if (success == false)
                throw new HotkeyAlreadyBoundException(Marshal.GetLastWin32Error());
        }

        public void UnregisterHotkeyCombination(HotkeyCombination hotkeyCombination)
        {
            bool success = NativeMethods.UnregisterHotKey(_hotkeyWindow.Handle, hotkeyCombination.GetHashCode());

            if (success == false)
                throw new HotkeyNotBoundException(Marshal.GetLastWin32Error());
        }


    }
}