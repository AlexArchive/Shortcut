using System.Windows.Forms;

namespace Shortcut.Demo.Console
{
    public class Program
    {
        private static readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();

        private static void Main()
        {
            System.Console.WriteLine("Run this application and press Ctrl + F");
            _hotkeyBinder.Bind(Modifiers.Control, Keys.F).To(HotkeyCallback);

            // Calling Run is the key to using Shortcut with console applications.
            // 
            Application.Run();
        }

        private static void HotkeyCallback()
        {
            System.Console.WriteLine("Hello, World");
        }
    }
}
