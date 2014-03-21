using System;

namespace Shortcut
{
    public class HotkeyCallback
    {
        public Action Callback { get; private set; }

        public void To(Action callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");
            Callback = callback;
        }

        public void Invoke()
        {
            Callback.Invoke();
        }
    }
}