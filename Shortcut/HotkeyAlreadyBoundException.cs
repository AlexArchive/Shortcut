using System;
using System.ComponentModel;

namespace Shortcut
{
    [Serializable]
    public sealed class HotkeyAlreadyBoundException : Win32Exception 
    {
        public HotkeyAlreadyBoundException(int errorCode) 
            : base (errorCode)
        {
            
        }

        public HotkeyAlreadyBoundException(string message) 
            : base (message)
        {
            
        }
    }
}
