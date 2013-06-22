using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            _hotkeyCallbacks.Add(hotkeyCombination, callback);
            RegisterHotkeyCombination(hotkeyCombination);
            return callback;
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
            {
                Marshal.GetLastWin32Error();
            }
        }

        public void UnregisterHotkeyCombination(HotkeyCombination hotkeyCombination)
        {
            if (!NativeMethods.UnregisterHotKey(_hotkeyWindow.Handle, hotkeyCombination.GetHashCode()))
                throw new Exception("", new Win32Exception(Marshal.GetLastWin32Error()));



        }


    }
}