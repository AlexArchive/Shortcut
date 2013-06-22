using System;

namespace Shortcut
{
    public class HotkeyCallback
    {
        private readonly HotkeyBinder _parent;
        private Action _callback;

        public HotkeyCallback(HotkeyBinder parent)
        {
            _parent = parent;
        }

        public HotkeyBinder To(Action callback)
        {
            _callback = callback;
            return _parent;
        }

        public void Invoke()
        {
            _callback.Invoke();
        }

    }
}
