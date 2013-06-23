using System;
using System.ComponentModel;

namespace Shortcut
{
    [Serializable]
    public sealed class HotkeyNotBoundException : Win32Exception
    {
        public HotkeyNotBoundException(int errorCode)
            : base (errorCode)
        {
            
        }
    }
}
