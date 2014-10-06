using System;
using System.Windows.Forms;
using Shortcut.Demo.WinForms.Forms;

namespace Shortcut.Demo.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
