using System;

namespace Shortcut
{
    /// <summary>
    /// Represents a callback for a <see cref="Hotkey"/> binding.
    /// </summary>
    public class HotkeyCallback
    {
        private Action callback;

        public bool Assigned { get { return callback != null; }}  

        /// <summary>
        /// Indicates that the <see cref="Hotkey"/> should be bound to the specified
        /// <paramref name="callback"/>.
        /// </summary>
        public void To(Action callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");
            this.callback = callback;
        }

        internal void Invoke()
        {
            callback.Invoke();
        }
    }
}